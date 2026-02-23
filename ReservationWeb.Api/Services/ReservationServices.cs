
using ReservationWeb.Api.DTOs;
using ReservationWeb.Api.Exceptions;
using ReservationWeb.Api.Models;
using ReservationWeb.Api.Repository;

namespace ReservationWeb.Api.Services
{
    public class ReservationServices : IReservationServices
    {
            private readonly IReservationRepository _reservationRepository;
    
            public ReservationServices(IReservationRepository reservationRepository)
            {
                _reservationRepository = reservationRepository;
            }
    
            public async Task<List<ListReservationDto>> GetAllReservations()
            {
                var reservations = await _reservationRepository.GetAllReservations();
                return reservations.Select(r => new ListReservationDto
                {
                    Id = r.Id,
                    Paciente = r.Paciente,
                    Medico = r.Medico,
                    Especialidad = r.Especialidad,
                    Fecha = r.Fecha
                }).ToList();
            }
    
            public async Task CreateReservation(CreateReservationDto createReservationDto)
            {
                DateValidation(createReservationDto.Fecha);
                var reservation = new Reservation
                {
                    Paciente = createReservationDto.Paciente,
                    Medico = createReservationDto.Medico,
                    Especialidad = createReservationDto.Especialidad,
                    Fecha = createReservationDto.Fecha,
                    FechaCreacion = DateTime.UtcNow
                };
                await _reservationRepository.CreateReservation(reservation);
        }

        private void DateValidation(DateTime date)
        {
            if (date < DateTime.UtcNow)
            {
                throw new BusinessException("La fecha de la reserva no puede ser en el pasado.");
                //ArgumentException("La fecha de la reserva no puede ser en el pasado.");
            }
        }
    }
}
