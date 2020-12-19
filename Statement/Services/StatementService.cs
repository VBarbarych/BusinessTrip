using Microsoft.AspNetCore.Identity;
using BusinessTrip.Models;
using Microsoft.EntityFrameworkCore;
using Statement.Data;
using Statement.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statement.Services
{
    public class StatementService : IStatementService
    {
        private readonly ApplicationDbContext _context;
        private DbSet<ApplicationStatement> DbSet;

        public StatementService(ApplicationDbContext context)
        {
            _context = context;
            DbSet = context.Set<ApplicationStatement>();
        }

        public async Task EditItemAsync(ApplicationStatement statement)
        {
            _context.Update(statement);
            await _context.SaveChangesAsync();
        }

        public async Task CreateStatement(ApplicationStatement statement, IdentityUser user)
        {
            //Adding statement
            DbSet.Add(statement);
            _context.SaveChanges();
            //binding statement to user
            _context.AspUserStatement.Add(new ApplicationUserStatement
            {
                StatementId = statement.StatementId,
                Id = user.Id
            });
            //setting current status
            _context.AspCurrentStatus.Add(new ApplicationCurrentStatus { 
                CurrentСomment = "Подача заяви",
                StatementId = statement.StatementId,
                StatusId = 1,
                DateOfLastChanges = DateTime.Now
            });
            //adding current status to history of statuses
            _context.AspHistoryOfStatus.Add(new ApplicationHistoryOfStatus
            {
                HistoryOfStatusId = statement.StatementId,
                StatusId = 1,
                DateOfChanges = DateTime.Now,
                Сomment = "Подача заяви",
            });
            //
            await _context.SaveChangesAsync();
        }

        public StatementViewModel GetAllStatements()
        {
            var statements = _context.AspStatement.ToList();

            var statementViewModel = new StatementViewModel()
            {
                Statements = statements
            };
            return statementViewModel;
        }



        private void ReplaceStub(string stubToReplace, string text, Microsoft.Office.Interop.Word.Document worldDocument)
        {
            var range = worldDocument.Content;
            range.Find.ClearFormatting();
            object wdReplaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text, Replace: wdReplaceAll);
        }

        public byte[] WorkWithDocFile(ApplicationStatement statement)
        {
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            //Application app = new Application();
            //Document doc = app.Documents.Add(Visible: true);

            //var room = _context.Rooms.Where(x => x.Id == id);


            var wordDoc = wordApp.Documents.Add(Path.GetFullPath(@"documents\statement_foreign.docx"));//Открываем шаблон
            ReplaceStub("{Name}", statement.UserNameGenitiveCase.ToString(), wordDoc);//Заменяем метку на данные из формы(здесь конкретно из текстбокса с именем textBox_fio)
            ReplaceStub("{LastName}", statement.UserLastNameGenitiveCase.ToString(), wordDoc);
            ReplaceStub("{Surname}", statement.UserSurNameGenitiveCase.ToString(), wordDoc);
            ReplaceStub("{Place}", statement.InstitutionWhereYouGo.ToString(), wordDoc);
            ReplaceStub("{Country}", statement.StatementCountryOfDestination.ToString(), wordDoc);
            ReplaceStub("{City}", statement.StatementPlaceOfDestination.ToString(), wordDoc);
            ReplaceStub("{Purpose}", statement.PurposeOfBusinessTrip.ToString(), wordDoc);
            ReplaceStub("{Transport}", statement.TransportOfBusinessTrip.ToString(), wordDoc);
            ReplaceStub("{Route}", statement.RouteOfBusinessTrip.ToString(), wordDoc);
            ReplaceStub("{Basis}", statement.BasisOfBusinessTrip.ToString(), wordDoc);
            ///Может быть много таких меток
            string docText = wordDoc.WordOpenXML;
            var arr = Encoding.UTF8.GetBytes(docText);

            //_context.SaveChangesAsync();
            //using (Stream file = File.OpenWrite(Path.GetFullPath(@"documents\statement_foreign1.docx")))
            //{
            //    file.Write(bytes, 0, bytes.Length);
            //}

            //try
            //{ 
            //    File.WriteAllBytes(Path.GetFullPath(@"documents\statement_foreign1.docx"), bytes);
            //}
            //catch(Exception ex)
            //{

            //}
            //wordDoc.SaveAs(Path.GetFullPath(@"documents\statement_foreign1.docx"));
            //wordDoc.Save();

            //wordApp.Quit();
            //wordDoc.Close();

            //wordApp.Visible = true;
            return arr;

        }
    }
}
