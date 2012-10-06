namespace NuGetGallery.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SiteProfileImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("UserSiteProfiles", "Image", c => c.String(maxLength: 400));
            AlterColumn("UserSiteProfiles", "Name", c => c.String(maxLength: 255));
            AlterColumn("UserSiteProfiles", "Url", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("UserSiteProfiles", "Url", c => c.String());
            AlterColumn("UserSiteProfiles", "Name", c => c.String());
            DropColumn("UserSiteProfiles", "Image");
        }
    }
}
