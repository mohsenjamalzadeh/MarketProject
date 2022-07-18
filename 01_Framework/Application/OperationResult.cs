namespace _01_Framework.Application
{
    public class OperationResult
    {
        public bool sucssesed { get; set; }
        public string? Message { get; set; }

        public OperationResult Success(string message="operation was done successfully" )
        {
            sucssesed = true;
            Message=message;
            return this;
        }

        public OperationResult Failed(string message)
        {sucssesed = false;
            Message=message;
            return this;
        }
    }
}
