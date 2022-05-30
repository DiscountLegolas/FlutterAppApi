using Microsoft.EntityFrameworkCore;
using Api.Ef.Models;
namespace Api.Ef
{
    public class KekemelikDbContext:DbContext
    {
        public KekemelikDbContext(DbContextOptions<KekemelikDbContext> options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>(e=>{
                e.HasOne(p=>p.User1).WithMany(x=>x.User1Messages).HasForeignKey(a=>a.User1Id).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(p=>p.User2).WithMany(x=>x.User2Messages).HasForeignKey(a=>a.User2Id).OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<User>().ToTable("Users");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users {get;set;}
        public DbSet<Therapist> Therapists {get;set;}
        public DbSet<İl> İls {get;set;}
        public DbSet<İlçe> İlçes {get;set;}
        public DbSet<Post> Posts {get;set;}
        public DbSet<UserMessage> UserMessages {get;set;}
        public DbSet<TherapistMessage> TherapistMessages {get;set;}

    }
}