namespace HotelAPI.Utilties
{
    public class ErrorResponse
    {
        // Extremely basic error response class
        public string Message { get; set; }
        public string Details { get; set; }

        public ErrorResponse(string message, string details = "")
        {
            Message = message;
            Details = details;
        }
    }

}
