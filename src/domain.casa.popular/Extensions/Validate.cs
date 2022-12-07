namespace domain.casa.popular.Extensions
{
    using Newtonsoft.Json.Linq;

    public static class Validate
    {
        public static bool HasError(this JObject json)
            => json["error"] != null;
    }
}
