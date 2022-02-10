using System;
using System.Text;
using RabbitMQ.Client;

namespace Publisher  
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RabbitMQ Publisher!");
            Console.WriteLine("Angel Javier Valdez");
            var factory = new ConnectionFactory(){HostName="localhost"};
            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    //channel.QueueDeclare(queue: "hello", durable:false, exclusive:false, autoDelete:false, arguments:null);
                    channel.ExchangeDeclare(exchange:"logs", type:ExchangeType.Fanout);

                    string message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "logs", routingKey: "", basicProperties:null, body: body);
                    Console.WriteLine($"[x] Sent {message}");

                }

            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            
        }

        private static string GetMessage(string[] args)
        {
            return (args.Length > 0)? string.Join(" ", args): "info: Hola mundo!";
        }
    }
    
}



