namespace ProcurmentProjectView.Models
{
    public class ResponseModel<T>
    {
        public string Message { get; set; } = default!;
        public T Data { get; set; } 
        public bool Success { get; set; } = true;
        
        
    }
}
