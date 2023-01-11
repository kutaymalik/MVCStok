using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCStok.Models.Entities
{
    public class SaleAct
    {
        [Key]
        public int SalesID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Amount_Price { get; set; }


        public virtual Products ProductsList { get; set; }
        public int ProductID { get; set; }
        public virtual CurrentAccount CurrentAccountList { get; set; }
        public int CurrentAccountID { get; set; }
        public virtual Personal PersonalList { get; set; }
        public int PersonalID { get; set; }
    }
}