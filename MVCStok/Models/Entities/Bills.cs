using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCStok.Models.Entities
{
    public class Bills
    {   
        [Key]
        public int BillID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string BillSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillRowNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdmin { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ReceiverPerson { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryPerson { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime BillHour { get; set; }
        public ICollection<BillPen> BillPenList { get; set; }
    }
}