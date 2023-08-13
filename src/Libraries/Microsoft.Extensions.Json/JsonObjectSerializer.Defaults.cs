using System.Text.Json.Serialization;

namespace System.Text.Json;

public sealed partial class JsonObjectSerializer
{
    public static class Defaults
    {
        public static JsonSerializerOptions JsonWebScenario(JsonSerializerOptions? options = default)
        {
            options ??= new JsonSerializerOptions();

            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            //options.IgnoreNullValues = true;

            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            
            options.PropertyNameCaseInsensitive = true;
            options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

            options.AllowTrailingCommas = true;
            options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.WriteIndented = true;

            return options;
        }
    }
}
