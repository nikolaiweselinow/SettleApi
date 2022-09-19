using Newtonsoft.Json;

namespace SettleApi.Models.Payment
{
    public class PaymentRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("allow_credit")]
        public bool AllowCredit { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("pos_id")]
        public string PosId { get; set; }

        [JsonProperty("pos_tid")]
        public string PosTid { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("success_return_uri")]
        public string SuccessReturnUri { get; set; }

        [JsonProperty("failure_return_uri")]
        public string FailureReturnUri { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
