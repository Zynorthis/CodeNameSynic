using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using CodeNameSynic.Models;

[assembly: OwinStartupAttribute(typeof(CodeNameSynic.Startup))]
namespace CodeNameSynic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }
        private void CreateRoles()
        {
            ApplicationDbContext database = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(database));

            if (!roleManager.RoleExists("Regular"))
            {
                var role = new IdentityRole();
                role.Name = "Regular";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                roleManager.Create(role);
            }
        }
    }
}
