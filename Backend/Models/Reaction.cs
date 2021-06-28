using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Reaction
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int qId { get; set; }
        [ForeignKey("User")]
        public string userId { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }

        public User User { get; set; }
        public Questions Question { get; set; }

    }
}
