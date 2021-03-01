namespace Core.Models.Errors
{
    public class Error
    {
        public Error() { }
        public Error(string code, string message = "An error occured while processing your request")
        {
            this.Code = code;
            this.Message = message;
        }


        public string Code { get; set; }
        public string Message { get; set; }
    }
}
