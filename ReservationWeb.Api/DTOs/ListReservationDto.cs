namespace ReservationWeb.Api.DTOs
{
    public class ListReservationDto
    {
        public int Id { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public DateTime Fecha { get; set; }

    }
}
