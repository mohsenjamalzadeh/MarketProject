using BlogManagement.Domain.AuthorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mappings
{
    public class AuthorMapping:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(200).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(5000).IsRequired();

            builder.HasMany(p => p.Articles)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);


        }
    }
}
