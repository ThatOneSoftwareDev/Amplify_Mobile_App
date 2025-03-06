using System.Text.Json.Serialization;

namespace MonkeyFinderHybrid.Model;

public class Monkey
{
    //create all properties for monkey class then make sure the compiler dosen't complain by setting the default to an empty sting
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

[JsonSerializable(typeof(List<Monkey>))]
internal sealed partial class MonkeyContext : JsonSerializerContext
{

}
