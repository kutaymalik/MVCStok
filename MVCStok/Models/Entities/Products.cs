using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCStok.Models.Entities
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string ProductImage { get; set; }
        public virtual Categories Category { get; set; }
        public int Categoryid { get; set; }
        public ICollection<SaleAct> SaleActList { get; set; }
    }
}