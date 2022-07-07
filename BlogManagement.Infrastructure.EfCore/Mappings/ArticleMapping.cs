using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mappings
{
    public class ArticleMapping:IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Content).IsRequired().IsRequired();
            builder.Property(p => p.Picture).HasMaxLength(1000);
            builder.Property(p => p.Slug).HasMaxLength(170).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(150).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(200).IsRequired();
            builder.Property(p => p.KeyWords).HasMaxLength(80).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(p => p.CanonicalAddress).HasMaxLength(1000).IsRequired();

            builder.HasOne(p => p.ArticleCategory)
                .WithMany(p => p.Articles)
                .HasForeignKey(p => p.ArticleCategoryId);

            builder.HasOne(p => p.Author)
                .WithMany(p => p.Articles)
                .HasForeignKey(p => p.AuthorId);


        }
    }
}
