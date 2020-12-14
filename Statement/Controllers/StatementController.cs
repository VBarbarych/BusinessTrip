using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessTrip.Models;
using Microsoft.AspNetCore.Mvc;
using Statement.Services;

namespace Statement.Controllers
{
    public class StatementController : Controller
    {
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService)
        {
            _statementService = statementService;
        }

        public IActionResult Index()
        {
            return View();
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
                await _statementService.CreateStatement(statement);
                _statementService.WorkWithDocFile(statement);

                return RedirectToAction(nameof(Index));
            }

            return View(statement);
        }

    }
}