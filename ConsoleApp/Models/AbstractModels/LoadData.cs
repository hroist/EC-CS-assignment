using Newtonsoft.Json;

namespace ConsoleApp.Models.AbstractModels
{
    internal abstract class LoadData
    {
        [JsonProperty("contacts")]
        public List<LoadData> Contacts { get; set; } = null!;
    }
}
