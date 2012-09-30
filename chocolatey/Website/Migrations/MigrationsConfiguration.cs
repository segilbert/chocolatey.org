using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace NuGetGallery.Migrations
{
    public class MigrationsConfiguration : DbMigrationsConfiguration<EntitiesContext>
    {
        private const string GalleryOwnerEmail = "chocolatey@chocolatey.org";
        private const string GalleryOwnerName = "Chocolatey Gallery";

        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntitiesContext context)
        {
            var roles = context.Set<Role>();
            if (!roles.Any(x => x.Name == Constants.AdminRoleName))
            {
                roles.Add(new Role() { Name = Constants.AdminRoleName });
                context.SaveChanges();
            }

            var gallerySettings = context.Set<GallerySetting>();
            if (!gallerySettings.Any())
            {
                gallerySettings.Add(new GallerySetting
                {
                    SmtpHost = "localhost",
                    SmtpPort = 25,
                    GalleryOwnerEmail = GalleryOwnerEmail,
                    GalleryOwnerName = GalleryOwnerName,
                    ConfirmEmailAddresses = false
                });
                context.SaveChanges();
            }
            else
            {
                var gallerySetting = gallerySettings.First();
                if (String.IsNullOrEmpty(gallerySetting.GalleryOwnerEmail))
                {
                    gallerySetting.GalleryOwnerEmail = GalleryOwnerEmail;
                }
                if (String.IsNullOrEmpty(gallerySetting.GalleryOwnerName))
                {
                    gallerySetting.GalleryOwnerName = GalleryOwnerName;
                }
                context.SaveChanges();
            }
        }
    }
}
