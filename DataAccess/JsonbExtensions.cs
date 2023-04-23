using Core.Models;
using Newtonsoft.Json;

namespace DataAccess;

public static class JsonbExtensions
{
    public static Jsonb ToJsonb<T>(this T value) where T : IdableEntity => new Jsonb()
    {
        Content = JsonConvert.SerializeObject(value),
        Type = typeof(T).FullName,
        Id = value.Id
    };

    public static T Deserialize<T>(this Jsonb value) => 
        JsonConvert.DeserializeObject<T>(value.Content);
}