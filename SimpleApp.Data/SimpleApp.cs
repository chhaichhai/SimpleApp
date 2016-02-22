using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleApp.DataLayer.Model;
using TrackerEnabledDbContext.Common.Configuration;
using TrackerEnabledDbContext.Identity;

namespace SimpleApp.DataLayer
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class SimpleApp : TrackerIdentityContext<ApplicationUser>
    {
        // Your context has been configured to use a 'SimpleApp' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SimpleApp.Data.SimpleApp' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SimpleApp' 
        // connection string in the application configuration file.
        public SimpleApp()
            : base("name=SimpleApp")
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Donor> Donors { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            GlobalTrackingConfig.DisconnectedContext = true;
        }

        public static SimpleApp Create()
        {
            return new SimpleApp();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}