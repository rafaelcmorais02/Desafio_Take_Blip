using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioTake.Repositories
{
    public class MyData
    {
        [JsonPropertyName("owner")]
        public AvatarRepository owner { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime Date{get; set;}
    }
}
