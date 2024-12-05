namespace SmartAgroAPI.DataTransferObjects
{
    public class ApiRequestToken
    {
        public required ApiRequestUser user { get; set; }
        public required string Token { get; set; }
    }
}
