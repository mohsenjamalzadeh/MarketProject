using _0_Framework.Application;
using _01_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.LogAgg;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IBlogManagementLogRepository _logRepository;

        public ArticleApplication(IArticleRepository articleRepository, IBlogManagementLogRepository logRepository)
        {
            _articleRepository = articleRepository;
            _logRepository = logRepository;
        }

        public OperationResult CreateArticle(CreateArticle command)
        {
            var operation = new OperationResult();
            if (_articleRepository.IsExist(p => p.Title == command.Title))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "CreateArticle", reason: ResultMessage.IsDuplicate, isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            var publishDate = DateTime.Parse(command.PublishDate);
            var article = new Article(command.Title, command.Content,
                command.Picture, publishDate, command.Studytime, command.Slug.Slugify(),
                command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription,
                command.CanonicalAddress, command.ArticleCategoryId, command.AuthorId,
                command.ShortDescription);

            _articleRepository.Create(article);
            _articleRepository.SaveChange();

            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: $"Create_Article", reason: ResultMessage.IsSuccess + $"CreateArticle with name{command.Title}", isSuccess: true));
            return operation.Success();
        }

        public OperationResult EditArticle(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.Get(command.Id);
            if (article == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Edit_Article", reason: ResultMessage.EntityNotFound, isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            if (_articleRepository.IsExist(p => p.Title == command.Title && p.Id != command.Id))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: $"Edit_Article {command.Title}", reason: ResultMessage.IsDuplicate, isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            var publishDate = DateTime.Parse(command.PublishDate);
            article.Edit(command.Title, command.Content,
                command.Picture, publishDate, command.Studytime, command.Slug.Slugify(),
                command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription,
                command.CanonicalAddress, command.ArticleCategoryId, command.AuthorId,
                command.ShortDescription);

            _articleRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: $"Edit_Article ", reason: ResultMessage.IsSuccess + $"{command.Title}_Edited", isSuccess: true));
            return operation.Success();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> GetAll(ArticleSearchModel searchModel)
        {
            return _articleRepository.GetAll(searchModel);
        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var article = _articleRepository.Get(id);
            if (article == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Activate_teArticle", reason: ResultMessage.EntityNotFound, isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            article.Active();
            _articleRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: $"Activate_Article", reason: ResultMessage.IsSuccess + $"Activate {article.Title} Article", isSuccess: true));
            return operation.Success();
        }

        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var article = _articleRepository.Get(id);
            if (article == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "InActivate Article", reason: ResultMessage.EntityNotFound, isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            article.InActive();
            _articleRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: $"InActivate _ Article", reason: ResultMessage.IsSuccess + $"InActivate {article.Title} Article", isSuccess: true));
            return operation.Success();
        }

        public void AddNumView(long id)
        {
            var article = _articleRepository.Get(id);
            if (article == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "NotExist Article ", reason: ResultMessage.EntityNotFound, isSuccess: false));
            }
            article.AddView();
            _articleRepository.SaveChange();

        }

        public void AddNumVote(long id)
        {
            var article = _articleRepository.Get(id);
            if (article == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "NotExist Article ", reason: ResultMessage.EntityNotFound, isSuccess: false));
            }
            article.Add();
            _articleRepository.SaveChange();

        }
    }
}
