using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Api.Client;
using Mollie.Api.Models.List;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;
using Mollie.Api.Models.PaymentMethod;
using Microsoft.Extensions.Logging;

namespace CineMagicBlazor.Services
{
    public class MolliePaymentService
    {
        private readonly PaymentClient _paymentClient;
        private readonly PaymentMethodClient _paymentMethodClient;
        private readonly string _apiKey;
        private readonly ILogger<MolliePaymentService> _logger;

        public MolliePaymentService(IHttpClientFactory clientFactory, string apiKey, ILogger<MolliePaymentService> logger)
        {
            HttpClient httpClient = clientFactory.CreateClient(nameof(MolliePaymentService));
            _apiKey = apiKey;
            _logger = logger;
            
            _paymentClient = new PaymentClient(_apiKey, httpClient);
            _paymentMethodClient = new PaymentMethodClient(_apiKey, httpClient);
        }

        public async Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest)
        {
            try
            {
                var result = await _paymentClient.CreatePaymentAsync(paymentRequest);
                // Log success
                _logger.LogInformation($"Payment created successfully, ID: {result.Id}");
                return result;
            }
            catch (Exception ex)
            {
                // Log error
                _logger.LogError($"Error creating payment: {ex.Message}");
                throw;
            }
        }

        public async Task<PaymentResponse> GetPaymentStatusAsync(string paymentId)
        {
            return await _paymentClient.GetPaymentAsync(paymentId);
        }
        
        public async Task<ListResponse<PaymentMethodResponse>> GetPaymentMethodsAsync()
        {
            return await _paymentMethodClient.GetPaymentMethodListAsync();
        }
    }
}