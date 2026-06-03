using System.Text.Json.Serialization;

namespace ProcurmentProjectView.DTOs
{
    public class PrRequestDto
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("estimated_budget")]
        public string EstimatedBudget { get; set; } = default!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("deliveryDate")]
        public string DeliveryDate { get; set; } = default!;

        [JsonPropertyName("note")]
        public string Note { get; set; } = default!;
    }
}
