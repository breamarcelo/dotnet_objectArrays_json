using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BeatlesMembersJson
{
    // Object constructor
    public class Beatle
    {
        public string? Name { get; set; }
        public string? Instrument { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Read the existing JSON file and parse as C# Array
            var readFile = File.ReadAllText("C:\\Users\\bream\\source\\repos\\arraysDemo\\json1.json");
            var readJson = JsonNode.Parse(readFile).AsArray().ToArray();

            // Create a new Array where the read data will be stored
            Beatle[] beatles = new Beatle[readJson.Length];
            int index = 0;
            foreach (var j in readJson)
            {
                // Deserialize each Object from the JSON array and append it to the new array
                var member = JsonSerializer.Deserialize<Beatle>(j);
                beatles[index] = member;
                index++;
            }

            // Create a new Object
            Beatle newBeatle = new Beatle
            {
                Name = "George",
                Instrument = "Guitar",
            };
            
            // Resize and append new Object to the new Array
            Array.Resize(ref beatles, beatles.Length + 1);
            beatles[beatles.Length - 1] = newBeatle;

            // Serialize the new Array and re-write the JSON file
            string jsonString = JsonSerializer.Serialize(beatles);
            File.WriteAllText("C:\\Users\\bream\\source\\repos\\arraysDemo\\json1.json", jsonString);
           
        }
    }
}