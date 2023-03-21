namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FolowerId = c.String(nullable: false, maxLength: 128),
                        FolwerId = c.String(),
                        Folower_Id = c.String(maxLength: 128),
                        Folowee_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FolowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.Folower_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Folowee_Id)
                .Index(t => t.Folower_Id)
                .Index(t => t.Folowee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "Folowee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "Folower_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Folowee_Id" });
            DropIndex("dbo.Followings", new[] { "Folower_Id" });
            DropTable("dbo.Followings");
        }
    }
}
