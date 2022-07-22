
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerMyFirstAPI.Controller
{
    class ConsumerController
    {
        public TripRepository TripRepository { get; set; }
        public string IdTripConsumed { get; set; }
        public ConsumerController(string qname)
        { }

        public void SelectDriverById()
        { }

        public TripModel ConsumeQueue(bool printTrip)
        {
            TripModel trip01 = new TripModel();
            var factory = new ConnectionFactory()
            {
                HostName = MyConfig.HostName
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare
                    (
                    queue: MyConfig.QueueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        trip01 = System.Text.Json.JsonSerializer.Deserialize<TripModel>(message);

                        if (printTrip == true)
                        Console.WriteLine($"[Via Consumo da Fila] Trip ID: {trip01.Id} | Driver Name: {trip01.NameDriver} | Driver Phone Number: {trip01.PhoneNumberDriver}");  
                    };
                
                    channel.BasicConsume(queue: MyConfig.QueueName,
                                    autoAck: true,
                                    consumer: consumer);
                    //if (printTrip == true) { Console.ReadLine(); }
                    //Console.ReadLine();
                    return trip01;
                }
            }
        }
    }
}
