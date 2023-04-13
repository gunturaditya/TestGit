using Microsoft.EntityFrameworkCore;
using WebStudy1.Models;
using WebStudy1.ModelVM;

namespace WebStudy1.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { 

        }

        public DbSet<Universities> Universities { get; set;}
        public DbSet<Educations> Educations { get; set;}
        public DbSet<Profilings> Profilings { get; set;}
        public DbSet<Employees> Employees { get; set;}
        
        public DbSet<Account> accounts { get; set;}

        public DbSet<Account_Roles> account_roles { get; set;}
        public DbSet<Roles> roles { get; set;}

        //Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relasi antara satu university dengan banyan educations
            modelBuilder.Entity<Universities>()
                        .HasMany(U => U.Educations)
                        .WithOne(e => e.Universities)
                        .HasForeignKey(e => e.Universitas_id);

            modelBuilder.Entity<Roles>()
                        .HasMany(r => r.Account_Roles)
                        .WithOne(a => a.Roles)
                        .HasForeignKey(a => a.Role_id);

            modelBuilder.Entity<Account>()
                        .HasMany(account => account.AccountRoles)
                        .WithOne(account_roles => account_roles.Account)
                        .HasForeignKey(account_roles => account_roles.Account_nik);


            modelBuilder.Entity<Account>()
                        .HasOne(a => a.Employee)
                        .WithOne(e => e.Account)
                        .HasForeignKey<Account>(a => a.Employee_nik);
          modelBuilder.Entity<Profilings>()
                    .HasOne(p => p.Educations)
                    .WithOne(e => e.Profiling)
                    .HasForeignKey<Profilings>(p => p.Education_ID);

            modelBuilder.Entity<Profilings>()
                    .HasOne(p => p.Employees)
                    .WithOne(e => e.Profiling)
                    .HasForeignKey<Profilings>(p=>p.Employee_Nik);
       /*     modelBuilder.Entity<VMLogin>()
                   .HasNoKey();*/
        }

        //Fluent API

 

        //Fluent API

    
    }
}
