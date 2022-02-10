using System;
using System.Text;
using RabbitMQ.Client;


namespace Send  
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RabbitMQ Send!");
            Console.WriteLine("Angel Javier Valdez");
            var factory = new ConnectionFactory(){HostName="localhost"};
            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello", durable:false, exclusive:false, autoDelete:false, arguments:null);
                    string message = "Hola mundo!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties:null, body: body);
                    Console.WriteLine($"[x] Sent {message}");

                }

            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            
        }
    }
    
}


