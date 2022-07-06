using _01_Framework.Domain;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Domain.TagAgg
{
    public class Tag:EntityBase
    {
        public string Name { get;private set; }
        public bool IsActive { get;private set; }
        
        public ICollection<Article> Articles { get; private set; }

        protected Tag()
        {
            
        }

        public Tag(string name)
        {
            Name = name;
        }


        public void Edit(string name)
        {
            Name = name;
        }

        public void Active()
        {
            IsActive = true;
        }

        public void Inactive()
        {
            IsActive = false;
        }
    }


}
