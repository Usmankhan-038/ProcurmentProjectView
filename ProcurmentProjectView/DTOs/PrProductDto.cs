using System.Text.Json.Serialization;

namespace ProcurmentProjectView.DTOs
{
    public class PrProductDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("company")]
        public string Company { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        [JsonPropertyName("upc")]
        public string Upc { get; set; } = default!;
    }
}
