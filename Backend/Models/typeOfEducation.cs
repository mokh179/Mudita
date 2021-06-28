using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    public class typeOfEducation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<userEducation> UserEducations { get; set; }
    }
}