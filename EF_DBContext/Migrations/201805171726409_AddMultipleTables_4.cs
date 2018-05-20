namespace EF_DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMultipleTables_4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        DiscountedPrice = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ImagePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MstArea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MstCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StoreTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MstCity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MstStoreType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MstStoreType");
            DropTable("dbo.MstCity");
            DropTable("dbo.MstCategory");
            DropTable("dbo.MstArea");
            DropTable("dbo.Item");
        }
    }
}
