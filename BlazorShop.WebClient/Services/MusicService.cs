﻿namespace BlazorShop.WebClient.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public MusicService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<MusicResponse>> GetMusics()
        {
            var response = await _httpClient.GetAsync("Musics/musics");
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

            var result = JsonSerializer.Deserialize<Result<MusicResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Items;
        }

        public async Task<MusicResponse> GetMusic(int id)
        {
            var response = await _httpClient.GetAsync($"Musics/music/{id}");
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

            var result = JsonSerializer.Deserialize<Result<MusicResponse>>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result.Item;
        }

        public async Task<RequestResponse> AddMusic(MusicResponse music)
        {
            var response = await _httpClient.PostAsJsonAsync("Musics/music", music);
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

            _toastService.ShowSuccess("The Music was added.");
            return RequestResponse.Success(0);
        }

        public async Task<RequestResponse> UpdateMusic(MusicResponse music)
        {
            var response = await _httpClient.PutAsJsonAsync("Musics/music", music);
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

            _toastService.ShowSuccess("The Music was updated.");
            return RequestResponse.Success(0);
        }

        public async Task<RequestResponse> DeleteMusic(int id)
        {
            var response = await _httpClient.DeleteAsync($"Musics/music/{id}");
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

            _toastService.ShowSuccess("The Music was deleted.");
            return RequestResponse.Success(0);
        }
    }
}
