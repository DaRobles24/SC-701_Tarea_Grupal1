using ReservationWeb.Api.Models;

namespace ReservationWeb.Api.Repository
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservations();
        Task CreateReservation(Reservation reservation);
    }
}
