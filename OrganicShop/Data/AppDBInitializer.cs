using OrganicShop.Models;
using System;

namespace OrganicShop.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                    new Roles()
                    {

                        RoleName = "Admin",
                        RoleDescription = "Admin"

                    },
                    new Roles()
                    {

                        RoleName = "Staff",
                        RoleDescription = "Nhan Vien"
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
