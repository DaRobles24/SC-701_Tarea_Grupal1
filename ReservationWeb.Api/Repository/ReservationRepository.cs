using Microsoft.Data.SqlClient;
using ReservationWeb.Api.Models;

namespace ReservationWeb.Api.Repository
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly string _connectionString;
        public ReservationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        
        public async Task<List<Reservation>> GetAllReservations()
        {
            var reservations = new List<Reservation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT Id, Paciente, Medico, Especialidad, Fecha, FechaCreacion FROM Reservas", connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        reservations.Add(new Reservation
                        {
                            Id = reader.GetInt32(0),
                            Paciente = reader.GetString(1),
                            Medico = reader.GetString(2),
                            Especialidad = reader.GetString(3),
                            Fecha = reader.GetDateTime(4),
                            FechaCreacion = reader.GetDateTime(5)
                        });
                    }
                }
            }

            return reservations;

        }
        public async Task CreateReservation(Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Reservas (Paciente, Medico, Especialidad, Fecha, FechaCreacion) VALUES (@Paciente, @Medico, @Especialidad, @Fecha, @FechaCreacion)", connection);
                command.Parameters.AddWithValue("@Paciente", reservation.Paciente);
                command.Parameters.AddWithValue("@Medico", reservation.Medico);
                command.Parameters.AddWithValue("@Especialidad", reservation.Especialidad);
                command.Parameters.AddWithValue("@Fecha", reservation.Fecha);
                command.Parameters.AddWithValue("@FechaCreacion", reservation.FechaCreacion);
                command.ExecuteNonQuery();
            }

        }
    }
}
