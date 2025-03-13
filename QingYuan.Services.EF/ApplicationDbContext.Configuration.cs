using Microsoft.EntityFrameworkCore;
using QingYuan.Extensions;
using QingYuan.Model;

namespace QingYuan.Services.EF
{
    public partial class ApplicationDbContext
    {
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
