using System.Text.Json.Serialization;

namespace ProcurmentProjectView.DTOs
{
    public class PrProductDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("company")]
        public string Company { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        [JsonPropertyName("upc")]
        public string Upc { get; set; } = default!;

        // Fallbacks in case the API returns aliased names
        [JsonPropertyName("productName")]
        public string ProductName { get; set; } = default!;

        [JsonPropertyName("productDescription")]
        public string ProductDescription { get; set; } = default!;

        [JsonPropertyName("productUpc")]
        public string ProductUpc { get; set; } = default!;
        
        [JsonPropertyName("productCompany")]
        public string ProductCompany { get; set; } = default!;

        public string GetName() => !string.IsNullOrEmpty(Name) ? Name : ProductName;
        public string GetDescription() => !string.IsNullOrEmpty(Description) ? Description : ProductDescription;
        public string GetUpc() => !string.IsNullOrEmpty(Upc) ? Upc : ProductUpc;
        public string GetCompany() => !string.IsNullOrEmpty(Company) ? Company : ProductCompany;
    }
}
