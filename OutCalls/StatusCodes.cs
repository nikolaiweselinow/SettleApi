using SettleApi.Models.StatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleApi.OutCalls
{
    public class StatusCodes
    {
        private readonly ISettleApiClient _settleApi;
        public StatusCodes(ISettleApiClient apiClient)
        {
            _settleApi = apiClient;
        }

        public async Task<List<StatusCodeModel>> ListStatusCodes()
        {
            string endpoint = "/status_code/";
            return await _settleApi.Get<List<StatusCodeModel>>(endpoint);            
        }
        public async Task<StatusCodeModel> GetStatusCode(string statusCodeId)
        {
            string endpoint = "/status_code/" + statusCodeId + "/";
            return await _settleApi.Get<StatusCodeModel>(endpoint);
        }
    }
}
