using _0_Framework.Application;
using _01_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Domain.LogAgg;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IBlogManagementLogRepository _logRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IBlogManagementLogRepository logRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _logRepository = logRepository;
        }

        public OperationResult CreateArticleCategory(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.IsExist(p => p.Name == command.Name))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"CreateArticleCategory",reason:ResultMessage.IsDuplicate+$"_ for Name{command.Name}",isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            var articleCategory = new ArticleCategory(command.Name, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Slug.Slugify(),
                command.KeyWords, command.Description, command.MetaDescription);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChange();
            
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"CreateArticleCategory",reason:ResultMessage.IsSuccess+$"_ for Name{command.Name}",isSuccess:true));
            return operation.Success();

        }

        public OperationResult EditArticleCategory(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            if (articleCategory == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit ArticleCategory",reason:ResultMessage.EntityNotFound,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            if (_articleCategoryRepository.IsExist(p => (p.Name == command.Name && p.Id != command.Id)))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit ArticleCategory",reason:ResultMessage.IsDuplicate,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }
            articleCategory.Edit(command.Name,command.Picture,
                command.PictureAlt,command.PictureTitle,command.Slug.Slugify(),
                command.KeyWords,command.Description,command.MetaDescription);

            _articleCategoryRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit ArticleCategory",reason:ResultMessage.IsSuccess+$"_{command.Name} Edited",isSuccess:true));
            return operation.Success();

        }

        public List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.GetAll(searchModel);
        }

        public EditArticleCategory? GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);

        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(id);
            if (articleCategory == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Activate_ArticleCategory",reason:ResultMessage.EntityNotFound,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            articleCategory.Active();
            _articleCategoryRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:$"Activate_ArticleCategory",reason:ResultMessage.IsSuccess+$"_Activate_{articleCategory.Name}",isSuccess:true));
            return operation.Success();
        }

        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(id);
            if (articleCategory == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"InActivate ArticleCategory",reason:ResultMessage.EntityNotFound,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            articleCategory.InActive();
            _articleCategoryRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:$"InActivate_ArticleCategory",reason:ResultMessage.IsSuccess+$"_{articleCategory.Name} InActivate",isSuccess:true));
            return operation.Success();
        }
    }
}
