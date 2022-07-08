using _01_Framework.Application;
using BlogManagement.Application.Contracts.Author;
using BlogManagement.Domain.AuthorAgg;
using BlogManagement.Domain.LogAgg;

namespace BlogManagement.Application
{
    public class AuthorApplication:IAuthorApplication
    {
        private readonly IBlogManagementLogRepository _logRepository;
        private readonly IAuthorRepository _authorRepository;

        public AuthorApplication(IBlogManagementLogRepository logRepository, IAuthorRepository authorRepository)
        {
            _logRepository = logRepository;
            _authorRepository = authorRepository;
        }


        public OperationResult DefineAuthor(DefinitionAuthor command)
        {
            var operation = new OperationResult();
            if ( _authorRepository.IsExist(p => p.Name == command.Name))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Define Author",reason:ResultMessage.IsDuplicate,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            var author = new Author(command.Name,command.Picture,command.PictureAlt,command.PictureTitle,command.Description);

            _authorRepository.Create(author);
            _authorRepository.SaveChange();
            
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Define Author",reason:ResultMessage.IsSuccess+$"_ {command.Name} Added in Authors ",isSuccess:true));
            return operation.Success();
        }

        public OperationResult EditAuthor(EditAuthor command)
        {
            var operation = new OperationResult();
            var author = _authorRepository.Get(command.Id);
            if (author == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit Author",reason:ResultMessage.EntityNotFound,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            if (_authorRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit Author",reason:ResultMessage.IsDuplicate,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }
            author.Edit(command.Name,command.Picture,command.PictureAlt,command.PictureTitle,command.Description);

            _authorRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit Author",reason:ResultMessage.IsSuccess+$"_ {command.Name} Edited",isSuccess:true));
            return operation.Success();
        }

        public List<AuthorViewModel> GetAll(AuthorSearchModel searchModel)
        {
            return _authorRepository.GetAll(searchModel);
        }

        public EditAuthor GetDetails(long id)
        {
            return _authorRepository.GetDetails(id);
        }
    }
}
