using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QingYuan.Extensions;
using QingYuan.Model;
using QingYuan.Model.Base;

namespace QingYuan.Services.EF
{
    public partial class ApplicationDbContext
    {
        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override EntityEntry Remove(object entity)
        {
            if (entity is BaseSoftDelete e)
            {
                e.IsDeleted = true;
                e.UpdateTime = DateTimeOffset.Now;
                return base.Update(e);
            }
            return base.Remove(entity);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is IUpdateTime && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((IUpdateTime) entry.Entity).UpdateTime = DateTimeOffset.Now;

                if (entry.State == EntityState.Added)
                {
                    ((ICreateTime) entry.Entity).CreateTime = DateTimeOffset.Now;
                }
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Convert table names to snake_case
                entity.SetTableName(entity.GetTableName()!.ToSnakeCaseLower());

                // Convert column names to snake_case
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name!.ToSnakeCaseLower());
                    if (property.Name == nameof(ICreateTime.CreateTime))
                    {
                        property.SetDefaultValueSql("SYSDATETIMEOFFSET()");
                    }
                }

                // Convert key names to snake_case
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName()!.ToSnakeCaseLower());
                }

                // Convert foreign key names to snake_case
                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(key.GetConstraintName()!.ToSnakeCaseLower());
                }

                // Convert index names to snake_case
                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName()!.ToSnakeCaseLower());
                }

            }
        }
    }
}
