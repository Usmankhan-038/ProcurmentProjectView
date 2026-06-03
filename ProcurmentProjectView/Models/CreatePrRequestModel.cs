using System.Text.Json.Serialization;
using ProcurmentProjectView.DTOs;

namespace ProcurmentProjectView.Models
{
    public class CreatePrRequestModel
    {
        [JsonPropertyName("prRequest")]
        public PrRequestDto PrRequest { get; set; } = new PrRequestDto();

        [JsonPropertyName("products")]
        public List<PrProductDto> Products { get; set; } = new List<PrProductDto>();
    }
}
