using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DemoApp
{
    public class Beatle
    {
        public string? Name { get; set; }
        public string? Instrument { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var readFile = File.ReadAllText("C:\\Users\\bream\\source\\repos\\arraysDemo\\json1.json");
            var readJson = JsonNode.Parse(readFile).AsArray().ToArray();

            Beatle[] beatles = new Beatle[readJson.Length];
            int index = 0;
            foreach (var j in readJson)
            {
                var member = JsonSerializer.Deserialize<Beatle>(j);
                Beatle beatle = new Beatle
                {
                    Name = member.Name,
                    Instrument = member.Instrument,
                };
                beatles[index] = beatle;
                index++;
            }

            Beatle newBeatle = new Beatle
            {
                Name = "George",
                Instrument = "Guitar",
            };
            
            Array.Resize(ref beatles, beatles.Length + 1);
            beatles[beatles.Length - 1] = newBeatle;

            string jsonString = JsonSerializer.Serialize(beatles);

            File.WriteAllText("C:\\Users\\bream\\source\\repos\\arraysDemo\\json1.json", jsonString);
           
            Console.ReadLine();
        }
    }
}