using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Statement.Common;
using BusinessTrip.Models;


namespace Statement.ViewModel
{
    public class CreateStatementViewModel
    {
        public int StatementId { get; set; }     // ключ

        [Required(ErrorMessage = "Поле Ім'я є обов'язковим")]
        [MaxLength(100)]
        [Display(Name = "Ім'я (у Родовому відмінку)")]
        public string UserNameGenitiveCase { get; set; }   //genitive case - родовий відмінок

        [Required(ErrorMessage = "Поле Прізвище є обов'язковим")]
        [MaxLength(100)]
        [Display(Name = "Прізвище (у Родовому відмінку)")]
        public string UserSurNameGenitiveCase { get; set; }   //genitive case - родовий відмінок

        [Required(ErrorMessage = "Поле По батькові є обов'язковим")]
        [MaxLength(100)]
        [Display(Name = "По батькові (у Родовому відмінку)")]
        public string UserLastNameGenitiveCase { get; set; }   //genitive case - родовий відмінок

        [Required(ErrorMessage = "Поле Підрозділ за основним місцем праці є обов'язковим")]
        [MaxLength(200)]
        [Display(Name = "Підрозділ за основним місцем праці")]
        public string SubdivisionAtTheMainPlaceOfWork { get; set; } // підрозділ  за основним місцем праці

        [Required(ErrorMessage = "Поле Посада за основним місцем праці є обов'язковим")]
        [MaxLength(100)]
        [Display(Name = "Посада за основним місцем праці")]
        public string PositionAtTheMainPlaceOfWork { get; set; } // підрозділ  за основним місцем праці

        [MaxLength(200)]
        [Display(Name = "Підрозділ за сумісництвом (за наявності)")]
        public string SubdivisionPartTime { get; set; } // підрозділ та посаду за за сумісництвом (за наявності) - необов'язково
        [MaxLength(100)]
        [Display(Name = "Посада за сумісництвом (за наявності)")]
        public string PositionPartTime { get; set; } // підрозділ та посаду за за сумісництвом (за наявності) - необов'язково

        [Required(ErrorMessage = "Поле Тип відрядження є обов'язковим")]
        [MaxLength(50)]
        [Display(Name = "Тип відрядження")]
        public string TypeOfBusinessTrip { get; set; } // тип відрядження 


        [Display(Name = "Мета відрядження")]
        public string PurposeOfBusinessTripOption { get; set; }     // мета відрядження 
        public string PurposeOfBusinessTripOther { get; set; }      // мета відрядження                                         ------------------------------------- other


        [Required(ErrorMessage = "Поле Вид збереження заробітної плати є обов'язковим")]
        [MaxLength(200)]
        [Display(Name = "Вид збереження заробітної плати")]
        public string TypeOfSalaryRetention { get; set; } // вид збереження заробітної плати


        [Required(ErrorMessage = "Поле Місто відрядження є обов'язковим")]
        [MaxLength(200)]
        [Display(Name = "Місто відрядження")]
        public string StatementPlaceOfDestination { get; set; }  // місто відрядження

        [MaxLength(200)]
        [Display(Name = "Країна відрядження (для закордонного відрядження)")]
        public string StatementCountryOfDestination { get; set; }  // країна відрядження  (для закордонного відрядження) - необов'язково

        [Display(Name = "Установа, куди відряджаєтесь")]
        public string InstitutionWhereYouGoOption { get; set; }       // установа, куди відряджаєтесь
        public string InstitutionWhereYouGoOther { get; set; }       // установа, куди відряджаєтесь   ------------------------------------- other

        [Required(ErrorMessage = "Поле Дата початку відрядження є обов'язковим")]
        [DataType(DataType.DateTime, ErrorMessage = "Введіть коректну дату у форматі: dd/mm/yyyy hh:mm")]
        //[Range(typeof(DateTime), "01/01/2010", "01/01/2100")]
        [DateRangeAttribute]
        [Display(Name = "Дата початку відрядження")]
        public DateTime DateOfBusinessTrip { get; set; }   // дата початку відрядження

        [Required(ErrorMessage = "Поле Дата завершення відрядження є обов'язковим")]
        [DataType(DataType.DateTime, ErrorMessage = "Введіть коректну дату у форматі: dd/mm/yyyy hh:mm")]
        //[Range(typeof(DateTime), "01/01/2010", "01/01/2100")]
        [DateRangeAttribute]
        [Display(Name = "Дата завершення відрядження")]
        public DateTime DateOfСompletionBusinessTrip { get; set; }   // дата завершення відрядження

        [MaxLength(200)]
        [Display(Name = "Маршрут поїздки (для відряджень по Україні). Наприклад: Львів-Київ-Львів - необов'язково")]
        public string RouteOfBusinessTrip { get; set; } // маршрут поїздки (для відряджень по Україні). Наприклад: Львів-Київ-Львів - необов'язково




        [Display(Name = "Транспорт, яким будете подорожувати (для відряджень по Україні) - необов'язково")]
        public string TransportOfBusinessTripOption { get; set; }   //  транспорт, яким будете подорожувати (для відряджень по Україні) - необов'язково
        public string TransportOfBusinessTripOther { get; set; }    //  транспорт, яким будете подорожувати (для відряджень по Україні) - необов'язково  ------------------------------------- other


        [Display(Name = "Оплата видатків на відрядження")]
        public string PaymentOfTravelExpensesOption { get; set; } // оплата видатків на відрядження                  
        public string PaymentOfTravelExpensesOther { get; set; } // оплата видатків на відрядження                          ------------------------------------- other

        [Display(Name = "Підстава відрядження")]
        public string BasisOfBusinessTripOption { get; set; } // підстава відрядження                               
        public string BasisOfBusinessTripOther { get; set; } // підстава відрядження                                        ------------------------------------- other


        public static explicit operator ApplicationStatement(CreateStatementViewModel statement)
        {
            var applicationStatement = new ApplicationStatement();
            applicationStatement.UserNameGenitiveCase = statement.UserNameGenitiveCase;
            applicationStatement.UserSurNameGenitiveCase = statement.UserSurNameGenitiveCase;
            applicationStatement.UserLastNameGenitiveCase = statement.UserLastNameGenitiveCase;

            applicationStatement.PositionAtTheMainPlaceOfWork = statement.PositionAtTheMainPlaceOfWork;
            applicationStatement.SubdivisionAtTheMainPlaceOfWork = statement.SubdivisionAtTheMainPlaceOfWork;

            applicationStatement.PositionPartTime = statement.PositionPartTime;
            applicationStatement.SubdivisionPartTime = statement.SubdivisionPartTime;

            applicationStatement.TypeOfBusinessTrip = statement.TypeOfBusinessTrip;


            if(statement.PurposeOfBusinessTripOption == "")
            {
                applicationStatement.PurposeOfBusinessTrip = statement.PurposeOfBusinessTripOther;
            }
            else
            {
                applicationStatement.PurposeOfBusinessTrip = statement.PurposeOfBusinessTripOption;
            }

            if (statement.BasisOfBusinessTripOption == "")
            {
                applicationStatement.BasisOfBusinessTrip = statement.BasisOfBusinessTripOther;
            }
            else
            {
                applicationStatement.BasisOfBusinessTrip = statement.BasisOfBusinessTripOption;
            }

            if (statement.PaymentOfTravelExpensesOption == "")
            {
                applicationStatement.PaymentOfTravelExpenses = statement.PaymentOfTravelExpensesOther;
            }
            else
            {
                applicationStatement.PaymentOfTravelExpenses = statement.PaymentOfTravelExpensesOption;
            }

            applicationStatement.TypeOfSalaryRetention = statement.TypeOfSalaryRetention;

            applicationStatement.StatementPlaceOfDestination = statement.StatementPlaceOfDestination;

            if(statement.TypeOfBusinessTrip == "Відрядження закордон")
            {
                applicationStatement.StatementCountryOfDestination = statement.StatementCountryOfDestination;
            }
            else
            {
                applicationStatement.StatementCountryOfDestination = "Україна";
            }

            if (statement.InstitutionWhereYouGoOption == "")
            {
                applicationStatement.InstitutionWhereYouGo = statement.InstitutionWhereYouGoOther;
            }
            else
            {
                applicationStatement.InstitutionWhereYouGo = statement.InstitutionWhereYouGoOption;
            }

            applicationStatement.DateOfBusinessTrip = statement.DateOfBusinessTrip;

            applicationStatement.DateOfСompletionBusinessTrip = statement.DateOfСompletionBusinessTrip;

            if (statement.TypeOfBusinessTrip == "Відрядження по Україні")
            {
                applicationStatement.RouteOfBusinessTrip = statement.RouteOfBusinessTrip;

                if (statement.TransportOfBusinessTripOption == "")
                {
                    applicationStatement.TransportOfBusinessTrip = statement.TransportOfBusinessTripOther;
                }
                else
                {
                    applicationStatement.TransportOfBusinessTrip = statement.TransportOfBusinessTripOption;
                }

            }

            return applicationStatement;
        }
    }
}
