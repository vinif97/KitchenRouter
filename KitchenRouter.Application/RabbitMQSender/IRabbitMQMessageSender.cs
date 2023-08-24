namespace KitchenRouter.Application.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(byte[] body, string queueName);
    }
}
