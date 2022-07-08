using _01_Framework.Domain;

namespace BlogManagement.Domain.LogAgg
{
    public class LogBlogManagement
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get;private  set; }
        public string MakerOperation { get;private set; }
        public string PlaceOperation { get;private set; }
        public string Reason { get;private set; }
        public bool IsSuccess { get;private set; }

        public LogBlogManagement(string makerOperation, string placeOperation, string reason, bool isSuccess)
        {
            MakerOperation = makerOperation;
            PlaceOperation = placeOperation;
            Reason = reason;
            IsSuccess = isSuccess;
            CreationDate = DateTime.Now;
        }
    }

   
}
