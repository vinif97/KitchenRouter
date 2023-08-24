using KitchenRouter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenRouter.Infrastructure.Configurations
{
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public virtual void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.RowVersion)
                .IsRowVersion();
            builder.HasQueryFilter(entity => !entity.IsDeleted);
            builder.Ignore(entity => entity.Valid);
            builder.Ignore(entity => entity.Invalid);
            builder.Ignore(entity => entity.ValidationResult);
        }
    }
}
