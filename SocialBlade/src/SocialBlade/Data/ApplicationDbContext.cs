using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialBlade.Models;

namespace SocialBlade.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRelation>()
                .HasOne(x => x.Followee)
                .WithMany(x => x.RelationB)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserRelation>()
                .HasOne(x => x.Follower)
                .WithMany(x => x.RelationA)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
