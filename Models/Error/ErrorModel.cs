using Newtonsoft.Json;

namespace SettleApi.Models.Error
{
    public class ErrorModel
    {
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error_details")]
        public ErrorDetails ErrorDetails { get; set; }
    }

    public class ErrorDetails
    {
        [JsonProperty("amount")]
        public string[] Amount { get; set; }
    }
}
