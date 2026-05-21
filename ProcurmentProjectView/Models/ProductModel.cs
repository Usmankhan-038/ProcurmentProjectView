using System.Text.Json.Serialization;

namespace ProcurmentProjectView.Models
{
    using System.Text.Json.Serialization;

    public class ProductModel
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public string company { get; set; } // already lowercase, matches API

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("upc")]
        public string Upc { get; set; }

        public DateTime createdAt { get; set; } // already camelCase, matches API
    }
}
