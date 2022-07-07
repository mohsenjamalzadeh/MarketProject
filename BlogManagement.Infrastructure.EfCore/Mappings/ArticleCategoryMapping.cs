using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mappings
{
    public class ArticleCategoryMapping:IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Name).HasMaxLength(1000);
            builder.Property(p => p.Picture).HasMaxLength(1000);
            builder.Property(p => p.PictureAlt).HasMaxLength(150);
            builder.Property(p => p.PictureTitle).HasMaxLength(150);
            builder.Property(p => p.Slug).HasMaxLength(600);
            builder.Property(p => p.KeyWords).HasMaxLength(80);
            builder.Property(p => p.MetaDescription).HasMaxLength(150);
            builder.Property(p => p.Description).HasMaxLength(500);

            builder.HasMany(p => p.Articles)
                .WithOne(p => p.ArticleCategory)
                .HasForeignKey(p => p.ArticleCategoryId);

        }
    }
}
