using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Util
{
    class RabbitMQ
    {
        private ConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel channel;

        public RabbitMQ()
        {
            connectionFactory = new ConnectionFactory() { HostName = "localhost" };
        }

        public String receive(String queueName)
        {
            
            Console.WriteLine(queueName);
            Console.WriteLine("In RabbitMQ.receive");
            string messageReceived = "";
            Console.WriteLine("connectionFactory : " + connectionFactory);
            
            using (connection = connectionFactory.CreateConnection())
            {
                Console.WriteLine("connection : " + connection);
                using (channel = connection.CreateModel())
                {
                    Console.WriteLine("channel : " + channel);
                    channel.QueueDeclare(queue: queueName,
                                            durable: false,
                                            exclusive: false,
                                            autoDelete: false,
                                            arguments: null);
                    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                    Console.WriteLine("Requesting message");
                    consumer.Received += (Model, ea) =>
                    {
                        var body = ea.Body;
                        messageReceived = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Message received : " + messageReceived);
                    };

                    channel.BasicConsume(queue: queueName,
                        noAck: true,
                        consumer: consumer);

                    Console.WriteLine("Waiting for message ...");

                    while (messageReceived == "") { } //menunggu hingga menerima pesan

                    channel.Close();
                    connection.Close();
                    return messageReceived;
                }
                
            }
           
        }
    }
}
