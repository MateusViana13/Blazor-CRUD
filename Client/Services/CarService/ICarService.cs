using CRUD_WEBAPI_BLAZOR.Shared;

namespace CRUD_WEBAPI_BLAZOR.Client.Services.CarService
{
    public interface ICarService
    {
        List<Car> Cars { get; set; }
        List<Manufacturer> Manufacturers { get; set; }
        Task GetManufactures();
        Task GetCars();
        Task<Car> GetSingleCar(int? id);
        Task CreateCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(int id);
    }
}
