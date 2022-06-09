using MakeWeBet.Data.Models.Entity;
using MakeWeBet.Data.Models.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Data.Models.Context
{
    public class MakeWeBetContext : IdentityDbContext<ApplicationUser>
    {
        public MakeWeBetContext(DbContextOptions<MakeWeBetContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(f => f.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelbuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    IEnumerable<IMutableForeignKey> foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        //    foreach (IMutableForeignKey fkRelationship in foreignKeys)
        //    {
        //        fkRelationship.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
        //}

        public DbSet<User> USER { get; set; }
        public DbSet<Bet> BET { get; set; }
        public DbSet<BetCategory> BET_CATEGORY { get; set; }
        public DbSet<Country> COUNTRY { get; set; }
        public DbSet<Currency> CURRENCY { get; set; }
        public DbSet<UserBet> USER_BET { get; set; }
        public DbSet<UserBetCategorySuggestion> USER_BET_CATEGORY_SUGGESTION { get; set; }
        public DbSet<UserFollowership> USER_FOLLOWERSHIP { get; set; }

    }
}
