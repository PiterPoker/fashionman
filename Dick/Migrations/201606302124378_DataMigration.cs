namespace Dick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Users_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "Users_Id" });
            RenameColumn(table: "dbo.Orders", name: "Users_Id", newName: "UserId");
            AlterColumn("dbo.Orders", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "Users_Id");
            CreateIndex("dbo.Orders", "Users_Id");
            AddForeignKey("dbo.Orders", "Users_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
