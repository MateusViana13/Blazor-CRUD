using CRUD_WEBAPI_BLAZOR.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CRUD_WEBAPI_BLAZOR.Client.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public CarService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public List<Car> Cars { get; set; } = new List<Car>();
        public List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

        public async Task CreateCar(Car car)
        {
            var result = await _httpClient.PostAsJsonAsync("api/car", car);
            await SetCars(result);
        }

        private async Task SetCars(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Car>>();
            Cars = response;
            _navigationManager.NavigateTo("cars");
        }

        public async Task DeleteCar(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/car/{id}");
            await SetCars(result);
            
        }

        public async Task GetCars()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Car>>("api/car");
            if (result != null)
                Cars = result;
        }

        public async Task GetManufactures()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Manufacturer>>("api/car/manufacturers");
            if (result != null)
                Manufacturers = result;
        }

        public async Task<Car> GetSingleCar(int? id)
        {
            var result = await _httpClient.GetFromJsonAsync<Car>($"api/car/{id}");
            if (result != null)
                return result;
            throw new Exception("Car not found!");
        }

        public async Task UpdateCar(Car car)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/car/{car.Id}", car);
            await SetCars(result);
        }
    }
}
