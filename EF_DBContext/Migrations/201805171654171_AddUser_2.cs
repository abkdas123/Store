namespace EF_DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MstUser",
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
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MstUser");
        }
    }
}
