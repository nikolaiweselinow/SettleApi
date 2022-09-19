using Newtonsoft.Json;
using NLog;
using SettleApi.Enums;
using SettleApi.Helpers;
using SettleApi.Models.Error;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SettleApi
{
    public class SettleApiClient : ISettleApiClient
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private HttpClient _httpClient;        
        private string _endpoint;      
        private ApiMode _apiMode;
        private string _merchantId;
        private string _userId;
        private string _secretKey;    

        public SettleApiClient(string merchantId, string userId, string secretKey, ApiMode apiMode = ApiMode.sandbox)
        {            
            _httpClient = new HttpClient();            
            _merchantId = merchantId;
            _userId = userId;
            _secretKey = secretKey;            
            _apiMode = apiMode;
            //CREATE DEFAULT HEADERS INFORMATION

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.mcash.api.merchant.v1+json"));            
            _httpClient.DefaultRequestHeaders.Add("X-Settle-Merchant", _merchantId);
            _httpClient.DefaultRequestHeaders.Add("X-Settle-User", _userId);
            _httpClient.DefaultRequestHeaders.Add("Authorization", "SECRET " + _secretKey);            

            if (_apiMode == ApiMode.sandbox)
                _endpoint = "https://api.sandbox.settle.eu/merchant/v1";
            else
                _endpoint = "https://api.settle.eu/merchant/v1";           
        }     

        public async Task<T> Get<T>(string url)
        {
            string responseContent = "";
            try
            {
                var response = await _httpClient.GetAsync(_endpoint + url);                
                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                }
                if (response.IsSuccessStatusCode)
                {                    
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                {
                    _logger.Error(response.StatusCode + "Error: " + responseContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, responseContent);
            }
            return default(T);
        }

        public async Task<Result<T>> Put<T>(string url, object obj)
        {
            string responseContent = "";
            try
            {                
                string postData = JsonConvert.SerializeObject(obj);
                var response = await _httpClient.PutAsync(_endpoint + url, new StringContent(postData, Encoding.UTF8, "application/json"));
                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                }
                if (response.IsSuccessStatusCode)
                {
                    return Result.Ok(JsonConvert.DeserializeObject<T>(responseContent));                    
                }
                else if (!string.IsNullOrEmpty(responseContent))
                {
                    return Result.Fail<T>(JsonConvert.DeserializeObject<ErrorModel>(responseContent).ErrorDescription);
                }
                else
                {
                    _logger.Error(response.StatusCode + "Error: " + responseContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Result.Fail<T>();
        }

        public async Task<Result<T>> Post<T>(string url, object obj)
        {
            string responseContent = "";
            try
            {                
                string postData = JsonConvert.SerializeObject(obj);
                var response = await _httpClient.PostAsync(_endpoint + url + "/", new StringContent(postData, Encoding.UTF8, "application/json"));
                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                }
                if (response.IsSuccessStatusCode)
                {
                    return Result.Ok(JsonConvert.DeserializeObject<T>(responseContent));
                }
                else if (!string.IsNullOrEmpty(responseContent))
                {
                    return Result.Fail<T>(JsonConvert.DeserializeObject<ErrorModel>(responseContent).ErrorDescription);
                }
                else
                {
                    _logger.Error($"Error posting data. Status code: {response.StatusCode}, Response: null");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Result.Fail<T>();
        }

       
    }
}
