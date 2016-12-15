using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialBlade.Models;
using SocialBlade.Models.PostViewModels;

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
        public DbSet<User_Dislike> UserDislikes { get; set; }
        public DbSet<User_Group> UserGroups { get; set; }
        public DbSet<User_Like> UserLikes { get; set; }
        public DbSet<UserRelation> UserRelations { get; set; }



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

            builder.Entity<Comment>()
                .HasOne<Post>(x => x.Post)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .Property(x => x.DateCreated)
                .HasDefaultValueSql("getdate()");

            builder.Entity<Post>()
                .Property(x => x.DateModified)
                .HasDefaultValueSql("getdate()");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
