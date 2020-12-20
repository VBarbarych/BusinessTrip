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
using OfficeOpenXml;
using Statement.Models;

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

            Microsoft.Office.Interop.Word.Document wordDoc;
            string docText = null;
            //var room = _context.Rooms.Where(x => x.Id == id);
            if(statement.TypeOfBusinessTrip == "Відрядження закордон")
            {


                wordDoc = wordApp.Documents.Add(Path.GetFullPath(@"documents\statement_foreign.docx"));//Открываем шаблон
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
                ReplaceStub("{TypeOfSalaryRetention}", statement.TypeOfBusinessTrip.ToString(), wordDoc);
                ReplaceStub("{PaymentOfTravelExpensesOption}", statement.PaymentOfTravelExpenses.ToString(), wordDoc);

                ///Может быть много таких меток
                docText = wordDoc.WordOpenXML;


            }
            else if(statement.TypeOfBusinessTrip == "Відрядження по Україні")
            {
                wordDoc = wordApp.Documents.Add(Path.GetFullPath(@"documents\statement_ukraine.docx"));//Открываем шаблон
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
                ReplaceStub("{TypeOfSalaryRetention}", statement.TypeOfBusinessTrip.ToString(), wordDoc);
                ReplaceStub("{PaymentOfTravelExpensesOption}", statement.PaymentOfTravelExpenses.ToString(), wordDoc);
                ReplaceStub("{DateStart}", statement.DateOfBusinessTrip.ToString(), wordDoc);
                ReplaceStub("{DateEnd}", statement.DateOfСompletionBusinessTrip.ToString(), wordDoc);

                ///Может быть много таких меток
                docText = wordDoc.WordOpenXML;

            }

            var arr = Encoding.UTF8.GetBytes(docText);


            return arr;
        }

        public MemoryStream WriteExcelStatementsBetweenDates(BetweenDates dates)
        {
            var memoryStream = new MemoryStream();
            var allStatements = _context.AspStatement.Join(_context.AspCurrentStatus,
                                                        statement => statement.StatementId,
                                                        currentStatus => currentStatus.StatementId,
                                                        (statement, currentStatus) => new StatementWithAllStatuses
                                                        {
                                                            Statement = statement,
                                                            CurrentStatus = currentStatus
                                                        }).Where(c => c.CurrentStatus.DateOfLastChanges >= dates.startDate && c.CurrentStatus.DateOfLastChanges <= dates.endDate).ToList();

            var statuses = _context.AspStatus.ToList();
            foreach (var statement in allStatements)
            {
                statement.CurrentStatus.Status = statuses.
                    FirstOrDefault(status => status.StatusId == statement.CurrentStatus.StatusId);
            }

            foreach(var item in allStatements)
            {
                item.Statement.UserLastNameGenitiveCase = String.IsNullOrEmpty(item.Statement.UserLastNameGenitiveCase) ? "" : item.Statement.UserLastNameGenitiveCase;
                item.Statement.UserSurNameGenitiveCase = String.IsNullOrEmpty(item.Statement.UserSurNameGenitiveCase) ? "" : item.Statement.UserSurNameGenitiveCase;
                item.Statement.UserNameGenitiveCase = String.IsNullOrEmpty(item.Statement.UserNameGenitiveCase) ? "" : item.Statement.UserNameGenitiveCase;
                item.Statement.SubdivisionAtTheMainPlaceOfWork = String.IsNullOrEmpty(item.Statement.SubdivisionAtTheMainPlaceOfWork) ? "" : item.Statement.SubdivisionAtTheMainPlaceOfWork;
                item.Statement.PositionAtTheMainPlaceOfWork = String.IsNullOrEmpty(item.Statement.PositionAtTheMainPlaceOfWork) ? "" : item.Statement.PositionAtTheMainPlaceOfWork;
                item.Statement.SubdivisionPartTime = String.IsNullOrEmpty(item.Statement.SubdivisionPartTime) ? "" : item.Statement.SubdivisionPartTime;
                item.Statement.PositionPartTime = String.IsNullOrEmpty(item.Statement.PositionPartTime) ? "" : item.Statement.PositionPartTime;
                item.Statement.TypeOfBusinessTrip = String.IsNullOrEmpty(item.Statement.TypeOfBusinessTrip) ? "" : item.Statement.TypeOfBusinessTrip;
                item.Statement.PurposeOfBusinessTrip = String.IsNullOrEmpty(item.Statement.PurposeOfBusinessTrip) ? "" : item.Statement.PurposeOfBusinessTrip;
                item.Statement.TypeOfSalaryRetention = String.IsNullOrEmpty(item.Statement.TypeOfSalaryRetention) ? "" : item.Statement.TypeOfSalaryRetention;
                item.Statement.StatementPlaceOfDestination = String.IsNullOrEmpty(item.Statement.StatementPlaceOfDestination) ? "" : item.Statement.StatementPlaceOfDestination;
                item.Statement.StatementCountryOfDestination = String.IsNullOrEmpty(item.Statement.StatementCountryOfDestination) ? "" : item.Statement.StatementCountryOfDestination;
                item.Statement.InstitutionWhereYouGo = String.IsNullOrEmpty(item.Statement.InstitutionWhereYouGo) ? "" : item.Statement.InstitutionWhereYouGo;
                item.Statement.RouteOfBusinessTrip = String.IsNullOrEmpty(item.Statement.RouteOfBusinessTrip) ? "" : item.Statement.RouteOfBusinessTrip;
                item.Statement.TransportOfBusinessTrip = String.IsNullOrEmpty(item.Statement.TransportOfBusinessTrip) ? "" : item.Statement.TransportOfBusinessTrip;
                item.Statement.PaymentOfTravelExpenses = String.IsNullOrEmpty(item.Statement.PaymentOfTravelExpenses) ? "" : item.Statement.PaymentOfTravelExpenses;
                item.Statement.BasisOfBusinessTrip = String.IsNullOrEmpty(item.Statement.BasisOfBusinessTrip) ? "" : item.Statement.BasisOfBusinessTrip;
                item.CurrentStatus.Status.StatusName = String.IsNullOrEmpty(item.CurrentStatus.Status.StatusName) ? "" : item.CurrentStatus.Status.StatusName;
            }

            var news_rows_isunder = new List<string[]>();
            var header_news_rows_under = new List<object[]>()
            {
                new object[] { "Прізвище, ім'я, по-батькові (Р.В.)", "Підрозділ та посада за основним місцем праці",
             "Відділ та посаду за сумісництвом (за наявності)", "Тип відрядження", "Мета відрядження", "Вид збереження заробітної плати",
                "Місто відрядження", "Країна відрядження (для закордонного відрядження)", "Установа (куди відрядження)",
                "Дата початку відрядження", "Дата завершення відрядження", "Маршрут поїздки (для відряджень по Україні)", "Транспорт (для відряджень по Україні)",
                "Здійснення оплати видатків на відрядження", "Підстава відрядження","Статус заяви", "Дата останньої зміни"}

            };

            using (ExcelPackage excel = new ExcelPackage())
            {

                excel.Workbook.Worksheets.Add("Поточні заяви");

                int j = 1;
                string header_under = "A" + j.ToString();
                j = j + header_news_rows_under.Count();

                string header_isunder = "A" + j.ToString();
                j = j + news_rows_isunder.Count();

                var worksheet = excel.Workbook.Worksheets["Поточні заяви"];
                worksheet.Cells[header_under].LoadFromArrays(header_news_rows_under);

                foreach (var item in allStatements)
                {
                    news_rows_isunder.Add(new string[] { item.Statement.UserSurNameGenitiveCase + " "+ item.Statement.UserNameGenitiveCase + " " + item.Statement.UserLastNameGenitiveCase,
                        item.Statement.SubdivisionAtTheMainPlaceOfWork + " " + item.Statement.PositionAtTheMainPlaceOfWork, item.Statement.SubdivisionPartTime + " " + item.Statement.PositionPartTime,
                        item.Statement.TypeOfBusinessTrip, item.Statement.PurposeOfBusinessTrip, item.Statement.TypeOfSalaryRetention, item.Statement.StatementPlaceOfDestination,
                    item.Statement.StatementCountryOfDestination, item.Statement.InstitutionWhereYouGo, item.Statement.DateOfBusinessTrip.ToString(), item.Statement.DateOfСompletionBusinessTrip.ToString(),
                    item.Statement.RouteOfBusinessTrip, item.Statement.TransportOfBusinessTrip, item.Statement.PaymentOfTravelExpenses, item.Statement.BasisOfBusinessTrip,
                    item.CurrentStatus.Status.StatusName,  item.CurrentStatus.DateOfLastChanges.ToString()});
                }

                worksheet.Cells[header_isunder].LoadFromArrays(news_rows_isunder);
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                news_rows_isunder.Clear();
                memoryStream = new MemoryStream(excel.GetAsByteArray());
            }
            return memoryStream;
        }
    }
}
