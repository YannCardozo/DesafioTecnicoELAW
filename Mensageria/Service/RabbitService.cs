using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Mensageria.Service
{
    public static class RabbitService
    {
        private const string Queue = "novos_processos";

        private static readonly ConnectionFactory _factory = new()
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "guest",
            Password = "guest"
        };

        public static void Publish(object payload)
        {

            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: Queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload));
            var props = channel.CreateBasicProperties();
            props.Persistent = true;

            channel.BasicPublish(
                exchange: "",
                routingKey: Queue,
                basicProperties: props,
                body: body);
        }
    }
}
