namespace Application
{
    public class Result
    {
        public bool Success;
        public string message;

        public Result(bool success, string message)
        {
            Success = success;
            message = message;
        }
    }
}