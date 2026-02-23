using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationWeb.Mvc.Models;

namespace ReservationWeb.Mvc.Services
{
    public interface IReservationApiService
    {
        Task<List<ReservationListViewModel>> GetAllAsync();
        Task<ReservationListViewModel?> GetByIdAsync(int id);
        Task CreateAsync(ReservationFormViewModel model);
        Task UpdateAsync(ReservationFormViewModel model);
        Task DeleteAsync(int id);
    }

    public class ReservationApiService : IReservationApiService
    {
        private readonly HttpClient _httpClient;

        public ReservationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: api/reservations
        public async Task<List<ReservationListViewModel>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ReservationListViewModel>>("api/reservations");
            return result ?? new List<ReservationListViewModel>();
        }

        // GET: api/reservations/{id}
        public async Task<ReservationListViewModel?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ReservationListViewModel>($"api/reservations/{id}");
        }

        // POST: api/reservations
        public async Task CreateAsync(ReservationFormViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/reservations", model);
            response.EnsureSuccessStatusCode();
        }

        // PUT: api/reservations/{id}
        public async Task UpdateAsync(ReservationFormViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/reservations/{model.Id}", model);
            response.EnsureSuccessStatusCode();
        }

        // DELETE: api/reservations/{id}
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/reservations/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
