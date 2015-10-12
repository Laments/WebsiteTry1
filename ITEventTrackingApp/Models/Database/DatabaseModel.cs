using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

//10.11.15 - changed namespace from ITDatabase to DatabaseModel, updated namespace to be correct
namespace ITEventTrackingApp.Models.DatabaseModel
{

    public class DatabaseTables : DbContext
    {

        // how to name base: http://stackoverflow.com/questions/11132003/how-to-create-a-valid-connection-string-for-entity-framework-the-underlying-pr
        public DatabaseTables()
                : base("name=DefaultConnection")
        {
        }

        // why using get/set here: http://stackoverflow.com/questions/4270794/why-is-my-dbcontext-dbset-null
        public DbSet<User> Users { get; set; }
        public DbSet<Checkin> Checkins { get; set; }
        public DbSet<Event> Events { get; set; }
    }

    // notes on EF Data annotations: https://msdn.microsoft.com/en-us/data/jj591583.aspx

    public class User
    {
        //InverseProperty from http://stackoverflow.com/questions/5716528/entity-framework-4-1-inverseproperty-attribute
        [Key, InverseProperty("FK_UserId")]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class Checkin
    {
        [Key, Column(Order = 0)]
        public int FK_UserId { get; set; }
        [Key, Column(Order = 1)]
        public int FK_EventId { get; set; }
        public bool? UserCheckedIn { get; set; }
        public bool? UserSawUpdatedEvent { get; set; }
    }


    public class Event
    {
        [Key, InverseProperty("FK_EventId")]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime? DateTime { get; set; }
        public bool? IsUpdated { get; set; }
    }
}



