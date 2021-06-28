using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppliedVacancy
    {
        [Key]
        public int ID { get; set; }
        [Column(Order = 1)]
        [ForeignKey("Company")]
        public int Company_Id { set; get; }
        [Column(Order = 2)]
        [ForeignKey("Vacancy")]
        public int Vacancy_Id { set; get; }
        [Column(Order = 3)]
        [ForeignKey("User")]
        public string User_Id { set; get; }
        [ForeignKey("State")]
        public int status { set; get; }
        [DataType(DataType.Date)]
        public DateTime AppliedDate { set; get; }
        public bool withDraw { set; get; }
        public bool isActive { set; get; }
        public Company Company { set; get; }
        public Vacancy Vacancy { set; get; }
        public User User { set; get; }
        public Status State { set; get; }

    }
}
