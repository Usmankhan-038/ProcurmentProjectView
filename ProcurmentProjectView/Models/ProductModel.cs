using System.Text.Json.Serialization;

namespace ProcurmentProjectView.Models
{
    using System.Text.Json.Serialization;

    public class ProductModel
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("company")]
        public string Company { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        [JsonPropertyName("upc")]
        public string Upc { get; set; } = default!;
        
        public DateTime CreatedAt { get; set; } 
    }
}
