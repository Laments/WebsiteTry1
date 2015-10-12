using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.SqlServer;
using ITEventTrackingApp.Models.DatabaseModel;
using System.Data.Entity.Migrations;

namespace ITEventTrackingApp.Models.DatabaseModel
{
    public class Seeder
    {
        internal static void SeedDatabase(DatabaseTables dbContext)
        {
            using (dbContext) {
                var users = new List<User>
                    {
                        new User{Id=0,Username="clee0",FullName="Cynthia Lee",Email="clee0@ameblo.jp"},
                        new User{Id=1,Username="wdunn1",FullName="Walter Dunn",Email="wdunn1@jiathis.com"},
                        new User{Id=2,Username="wfisher2",FullName="Walter Fisher",Email="wfisher2@chicagotribune.com"},
                        new User{Id=3,Username="tlong3",FullName="Terry Long",Email="tlong3@samsung.com"},
                        new User{Id=4,Username="moliver4",FullName="Mark Oliver",Email="moliver4@redcross.org"},
                        new User{Id=5,Username="pparker5",FullName="Patrick Parker",Email="pparker5@eventbrite.com"},
                        new User{Id=6,Username="mpatterson6",FullName="Marie Patterson",Email="mpatterson6@drupal.org"},
                        new User{Id=7,Username="pramirez7",FullName="Philip Ramirez",Email="pramirez7@nytimes.com"},
                        new User{Id=8,Username="rhowell8",FullName="Ralph Howell",Email="rhowell8@ovh.net"},
                        new User{Id=9,Username="sfisher9",FullName="Scott Fisher",Email="sfisher9@1688.com"},
                    };
                users.ForEach(s => dbContext.Users.Add(s));
                dbContext.SaveChanges();

                var events = new List<Event>
                    {
                        new Event{Id=0,EventName="Massages",Location="15965 NE 85th St #102, Redmond, WA 98052",DateTime=new DateTime(2015, 9, 25, 12, 32, 30),IsUpdated=false},
                        new Event{Id=1,EventName="Go Karts",Location="2207 NE Bel-Red Rd., Redmond, WA 98052",IsUpdated=true},
                        new Event{Id=2,EventName="Go Karts",DateTime=new DateTime(2015, 9, 30, 10, 12, 05),IsUpdated=false}
                   };
                events.ForEach(s => dbContext.Events.Add(s));
                dbContext.SaveChanges();

                var checkins = new List<Checkin>
                    {
                    new Checkin{FK_UserId=1,FK_EventId=0,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=1,FK_EventId=1,UserCheckedIn=true,UserSawUpdatedEvent=true},
                    new Checkin{FK_UserId=1,FK_EventId=2,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=2,FK_EventId=0,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=2,FK_EventId=1,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=2,FK_EventId=2,UserCheckedIn=false,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=3,FK_EventId=1,UserCheckedIn=true,UserSawUpdatedEvent=true},
                    new Checkin{FK_UserId=4,FK_EventId=1,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=4,FK_EventId=0,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=5,FK_EventId=1,UserCheckedIn=true,UserSawUpdatedEvent=true},
                    new Checkin{FK_UserId=6,FK_EventId=0,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    new Checkin{FK_UserId=7,FK_EventId=2,UserCheckedIn=true,UserSawUpdatedEvent=false},
                    };

                checkins.ForEach(s => dbContext.Checkins.Add(s));
                dbContext.SaveChanges();
            }
        }
    }
}

