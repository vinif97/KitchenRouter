using System.Text.Json;
using System.Text;

namespace KitchenRouter.Application.Utils
{
    public static class JsonConvertor
    {
        public static byte[] GetMessageAsByteArray<T>(T message)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }
    }
}
