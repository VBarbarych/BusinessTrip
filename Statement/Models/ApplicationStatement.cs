using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrip.Models
{
    [Table("AspStatement")]
    public class ApplicationStatement
    {

        public ApplicationStatement()
        {
            UserStatements = new HashSet<ApplicationUserStatement>();
            StatementFiles = new HashSet<ApplicationStatementFile>();
            CurrentStatuses = new HashSet<ApplicationCurrentStatus>();
            HistoryOfStatuses = new HashSet<ApplicationHistoryOfStatus>();
        }
        [Key]
        [Required]
        public int StatementId { get; set; }     // ключ

        //[Required]
        [MaxLength(100)]
        [Display(Name = "Ім'я (у Р. в.)")]
        public string UserNameGenitiveCase { get; set; }   //genitive case - родовий відмінок
        //[Required]
        [MaxLength(100)]
        [Display(Name = "Прізвище (у Р. в.)")]
        public string UserSurNameGenitiveCase { get; set; }   //genitive case - родовий відмінок
        //[Required]
        [MaxLength(100)]
        [Display(Name = "По батькові (у Р. в.)")]
        public string UserLastNameGenitiveCase { get; set; }   //genitive case - родовий відмінок

        //[Required]
        [MaxLength(200)]
        [Display(Name = "Підрозділ за основним місцем праці")]
        public string SubdivisionAtTheMainPlaceOfWork { get; set; } // підрозділ  за основним місцем праці

        //[Required]
        [MaxLength(100)]
        [Display(Name = "Посада за основним місцем праці")]
        public string PositionAtTheMainPlaceOfWork { get; set; } // підрозділ  за основним місцем праці


        [MaxLength(200)]
        [Display(Name = "Підрозділ за сумісництвом")]
        public string SubdivisionPartTime { get; set; } // підрозділ та посаду за за сумісництвом (за наявності) - необов'язково
        [MaxLength(100)]
        [Display(Name = "Посада за сумісництвом")]
        public string PositionPartTime { get; set; } // підрозділ та посаду за за сумісництвом (за наявності) - необов'язково




        //[Required]
        [MaxLength(50)]
        [Display(Name = "Тип відрядження")]
        public string TypeOfBusinessTrip { get; set; } // тип відрядження 

        [MaxLength(250)]
        [Display(Name = "Мета відрядження")]
        public string PurposeOfBusinessTrip { get; set; }     // мета відрядження                                         ------------------------------------- other

        //[Required]
        [MaxLength(200)]
        [Display(Name = "Вид збереження заробітної плати")]
        public string TypeOfSalaryRetention { get; set; } // вид збереження заробітної плати


        //[Required]
        [MaxLength(200)]
        [Display(Name = "Місто відрядження")]
        public string StatementPlaceOfDestination { get; set; }  // місто відрядження

        [MaxLength(200)]
        [Display(Name = "Країна відрядження")]
        public string StatementCountryOfDestination { get; set; }  // країна відрядження  (для закордонного відрядження) - необов'язково

        //[Required]
        [MaxLength(300)]
        [Display(Name = "Установа, куди відряджаєтесь")]
        public string InstitutionWhereYouGo { get; set; }       // установа, куди відряджаєтесь

        //[Required]
        [DataType(DataType.DateTime, ErrorMessage = "Введіть коректну дату у форматі: dd/mm/yyyy hh:mm")]
        [Range(typeof(DateTime), "1/1/2010", "1/1/2100")]
        [Display(Name = "Початок відрядження")]
        public DateTime DateOfBusinessTrip { get; set; }   // дата початку відрядження

        //[Required]
        [DataType(DataType.DateTime, ErrorMessage = "Введіть коректну дату у форматі: dd/mm/yyyy hh:mm")]
        [Range(typeof(DateTime), "1/1/2010", "1/1/2100")]
        [Display(Name = "Завершення відрядження")]
        public DateTime DateOfСompletionBusinessTrip { get; set; }   // дата завершення відрядження

        [MaxLength(200)]
        [Display(Name = "Маршрут поїздки")]
        public string RouteOfBusinessTrip { get; set; } // маршрут поїздки (для відряджень по Україні). Наприклад: Львів-Київ-Львів - необов'язково

        [MaxLength(200)]
        [Display(Name = "Транспорт, яким будете подорожувати")]
        public string TransportOfBusinessTrip { get; set; }   //  транспорт, яким будете подорожувати (для відряджень по Україні) - необов'язково  ------------------------------------- other

        //[Required]
        [MaxLength(200)]
        [Display(Name = "Оплата видатків на відрядження")]
        public string PaymentOfTravelExpenses { get; set; } // оплата видатків на відрядження                          ------------------------------------- other

        //[Required]
        [MaxLength(200)]
        [Display(Name = "Підстава відрядження")]
        public string BasisOfBusinessTrip { get; set; } // підстава відрядження                                        ------------------------------------- other

        public byte[] FileData { get; set; }

        public virtual ICollection<ApplicationUserStatement> UserStatements { get; set; }
        public virtual ICollection<ApplicationStatementFile> StatementFiles { get; set; }
        public virtual ICollection<ApplicationCurrentStatus> CurrentStatuses { get; set; }
        public virtual ICollection<ApplicationHistoryOfStatus> HistoryOfStatuses { get; set; }
    }
}
