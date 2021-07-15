using System.Text.Json.Serialization;

namespace DesafioTake.Repositories
{
    public class AvatarRepository
    {
        [JsonPropertyName("avatar_url")]
        public string Avatar_url { get; set; }
    }
}
