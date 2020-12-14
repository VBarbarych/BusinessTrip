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
        public string UserNameGenitiveCase { get; set; }   //genitive case - родовий відмінок
        //[Required]
        [MaxLength(100)]
        public string UserSurNameGenitiveCase { get; set; }   //genitive case - родовий відмінок
        //[Required]
        [MaxLength(100)]
        public string UserLastNameGenitiveCase { get; set; }   //genitive case - родовий відмінок

        //[Required]
        [MaxLength(200)]
        public string SubdivisionAtTheMainPlaceOfWork { get; set; } // підрозділ  за основним місцем праці

        //[Required]
        [MaxLength(100)]
        public string PositionAtTheMainPlaceOfWork { get; set; } // підрозділ  за основним місцем праці


        [MaxLength(200)]
        public string SubdivisionPartTime { get; set; } // підрозділ та посаду за за сумісництвом (за наявності) - необов'язково
        [MaxLength(100)]
        public string PositionPartTime { get; set; } // підрозділ та посаду за за сумісництвом (за наявності) - необов'язково





        //[Required]
        [MaxLength(50)]
        public string TypeOfBusinessTrip { get; set; } // тип відрядження 

        [MaxLength(250)]
        public string PurposeOfBusinessTrip { get; set; }     // мета відрядження                                         ------------------------------------- other

        //[Required]
        [MaxLength(200)]
        public string TypeOfSalaryRetention { get; set; } // вид збереження заробітної плати


        //[Required]
        [MaxLength(200)]
        public string StatementPlaceOfDestination { get; set; }  // місто відрядження

        [MaxLength(200)]
        public string StatementCountryOfDestination { get; set; }  // країна відрядження  (для закордонного відрядження) - необов'язково

        //[Required]
        [MaxLength(300)]
        public string InstitutionWhereYouGo { get; set; }       // установа, куди відряджаєтесь

        //[Required]
        [DataType(DataType.DateTime, ErrorMessage = "Введіть коректну дату у форматі: dd/mm/yyyy hh:mm")]
        [Range(typeof(DateTime), "1/1/2010", "1/1/2100")]
        public DateTime DateOfBusinessTrip { get; set; }   // дата початку відрядження

        //[Required]
        [DataType(DataType.DateTime, ErrorMessage = "Введіть коректну дату у форматі: dd/mm/yyyy hh:mm")]
        [Range(typeof(DateTime), "1/1/2010", "1/1/2100")]
        public DateTime DateOfСompletionBusinessTrip { get; set; }   // дата завершення відрядження

        [MaxLength(200)]
        public string RouteOfBusinessTrip { get; set; } // маршрут поїздки (для відряджень по Україні). Наприклад: Львів-Київ-Львів - необов'язково

        [MaxLength(200)]
        public string TransportOfBusinessTrip { get; set; }   //  транспорт, яким будете подорожувати (для відряджень по Україні) - необов'язково  ------------------------------------- other

        //[Required]
        [MaxLength(200)]
        public string PaymentOfTravelExpenses { get; set; } // оплата видатків на відрядження                          ------------------------------------- other

        //[Required]
        [MaxLength(200)]
        public string BasisOfBusinessTrip { get; set; } // підстава відрядження                                        ------------------------------------- other

        public virtual ICollection<ApplicationUserStatement> UserStatements { get; set; }
        public virtual ICollection<ApplicationStatementFile> StatementFiles { get; set; }
        public virtual ICollection<ApplicationCurrentStatus> CurrentStatuses { get; set; }
        public virtual ICollection<ApplicationHistoryOfStatus> HistoryOfStatuses { get; set; }
    }
}
