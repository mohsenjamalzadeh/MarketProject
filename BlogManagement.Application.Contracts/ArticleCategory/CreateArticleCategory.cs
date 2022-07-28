using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required]
        public string Name { get; set; }

        [FileExtension(new string[] {".jpeg",".jpg",".png"})]
        [MaxFileSize( 3 * 1024 * 1024)]
        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string PictureAlt { get; set; }

        [Required]
        public string PictureTitle { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string KeyWords { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string MetaDescription { get; set; }

    }
}
