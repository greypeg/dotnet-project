using System.Text.Json.Serialization;

namespace dotnet_project.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusClass
    {
        TODO = 0,
        INPROGRESS = 1,
        INREVIEW = 2,
        DONE = 3
    }
}