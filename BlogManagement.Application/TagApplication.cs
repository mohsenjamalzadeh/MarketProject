using _01_Framework.Application;
using BlogManagement.Application.Contracts.Tag;
using BlogManagement.Domain.LogAgg;
using BlogManagement.Domain.TagAgg;

namespace BlogManagement.Application
{
    public class TagApplication:ITagApplication
    {
        private readonly IBlogManagementLogRepository _logRepository;
        private readonly ITagRepository _tagRepository;

        public TagApplication(IBlogManagementLogRepository logRepository, ITagRepository tagRepository)
        {
            _logRepository = logRepository;
            _tagRepository = tagRepository;
        }

        public OperationResult CreateTag(CreateTag command)
        {
            var operation = new OperationResult();
            if ( _tagRepository.IsExist(p => p.Name == command.Name))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Create Tag",reason:ResultMessage.IsDuplicate,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            var author = new Tag(command.Name);

            _tagRepository.Create(author);
            _tagRepository.SaveChange();
            
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Create Tag",reason:ResultMessage.IsSuccess+$"_ {command.Name} Added in Tags ",isSuccess:true));
            return operation.Success();
        }

        public OperationResult EditTag(EditTag command)
        {
            var operation = new OperationResult();
            var Tag = _tagRepository.Get(command.Id);
            if (Tag == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit Tag",reason:ResultMessage.EntityNotFound,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            if (_tagRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
            {
                _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit Tag",reason:ResultMessage.IsDuplicate,isSuccess:false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }
            Tag.Edit(command.Name);

            _tagRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation:"Admin",placeOperation:"Edit Tag",reason:ResultMessage.IsSuccess+$"_{command.Name} Edited",isSuccess:true));
            return operation.Success();
        }

        public List<TagViewModel> GetAll(TagSearchModel searchModel)
        {
            return _tagRepository.GetAll(searchModel);
        }

        public EditTag GetDetails(long id)
        {
            return _tagRepository.GetDetails(id);
        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var tag = _tagRepository.Get(id);
            if (tag == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "Activate Tag", reason: ResultMessage.EntityNotFound, isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            tag.Active();
            _tagRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: $"Activate Tag", reason: ResultMessage.IsSuccess+$"_ {tag.Name} Activate", isSuccess: true));
            return operation.Success();
        }

        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var tag = _tagRepository.Get(id);
            if (tag == null)
            {
                _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: "InActivate Tag", reason: ResultMessage.EntityNotFound, isSuccess: false));
                return operation.Failed(ResultMessage.IsDuplicate);
            }

            tag.Inactive();
            _tagRepository.SaveChange();
            _logRepository.Log(new LogBlogManagement(makerOperation: "Admin", placeOperation: $"InActivate Tag", reason: ResultMessage.IsSuccess+$"_ {tag.Name} InActivate", isSuccess: true));
            return operation.Success();
        }
    }
}
