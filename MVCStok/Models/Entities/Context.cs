using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCStok.Models.Entities
{
    public class Context: DbContext
    {
        public DbSet<Admin> AdminList { get; set; }
        public DbSet<CurrentAccount> CurrentAccountList { get; set; }
        public DbSet<Department> DepartmentList { get; set; }
        public DbSet<BillPen> BillPenList { get; set; }
        public DbSet<Bills> BillList { get; set; }
        public DbSet<Expense> ExpenseList { get; set; }
        public DbSet<Categories> CategoriesList { get; set; }
        public DbSet<SaleAct> SaleActList { get; set; }
        public DbSet<Products> ProductsList { get; set; }
    }
}