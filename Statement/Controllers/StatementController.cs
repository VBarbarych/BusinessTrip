using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessTrip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Statement.Services;

namespace Statement.Controllers
{
    public class StatementController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService, UserManager<IdentityUser> userManager)
        {
            _statementService = statementService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            var statements = _statementService.GetAllStatements();
            return View(statements);
        }


        //[HttpGet]
        //public FileResult PDFDownload()
        //{

        //    var statements = _statementService.GetAllStatements().Statements.FirstOrDefault();

        //    byte[] pdfByte = _statementService.WorkWithDocFile(statements);

        //    return File(pdfByte, "i.docx", "doc");
        //}

        [HttpGet]
        public FileStreamResult PDFDownload()
        {
            var statements = _statementService.GetAllStatements().Statements.FirstOrDefault();
            byte[] pdfByte = _statementService.WorkWithDocFile(statements);
            var memoryStream = new MemoryStream(pdfByte);

            return File(memoryStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Заява на відрядження.doc");
        }



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

    }
}