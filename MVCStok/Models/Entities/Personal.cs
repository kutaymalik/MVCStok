using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCStok.Models.Entities
{
    public class Personal
    {
        [Key]
        public int PersonalID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonalName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonalLastname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string PersonalImage { get; set; }

        public ICollection<SaleAct> SaleActList { get; set; }

        public Department Department { get; set; }
    }
}