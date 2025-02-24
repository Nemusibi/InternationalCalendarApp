using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendarClient.Models;

namespace CalendarClient.Services
{
    public class CalendarService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/Calendar/";

        public CalendarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CheckHealthAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Calendar/health");
                Console.WriteLine($"Health check status: {response.StatusCode}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Health check failed: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync(string country)
        {
            try
            {
                Console.WriteLine($"Attempting to fetch holidays for {country}");
                var response = await _httpClient.GetAsync($"api/Calendar/GetHolidays/{country}");

                Console.WriteLine($"Holiday response status: {response.StatusCode}");
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Holiday response content: {content}");

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<Holiday>>()
                       ?? new List<Holiday>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetHolidaysAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Event>> GetEventsAsync(string country)
        {
            try
            {
                Console.WriteLine($"Attempting to fetch events for {country}");
                var response = await _httpClient.GetAsync($"api/Calendar/GetEvents/{country}");

                Console.WriteLine($"Events response status: {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<Event>>()
                       ?? new List<Event>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetEventsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Visit>> GetVisitsAsync()
        {
            try
            {
                Console.WriteLine("Getting visits...");
                var response = await _httpClient.GetFromJsonAsync<List<Visit>>($"{_baseUrl}visits");
                Console.WriteLine($"Got {response?.Count ?? 0} visits");
                return response ?? new List<Visit>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting visits: {ex.Message}");
                throw;
            }
        }

        public async Task LogVisitAsync(Visit visit)
        {
            try
            {
                Console.WriteLine($"Logging visit to {visit.Country} on {visit.Date}");
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}visits", visit);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Visit logged successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging visit: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteVisitAsync(int visitId)
        {
            try
            {
                Console.WriteLine($"Deleting visit {visitId}");
                var response = await _httpClient.DeleteAsync($"{_baseUrl}visits/{visitId}");
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Visit deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting visit: {ex.Message}");
                throw;
            }
        }
    }
}