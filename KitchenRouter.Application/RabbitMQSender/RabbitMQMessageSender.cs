using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace KitchenRouter.Application.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _username;
        private readonly string _password;

        public RabbitMQMessageSender()
        {
            _hostName = "host.docker.internal";
            _username = "user";
            _password = "password";
        }

        public void SendMessage(byte[] body, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _username,
                Password = _password
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body);
        }
    }
}
