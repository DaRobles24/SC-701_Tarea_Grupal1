using ReservationWeb.Api.DTOs;

namespace ReservationWeb.Api.Services
{
    public interface IReservationServices
    {
        Task<List<ListReservationDto>> GetAllReservations();
        Task CreateReservation(CreateReservationDto createReservationDto);
    }
}
