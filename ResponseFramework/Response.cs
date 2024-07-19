using System.Net;


namespace ResponseFramework
{
    public class Response<Tresualt> : IResponse<Tresualt>
    {
        

        public Response(bool isSuccess, string? message, string? errorMessage, Tresualt? result, HttpStatusCode httpStatusCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            ErrorMessage = errorMessage;
            Result = result;
            HttpStatusCode = httpStatusCode;
        }
        public Response(Tresualt result)
        {
            Result = result;

            if (result != null)
            {
                IsSuccess = true;
                Message = "Successful";
                ErrorMessage = string.Empty;
                HttpStatusCode = HttpStatusCode.OK;
            }
            else
            {
                IsSuccess = false;
                Message = string.Empty;
                ErrorMessage = "Error";
                HttpStatusCode = HttpStatusCode.Ambiguous;
            }

        }
        public Response(string? errorMessage)
        {
            IsSuccess=false;
            Message= string.Empty;
            ErrorMessage = errorMessage;
            Result = default;
            HttpStatusCode = HttpStatusCode.Ambiguous;
        }

        public bool IsSuccess { get; set;}
        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }
        public Tresualt? Result { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
