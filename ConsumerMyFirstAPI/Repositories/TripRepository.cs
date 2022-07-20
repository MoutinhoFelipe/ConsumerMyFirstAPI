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

        public Trip selectTripFromDB(string IdTripRequest)
        {
            using (var connection = new SqlConnection(ConnectionString)) 
            {
                Trip trip01 = new Trip();
                string queryString = $"SELECT id, driver_name, driver_phone_number FROM trip WHERE id = '{IdTripRequest}'";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    trip01.Id = (int)reader[0];
                    trip01.NameDriver = (string)reader[1];
                    trip01.PhoneNumberDriver = (string)reader[2];
                }
                
                return trip01;
            }
        }
    }
}
