namespace NuGetGallery.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSiteProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserSiteProfiles",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropTable("UserSiteProfiles");
        }
    }
}
