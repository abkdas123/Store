namespace EF_DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CityId = c.Int(nullable: false),
                        Pincode = c.String(),
                        Phone = c.String(),
                        AltPhone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Store");
        }
    }
}
