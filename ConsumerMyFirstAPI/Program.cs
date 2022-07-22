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
            var TripReturned = new TripModel();

            //True para ligar Console.WriteLine
            //ConsumerController.ConsumeQueue(true);
            var idReturned = ConsumerController.ConsumeQueue(false).Id;
            TripRepository.SelectTripFromDB(idReturned);
        }
    }
}
