using ConsumerMyFirstAPI.Controller;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ConsumerMyFirstAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ConsumerController = new ConsumerController(MyConfig.QueueName);
            var TripRepository = new TripRepository(MyConfig.ConnectionString);
            var TripReturned = new Trip();

            ConsumerController.SelectDriverById();
            TripReturned = TripRepository.selectTripFromDB(ConsumerController.IdTripConsumed);
            Console.WriteLine($"O nome do motorista é {TripReturned.NameDriver} e seu número de telefone é {TripReturned.PhoneNumberDriver}");
        }
    }
}
