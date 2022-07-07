using BlogManagement.Domain.LogAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EfCore.Mappings
{
    public class LogBlogManagementMapping:IEntityTypeConfiguration<LogBlogManagement>
    {
        public void Configure(EntityTypeBuilder<LogBlogManagement> builder)
        {
            builder.ToTable("LogsBlogManagement");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.MakerOperation).HasMaxLength(300).IsRequired();
            builder.Property(p => p.PlaceOperation).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Reason).HasMaxLength(1000).IsRequired();

        }
    }
}
