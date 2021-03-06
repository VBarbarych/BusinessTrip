﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessTrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Statement.Services;
using Statement.Data;
using Statement.ViewModel;
using Microsoft.EntityFrameworkCore;
using Statement.Filters.AuthFilter;
using Statement.Models;

namespace Statement.Controllers
{
    [Auth]
    public class StatementController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStatementService _statementService;
        private ApplicationDbContext _context;

        public StatementController(IStatementService statementService, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _statementService = statementService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(user => user.Type.EndsWith("name"))?.Value;

            if (userName == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            var allStatements = _context.AspUserStatement.Where(x => x.Id == user.Id).Join(_context.AspStatement,
                                                     userStatement => userStatement.StatementId,
                                                     statement => statement.StatementId,
                                                     (userStatement, statement) => statement).ToList();


            var statementViewModel = new StatementViewModel()
            {
                Statements = allStatements
            };

            var statements = _statementService.GetAllStatements();

            return View(statementViewModel);
        }


        //[HttpGet]
        //public FileResult PDFDownload()
        //{

        //    var statements = _statementService.GetAllStatements().Statements.FirstOrDefault();

        //    byte[] pdfByte = _statementService.WorkWithDocFile(statements);

        //    return File(pdfByte, "i.docx", "doc");
        //}

        //[HttpGet]
        //public FileStreamResult PDFDownload()
        //{
        //    var statements = _statementService.GetAllStatements().Statements.FirstOrDefault();
        //    byte[] pdfByte = _statementService.WorkWithDocFile(statements);
        //    var memoryStream = new MemoryStream(pdfByte);

        //    return File(memoryStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Заява на відрядження.doc");
        //}

        //admin download
        [HttpGet]
        public FileStreamResult PDFDownload(int id)
        {
            var statements = _statementService.GetAllStatements().Statements.FirstOrDefault(statement => statement.StatementId == id);
            byte[] pdfByte = _statementService.WorkWithDocFile(statements);
            var memoryStream = new MemoryStream(pdfByte);
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Заява на відрядження.doc");
        }



        [HttpGet]
        public IActionResult CreateStatement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatement(CreateStatementViewModel statement)
        {
            if (ModelState.IsValid)
            {
                var userName = HttpContext.User.Claims.FirstOrDefault(user => user.Type.EndsWith("name"))?.Value;

                if (userName != null)
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    var applicationStatement = (ApplicationStatement)statement;
                    await _statementService.CreateStatement(applicationStatement, user);

                    if (HttpContext.User.Identity.Name == "Admin")
                    {

                        return RedirectToAction(nameof(Statements));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            return View(statement);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationStatement statement)
        {
            if (ModelState.IsValid)
            {
                var userName = HttpContext.User.Claims.FirstOrDefault(user => user.Type.EndsWith("name"))?.Value;

                if (userName != null)
                {
                    var user = await _userManager.FindByNameAsync(userName);
                    await _statementService.CreateStatement(statement, user);
                    //_statementService.WorkWithDocFile(statement);

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(statement);
        }

        //admin list of statements
        public IActionResult Statements()
        {
            var allStatements = _context.AspStatement.Join(_context.AspCurrentStatus,
                                                        statement => statement.StatementId,
                                                        currentStatus => currentStatus.StatementId,
                                                        (statement, currentStatus) => new StatementWithAllStatuses
                                                        {
                                                            Statement = statement,
                                                            CurrentStatus = currentStatus
                                                        }).ToList();
            var statuses = _context.AspStatus.ToList();
            foreach (var statement in allStatements)
            {
                statement.CurrentStatus.Status = statuses.
                    FirstOrDefault(status => status.StatusId == statement.CurrentStatus.StatusId);
            }
            return View(allStatements);
        }

        ////user list of statements
        //public async Task<IActionResult> Statements()
        //{
        //    var userName = HttpContext.User.Claims.FirstOrDefault(user => user.Type.EndsWith("name"))?.Value;
        //    if (userName == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var user = await _userManager.FindByNameAsync(userName);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var allStatements = userStatements.Join(_context.AspStatement,
        //                                             userStatement => userStatement.StatementId,
        //                                             statement => statement.StatementId,
        //                                             (userStatement, statement) => statement).ToList();
        //    return View(allStatements);
        //}

        //admin delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //
            var statement = await _context.AspStatement.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }
            //deleting on cascade
            _context.AspStatement.Remove(statement);
            _context.SaveChanges();
            return Redirect("/Statement/Statements");
        }

        ////user delete
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var statement = await _context.AspStatement.FindAsync(id);
        //    if (statement == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var userName = HttpContext.User.Claims.FirstOrDefault(user => user.Type.EndsWith("name"))?.Value;
        //    if (userName == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var user = await _userManager.FindByNameAsync(userName);
        //    if(user == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var userStatement = await _context.AspUserStatement.FindAsync(user.Id, statement.StatementId);
        //    if (userStatement == null)
        //    {
        //        return NotFound();
        //    }            
        //    //deleting on cascade
        //    _context.AspStatement.Remove(statement);
        //    _context.SaveChanges();
        //    return Redirect("/Statement/Statements");
        //}

        //admin edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statement = await _context.AspStatement.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }

            var statuses = _context.AspStatus.ToList();
            var statementCurrentStatus = _context.AspCurrentStatus.
                FirstOrDefault(currentStatus => currentStatus.StatementId == statement.StatementId);
            statementCurrentStatus.Status = statuses.
                FirstOrDefault(status => status.StatusId == statementCurrentStatus.StatusId);

            var statementHistoryOfStatuses = _context.AspHistoryOfStatus.
                Where(historyStatus => historyStatus.HistoryOfStatusId == statement.StatementId).
                OrderBy(historyStatus => historyStatus.DateOfChanges).ToList();
            foreach (var historyStatus in statementHistoryOfStatuses)
            {
                historyStatus.Status = statuses.
                    FirstOrDefault(status => status.StatusId == statementCurrentStatus.StatusId);
            }

            return View(new StatementWithAllStatuses
            {
                Statement = statement,
                CurrentStatus = statementCurrentStatus,
                HistoryOfStatuses = statementHistoryOfStatuses
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StatementWithAllStatuses editStatement)
        {
            if(editStatement.Statement.StatementId != id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    var userName = HttpContext.User.Claims.FirstOrDefault(user => user.Type.EndsWith("name"))?.Value;

                    if (userName != null)
                    {
                        editStatement.CurrentStatus.DateOfLastChanges = DateTime.Now;
                           var user = await _userManager.FindByNameAsync(userName);
                        await _statementService.EditItemAsync(editStatement.Statement);
                        _context.AspCurrentStatus.Update(editStatement.CurrentStatus);
                        _context.AspHistoryOfStatus.Add(new ApplicationHistoryOfStatus
                        {
                        DateOfChanges = editStatement.CurrentStatus.DateOfLastChanges,
                        HistoryOfStatusId = editStatement.CurrentStatus.StatementId,
                        StatusId = editStatement.CurrentStatus.StatusId,
                        Сomment = editStatement.CurrentStatus.CurrentСomment
                        });
                        _context.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.AspStatement.FindAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction(nameof(Statements));
            }
            return View(editStatement);
        }

        //details admin
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statement = await _context.AspStatement.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }

            var statuses = _context.AspStatus.ToList();
            var statementCurrentStatus = _context.AspCurrentStatus.
                FirstOrDefault(currentStatus => currentStatus.StatementId == statement.StatementId);
            statementCurrentStatus.Status = statuses.
                FirstOrDefault(status => status.StatusId == statementCurrentStatus.StatusId);

            var statementHistoryOfStatuses = _context.AspHistoryOfStatus.
                Where(historyStatus => historyStatus.HistoryOfStatusId == statement.StatementId).
                OrderBy(historyStatus => historyStatus.DateOfChanges).ToList();
            foreach (var historyStatus in statementHistoryOfStatuses)
            {
                historyStatus.Status = statuses.
                    FirstOrDefault(status => status.StatusId == historyStatus.StatusId);
            }

            return View(new StatementWithAllStatuses
            {
                Statement = statement,
                CurrentStatus = statementCurrentStatus,
                HistoryOfStatuses = statementHistoryOfStatuses
            });
        }

        //details user
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var statement = await _context.AspStatement.FindAsync(id);
        //    if (statement == null)
        //    {
        //        return NotFound();
        //    }

        //    var userName = HttpContext.User.Claims.FirstOrDefault(user => user.Type.EndsWith("name"))?.Value;
        //    if (userName == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var user = await _userManager.FindByNameAsync(userName);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var userStatement = await _context.AspUserStatement.FindAsync(user.Id, statement.StatementId);
        //    if (userStatement == null)
        //    {
        //        return NotFound();
        //    }
        //    //
        //    var statuses = _context.AspStatus.ToList();
        //    var statementCurrentStatus = _context.AspCurrentStatus.
        //        FirstOrDefault(currentStatus => currentStatus.StatementId == statement.StatementId);
        //    statementCurrentStatus.Status = statuses.
        //        FirstOrDefault(status => status.StatusId == statementCurrentStatus.StatusId);

        //    var statementHistoryOfStatuses = _context.AspHistoryOfStatus.
        //        Where(historyStatus => historyStatus.HistoryOfStatusId == statement.StatementId).
        //        OrderByDescending(historyStatus => historyStatus.DateOfChanges).ToList();
        //    foreach (var historyStatus in statementHistoryOfStatuses)
        //    {
        //        historyStatus.Status = statuses.
        //            FirstOrDefault(status => status.StatusId == statementCurrentStatus.StatusId);
        //    }

        //    return View(new StatementWithAllStatuses
        //    {
        //        Statement = statement,
        //        CurrentStatus = statementCurrentStatus,
        //        HistoryOfStatuses = statementHistoryOfStatuses
        //    });
        //}



        [HttpGet]
        public IActionResult StatementBetweenDates()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StatementBetweenDates([Bind("startDate,endDate")] BetweenDates dates)
        {
            DateTime some = dates.startDate;
            return View(dates);
        }

        public FileStreamResult ExcelStatementsBetweenDates(BetweenDates dates)
        {
            var memoryStream = _statementService.WriteExcelStatementsBetweenDates(dates);

            return File(memoryStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Всі заяви.xlsx");
        }
    }
}