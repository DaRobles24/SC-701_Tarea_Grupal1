using ReservationWeb.Api.Services;
using ReservationWeb.Api.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace ReservationWeb.Api.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : Controller
    {
        private readonly IReservationServices _reservationServices;
        public ReservationController(IReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ListReservationDto>>> GetAllReservations()
        {
            var reservations = await _reservationServices.GetAllReservations();
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            await _reservationServices.CreateReservation(createReservationDto);
            return Ok();
        }
    }
}
