﻿namespace BlazorShop.WebClient.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public SubscriptionService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<SubscriptionResponse>> GetSubscriptions()
        {
            var response = await _httpClient.GetAsync("Subscriptions/subscriptions");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var errorMessage = resultError.Successful == false ? resultError.Error : resultError.Title + ": " + resultError.Detail;
                _toastService.ShowError(errorMessage);
                return null;
            }

            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Items;
        }

        public async Task<SubscriptionResponse> GetSubscription(int id)
        {
            var response = await _httpClient.GetAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var errorMessage = resultError.Successful == false ? resultError.Error : resultError.Title + ": " + resultError.Detail;
                _toastService.ShowError(errorMessage);
                return null;
            }

            var result = JsonSerializer.Deserialize<Result<SubscriptionResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Item;
        }

        public async Task<RequestResponse> AddSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PostAsJsonAsync("Subscriptions/subscription", Subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var errorMessage = resultError.Successful == false ? resultError.Error : resultError.Title + ": " + resultError.Detail;
                _toastService.ShowError(errorMessage);
                return null;
            }

            _toastService.ShowSuccess("The Subscription was added.");
            return RequestResponse.Success(0);
        }

        public async Task<RequestResponse> UpdateSubscription(SubscriptionResponse Subscription)
        {
            var response = await _httpClient.PutAsJsonAsync("Subscriptions/subscription", Subscription);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var errorMessage = resultError.Successful == false ? resultError.Error : resultError.Title + ": " + resultError.Detail;
                _toastService.ShowError(errorMessage);
                return null;
            }

            _toastService.ShowSuccess("The Subscription was updated.");
            return RequestResponse.Success(0);
        }

        public async Task<RequestResponse> DeleteSubscription(int id)
        {
            var response = await _httpClient.DeleteAsync($"Subscriptions/subscription/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var errorMessage = resultError.Successful == false ? resultError.Error : resultError.Title + ": " + resultError.Detail;
                _toastService.ShowError(errorMessage);
                return null;
            }

            _toastService.ShowSuccess("The Subscription was deleted.");
            return RequestResponse.Success(0);
        }
    }
}
