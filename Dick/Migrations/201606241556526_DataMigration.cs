using System.Data.Entity.Migrations;

namespace Dick.Migrations
{
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clothes",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    Width = c.Double(false),
                    Length = c.Double(false),
                    Code = c.String(),
                    Price = c.Decimal(false, 18, 2),
                    Image = c.Binary(),
                    ImageType = c.String(),
                    ClothingPattern_Id = c.Int()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClothingPatterns", t => t.ClothingPattern_Id)
                .Index(t => t.ClothingPattern_Id);

            CreateTable(
                "dbo.ClothingPatterns",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    Code = c.String(),
                    Price = c.Decimal(false, 18, 2),
                    Image = c.Binary(),
                    ImageType = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Cutters",
                c => new
                {
                    Id = c.Int(false, true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    MiddleName = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(false, true),
                    BeginDate = c.DateTime(false),
                    EndDate = c.DateTime(false),
                    FittingDate = c.DateTime(false),
                    ClientId = c.Int(false),
                    CutterId = c.Int(false),
                    IsDone = c.Boolean(false),
                    ClothId = c.Int(false),
                    ClothingPatternId = c.Int(false),
                    Users_Id = c.String(maxLength: 128)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clothes", t => t.ClothId, true)
                .ForeignKey("dbo.ClothingPatterns", t => t.ClothingPatternId, true)
                .ForeignKey("dbo.Cutters", t => t.CutterId, true)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.CutterId)
                .Index(t => t.ClothId)
                .Index(t => t.ClothingPatternId)
                .Index(t => t.Users_Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(false, 128),
                    FirstName = c.String(),
                    LastName = c.String(),
                    MiddleName = c.String(),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(false),
                    TwoFactorEnabled = c.Boolean(false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(false),
                    AccessFailedCount = c.Int(false),
                    UserName = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(false, true),
                    UserId = c.String(false, 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(false, 128),
                    ProviderKey = c.String(false, 128),
                    UserId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.LoginProvider, t.ProviderKey, t.UserId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(false, 128),
                    RoleId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(false, 128),
                    Name = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "CutterId", "dbo.Cutters");
            DropForeignKey("dbo.Orders", "ClothingPatternId", "dbo.ClothingPatterns");
            DropForeignKey("dbo.Orders", "ClothId", "dbo.Clothes");
            DropForeignKey("dbo.Clothes", "ClothingPattern_Id", "dbo.ClothingPatterns");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] {"RoleId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"UserId"});
            DropIndex("dbo.AspNetUserLogins", new[] {"UserId"});
            DropIndex("dbo.AspNetUserClaims", new[] {"UserId"});
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] {"Users_Id"});
            DropIndex("dbo.Orders", new[] {"ClothingPatternId"});
            DropIndex("dbo.Orders", new[] {"ClothId"});
            DropIndex("dbo.Orders", new[] {"CutterId"});
            DropIndex("dbo.Clothes", new[] {"ClothingPattern_Id"});
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.Cutters");
            DropTable("dbo.ClothingPatterns");
            DropTable("dbo.Clothes");
        }
    }
}