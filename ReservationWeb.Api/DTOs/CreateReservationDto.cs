namespace ReservationWeb.Api.DTOs
{
    public class CreateReservationDto
    {
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
