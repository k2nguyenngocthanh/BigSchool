namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledColumnToCourse : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "Folower_Id", newName: "Follower_Id");
            RenameColumn(table: "dbo.Followings", name: "Folowee_Id", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Folowee_Id", newName: "IX_FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Folower_Id", newName: "IX_Follower_Id");
            DropPrimaryKey("dbo.Followings");
            AddColumn("dbo.Attendances", "LecturerId", c => c.String());
            AddColumn("dbo.Attendances", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Followings", "FollowerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Courses", "IsCanceled", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.Followings", "FollowerId");
            DropColumn("dbo.Followings", "FolowerId");
            DropColumn("dbo.Followings", "FolwerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "FolwerId", c => c.String());
            AddColumn("dbo.Followings", "FolowerId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Followings");
            DropColumn("dbo.Courses", "IsCanceled");
            DropColumn("dbo.Followings", "FollowerId");
            DropColumn("dbo.Attendances", "DateTime");
            DropColumn("dbo.Attendances", "LecturerId");
            AddPrimaryKey("dbo.Followings", "FolowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_Follower_Id", newName: "IX_Folower_Id");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_Folowee_Id");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "Folowee_Id");
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "Folower_Id");
        }
    }
}
