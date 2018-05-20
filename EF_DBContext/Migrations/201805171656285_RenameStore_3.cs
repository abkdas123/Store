namespace EF_DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameStore_3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Store", newName: "MstStore");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MstStore", newName: "Store");
        }
    }
}
