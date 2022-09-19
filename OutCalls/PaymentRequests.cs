using SettleApi.Helpers;
using SettleApi.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleApi.OutCalls
{
    public class PaymentRequests
    {
        private readonly ISettleApiClient _settleApi;

        public PaymentRequests(ISettleApiClient apiClient)
        {
            _settleApi = apiClient;
        }
        public async Task<Result<PaymentResponse>> CreatePayment(PaymentRequest req)
        {
            req.Action = ActionType.SALE;
            string endpoint = "/payment_request";
            return await _settleApi.Post<PaymentResponse>(endpoint, req);
        }
        public async Task<PaymentCallback> OutcomePayment(string transactionId)
        {
            string endpoint = "/payment_request/" + transactionId + "/outcome/";
            return await _settleApi.Get<PaymentCallback>(endpoint);
        }
        public async Task<Result<PaymentCallback>> CapturePayment(string transactionId)
        {
            PaymentCapture req = new PaymentCapture();
            req.Action = ActionType.CAPTURE;
            string endpoint = "/payment_request/" + transactionId + "/";
            return await _settleApi.Put<PaymentCallback>(endpoint, req);
        }
        public async Task<Result<PaymentCallback>> AbortPayment(string transactionId)
        {
            PaymentCapture req = new PaymentCapture();
            req.Action = ActionType.ABORT;
            string endpoint = "/payment_request/" + transactionId + "/";
            return await _settleApi.Put<PaymentCallback>(endpoint, req);
        }
        public async Task<Result<PaymentCallback>> RefundPayment(string transactionId)
        {
            PaymentCapture req = new PaymentCapture();
            req.Action = ActionType.REFUND;
            string endpoint = "/payment_request/" + transactionId + "/";
            return await _settleApi.Put<PaymentCallback>(endpoint, req);
        }
        public async Task<List<PaymentResponse>> GetTransactions()
        {
            string endpoint = "/payment_request";
            return await _settleApi.Get<List<PaymentResponse>>(endpoint);
        }    
    }
}
