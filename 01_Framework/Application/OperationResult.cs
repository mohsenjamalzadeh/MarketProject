namespace _01_Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public OperationResult Success(string message="operation was done successfully" )
        {
            IsSuccess = true;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSuccess = false;
            return this;
        }
    }
}
