using ProcurmentProjectView.DTOs;
using System.Text.Json.Serialization;

namespace ProcurmentProjectView.Models
{
    public class PrDetailResponseModel
    {
        [JsonPropertyName("prId")]
        public int PrId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("estimationBudget")]
        public string EstimationBudget { get; set; } = string.Empty;

        [JsonPropertyName("deliveryDate")]
        public string? DeliveryDate { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
        //[JsonPropertyName("note")]
        //public string Note { get; set; }

        // Mapped to match "product" array in JSON
        [JsonPropertyName("product")]
        public List<PrProductDto> Products { get; set; } = new List<PrProductDto>();
    }
}
