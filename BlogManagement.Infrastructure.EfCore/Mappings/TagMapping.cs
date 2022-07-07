using BlogManagement.Domain.TagAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mappings
{
    public class TagMapping:IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();


            builder.HasMany(p => p.Articles)
                .WithMany(p => p.Tags);
        }
    }
}
