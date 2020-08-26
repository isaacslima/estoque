using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Config
{
    public class BaseConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {

        /// <summary>
        /// Config Base Mapping
        /// </summary>
        /// <param name="builder">builder EntityType</param>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                 .HasKey(c => c.Id);
        }

    }
}
