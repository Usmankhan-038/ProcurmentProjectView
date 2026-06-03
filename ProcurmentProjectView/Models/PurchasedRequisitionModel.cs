using System.Text.Json.Serialization;

namespace ProcurmentProjectView.Models
{
    public class PurchasedRequisitionModel
    {
        public int Id { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("estimated_budget")]
        public string EstimatedBudget { get; set; } = default!;
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;
        [JsonPropertyName("deliveryDate")]
        public DateOnly DeliveryDate { get; set; }
        [JsonPropertyName("note")]
        public string Note { get; set; } = default!;
        [JsonPropertyName("products")]
        public ProductModel Product { get; set; } = default!;

    }
}
