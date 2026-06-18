using System.Text.Json.Serialization;
using ProcurmentProjectView.DTOs;

namespace ProcurmentProjectView.Models
{
    public class CreatePrRequestModel
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public List<PrDetailResponseModel> Data { get; set; } = new List<PrDetailResponseModel>();
    }
}
