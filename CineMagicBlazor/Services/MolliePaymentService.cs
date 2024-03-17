using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Api.Client;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;

namespace CineMagicBlazor.Services
{
    public class MolliePaymentService
    {
        private readonly PaymentClient _paymentClient;
        private readonly string _apiKey;
        
        public MolliePaymentService(IHttpClientFactory clientFactory, string apiKey)
        {
            HttpClient httpClient = clientFactory.CreateClient(nameof(MolliePaymentService));
            _apiKey = apiKey;
            _paymentClient = new PaymentClient(_apiKey, httpClient);
        }

        public async Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest)
        {
            return await _paymentClient.CreatePaymentAsync(paymentRequest);
        }

        public async Task<PaymentResponse> GetPaymentStatusAsync(string paymentId)
        {
            return await _paymentClient.GetPaymentAsync(paymentId);
        }

        // Add other methods as necessary for handling different parts of the payment process
    }
}