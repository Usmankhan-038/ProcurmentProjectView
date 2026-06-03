namespace ProcurmentProjectView.DTOs
{
    public class PrDataDto
    {
        public int TotalPrCount { get; set; }
        public List<StatusCountDto> PrStatusCount { get; set; } = default!;
    }
}
