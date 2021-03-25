using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace RestAPI.Domain
{
    [CosmosCollection("Posts")]
    public class CosmosPostDto
    {
        [CosmosPartitionKey]
        [JsonProperty("Id")]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
