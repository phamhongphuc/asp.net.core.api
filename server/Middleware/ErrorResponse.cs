using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace server.Middleware
{
    public class ErrorResponse
    {
        private static JsonSerializerSettings JsonSetting = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };

        public string Action { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }

        public static explicit operator string(ErrorResponse error)
            => JsonConvert.SerializeObject(error, JsonSetting);
    }
}
