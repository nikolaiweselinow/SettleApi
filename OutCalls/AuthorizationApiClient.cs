using SettleApi.Models.Merchant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleApi.OutCalls
{    
    public class AuthorizationApiClient
    {
        private readonly ISettleApiClient _settleApi;
        public AuthorizationApiClient(ISettleApiClient apiClient)
        {
            _settleApi = apiClient;
        }

        public async Task<MerchantInfo> Authorize(string userId)
        {
            string endpoint = "/api_key/" + userId + "/";
            return await _settleApi.Get<MerchantInfo>(endpoint);
        }      
    }
}
