namespace ProcurmentProjectView.Models
{
    public class TokenResponseModel
    {
        public string Message { get; set; } = default!;
        public string? Data { get; set; } = default!;
        public bool Success { get; set; } = true;
        
        
    }
}
