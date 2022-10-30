using Microsoft.EntityFrameworkCore;
using FileDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(u => u.HasOne(x => x.GroupPermission)
            .WithMany(x => x.users)
            .HasForeignKey(x => x.GroupId)
            //.HasConstraintName("FK_GroupPermission_User_id")
            );

            modelBuilder.Entity<UserModel>(a => a.HasOne(n => n.Role)
           .WithMany(x => x.users)
           .HasForeignKey(v => v.RoleId));

            modelBuilder.Entity<DocumentList>(a => a.HasOne(n => n.User)
           .WithMany(x => x.documentLists)
           .HasForeignKey(v => v.UserId));
        }
        public DbSet<UserModel> users { get; set; }
        public DbSet<CargoManifest> cargoManifests { get; set; }
        public DbSet<DocumentList> documentLists { get; set; }
        public DbSet<RoleModel> roles { get; set; }
        public DbSet<GroupPermission> groupPermissions { get; set; }

    }
}

