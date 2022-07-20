using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerMyFirstAPI.Services
{
    class QueueService
    {
        public string queueName;
        public QueueService(string qname)
        {
            this.queueName = qname;
        }

        public string ConsumeQueue()
        {
            string id_tripConsumed = null;
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare
                    (
                    queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        id_tripConsumed = Encoding.UTF8.GetString(body);
                        Console.WriteLine(id_tripConsumed);
                    };

                    channel.BasicConsume(queue: queueName,
                    autoAck: true,
                    consumer: consumer);

                    return id_tripConsumed;
                }
            }
        }
    }
}
