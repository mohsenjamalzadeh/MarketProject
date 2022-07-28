using _0_Framework.Application;
using _01_Framework.Application;
using BlogManagement.Application.Contracts.Author;
using BlogManagement.Domain.AuthorAgg;
using BlogManagement.Domain.LogAgg;

namespace BlogManagement.Application
{
    public class AuthorApplication : IAuthorApplication
    {
        private readonly IBlogManagementLogRepository _logRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IFileUploader _fileUploader;
        public AuthorApplication(IBlogManagementLogRepository logRepository, IAuthorRepository authorRepository, IFileUploader fileUploader)
        {
            _logRepository = logRepository;
            _authorRepository = authorRepository;
            _fileUploader = fileUploader;
        }


        public async Task<OperationResult> DefineAuthor(DefinitionAuthor command)
        {
            var operation = new OperationResult();
            if (_authorRepository.IsExist(p => p.Name == command.Name))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Define Author", reason: ResultMessage.IsDuplicate + $"_for Name{command.Name}", isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            var picture = await _fileUploader.UploadAsync(command.Picture, $"Blog/Authors/{command.Name.Slugify()}/");
            var author = new Author(command.Name, picture, command.PictureAlt, command.PictureTitle, command.Description);

            _authorRepository.Create(author);
            _authorRepository.SaveChange();

            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Define Author", reason: ResultMessage.IsSuccess + $"_ {command.Name} Added in Authors ", isSuccess: true));
            return operation.Success();
        }

        public async Task<OperationResult> EditAuthor(EditAuthor command)
        {
            var operation = new OperationResult();
            var author = _authorRepository.Get(command.Id);
            if (author == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Edit Author", reason: ResultMessage.EntityNotFound + $"_for Name{command.Name}", isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            if (_authorRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Edit Author", reason: ResultMessage.IsDuplicate + $"_for Name{command.Name}", isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            var picture = await _fileUploader.UploadAsync(command.Picture, $"Blog/Authors/{command.Name.Slugify()}/");
            author.Edit(command.Name, picture, command.PictureAlt, command.PictureTitle, command.Description);

            _authorRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Edit Author", reason: ResultMessage.IsSuccess + $"_ {command.Name} Edited", isSuccess: true));
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
