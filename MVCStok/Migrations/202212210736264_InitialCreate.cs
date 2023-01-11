namespace MVCStok.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30, unicode: false),
                        Password = c.String(maxLength: 30, unicode: false),
                        Authority = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        BillSerialNumber = c.String(maxLength: 1, unicode: false),
                        BillRowNumber = c.String(maxLength: 6, unicode: false),
                        TaxAdmin = c.String(maxLength: 60, unicode: false),
                        ReceiverPerson = c.String(maxLength: 30, unicode: false),
                        DeliveryPerson = c.String(maxLength: 30, unicode: false),
                        BillDate = c.DateTime(nullable: false),
                        BillHour = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BillID);
            
            CreateTable(
                "dbo.BillPens",
                c => new
                    {
                        BillPenID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bill_BillID = c.Int(),
                    })
                .PrimaryKey(t => t.BillPenID)
                .ForeignKey("dbo.Bills", t => t.Bill_BillID)
                .Index(t => t.Bill_BillID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 30, unicode: false),
                        ProductBrand = c.String(maxLength: 30, unicode: false),
                        Stock = c.Short(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        ProductImage = c.String(maxLength: 300, unicode: false),
                        Categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.Categoryid, cascadeDelete: true)
                .Index(t => t.Categoryid);
            
            CreateTable(
                "dbo.SaleActs",
                c => new
                    {
                        SalesID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductID = c.Int(nullable: false),
                        CurrentAccountID = c.Int(nullable: false),
                        PersonalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesID)
                .ForeignKey("dbo.CurrentAccounts", t => t.CurrentAccountID, cascadeDelete: true)
                .ForeignKey("dbo.Personals", t => t.PersonalID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CurrentAccountID)
                .Index(t => t.PersonalID);
            
            CreateTable(
                "dbo.CurrentAccounts",
                c => new
                    {
                        CurrentAccountID = c.Int(nullable: false, identity: true),
                        CurrentAccountName = c.String(nullable: false, maxLength: 30, unicode: false),
                        CurrentAccountLastname = c.String(nullable: false, maxLength: 30, unicode: false),
                        CurrentAccountCity = c.String(nullable: false, maxLength: 30, unicode: false),
                        CurrentAccountMail = c.String(nullable: false, maxLength: 50, unicode: false),
                        CurrentAccountPassword = c.String(maxLength: 50, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CurrentAccountID);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        PersonalID = c.Int(nullable: false, identity: true),
                        PersonalName = c.String(maxLength: 30, unicode: false),
                        PersonalLastname = c.String(maxLength: 30, unicode: false),
                        PersonalImage = c.String(maxLength: 300, unicode: false),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.PersonalID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .Index(t => t.Department_DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleActs", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SaleActs", "PersonalID", "dbo.Personals");
            DropForeignKey("dbo.Personals", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.SaleActs", "CurrentAccountID", "dbo.CurrentAccounts");
            DropForeignKey("dbo.Products", "Categoryid", "dbo.Categories");
            DropForeignKey("dbo.BillPens", "Bill_BillID", "dbo.Bills");
            DropIndex("dbo.Personals", new[] { "Department_DepartmentID" });
            DropIndex("dbo.SaleActs", new[] { "PersonalID" });
            DropIndex("dbo.SaleActs", new[] { "CurrentAccountID" });
            DropIndex("dbo.SaleActs", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "Categoryid" });
            DropIndex("dbo.BillPens", new[] { "Bill_BillID" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Departments");
            DropTable("dbo.Personals");
            DropTable("dbo.CurrentAccounts");
            DropTable("dbo.SaleActs");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.BillPens");
            DropTable("dbo.Bills");
            DropTable("dbo.Admins");
        }
    }
}
