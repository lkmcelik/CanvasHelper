using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CanvasHelperServerApp.Models
{
    public partial class CanvasDbContext : DbContext
    {
        public CanvasDbContext(DbContextOptions<CanvasDbContext> options)
            : base(options) {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentsType> AssignmentsTypes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Criterion> Criteria { get; set; }
        public virtual DbSet<FavoriteFeedback> FavoriteFeedbacks { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesPermissionsAssignment> RolesPermissionsAssignments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersCriteriaFeedback> UsersCriteriaFeedbacks { get; set; }
        public virtual DbSet<UsersFavoriteFeedback> UsersFavoriteFeedbacks { get; set; }
        public virtual DbSet<UsersRole> UsersRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(s => s.UserType)
                .HasConversion(v => v.ToString(),
                                v => (UserType)Enum.Parse(typeof(UserType), v));
        }
        public override int SaveChanges() {
            var r = base.SaveChanges();
            var entires = this.ChangeTracker.Entries();

            foreach (var item in entires) {
                this.Entry(item).State = EntityState.Detached;
            }

            return r;
        }
    }
}
