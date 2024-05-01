using HR.Data.Abstractions;
using HR.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharedKernel.Abstractions;
using SharedKernel;
using System.Reflection;
using SharedKernel.Models;
using SharedKernel.Constants;

namespace HR.Data
{
    public class HumanResourcesContext : DbContext
    {
        private IAppSettings _appSettings;

        public HumanResourcesContext(IAppSettings appSettings, DbContextOptions<HumanResourcesContext> options) : base(options) 
        {
            _appSettings = appSettings;
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<UserJobPosition> UserJobPositions { get; set; }
        public DbSet<UserLeave> UserLeaves { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdvancePayment> AdvancePayments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<UserPersonelInformation> UserPersonelInformations { get; set; }
        public DbSet<UserOtherInformation> UserOtherInformations { get; set; }
        public DbSet<DepartmentManager> DepartmentManagers { get; set; }
        public DbSet<UserSalary> UserSalaries { get; set; }
        public DbSet<LeaveSetting> LeaveSettings { get; set; }
        public DbSet<PossessionCategory> PossessionCategories { get; set; }
        public DbSet<UserPossession> Possessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CheckForSoftDelete();
            FillAudits();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void FillAudits()
        {
            this.ChangeTracker.DetectChanges();

            foreach (var entry in this.ChangeTracker.Entries<AuditableBaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedUserId = _appSettings.CurrentUser != null ? _appSettings.CurrentUser.Id : SystemConstants.SystemUserId;
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.IsDeleted = false;

                }
                else if (entry.State == EntityState.Modified && _appSettings.IsExists)
                {
                    entry.Entity.UpdatedUserId = _appSettings.CurrentUser != null ? _appSettings.CurrentUser.Id : SystemConstants.SystemUserId;
                    entry.Entity.UpdatedDate = DateTime.Now;
                }
            }
        }

        private void CheckForSoftDelete()
        {
            var deletedEntities = this.ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var item in deletedEntities)
            {
                if (item.Entity is AuditableBaseEntity entity)
                {
                    item.State = EntityState.Modified;
                    entity.IsDeleted = true;
                }
                else if (item.Entity is BaseEntity baseEntity)
                {
                    item.State = EntityState.Modified;
                    baseEntity.IsDeleted = true;
                }
            }
        }
    }
}