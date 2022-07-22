using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerMyFirstAPI
{
    class TripRepository
    {
        public string ConnectionString;
        public TripRepository(string conn)
        {
            this.ConnectionString = conn;
        }

        public TripModel SelectTripFromDB(int IdTripRequest)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                TripModel tripRepository01 = new TripModel();
                string queryString = $"SELECT id, driver_name, driver_phone_number FROM trip WHERE id = '{IdTripRequest}'";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tripRepository01.Id = (int)reader[0];
                    tripRepository01.NameDriver = (string)reader[1];
                    tripRepository01.PhoneNumberDriver = (string)reader[2];
                }
                Console.WriteLine($"[Via Query do Banco de Dados] Trip ID: {tripRepository01.Id} | Name Driver: {tripRepository01.NameDriver} | Phone Number Driver: {tripRepository01.PhoneNumberDriver}");
                return tripRepository01;
            }
        }
    }
}
