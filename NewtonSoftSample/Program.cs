using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace NewtonSoftSample
{
    internal class Program
    {
        public static void Serialize<T>(T obj, string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }

        public static T Deserialize<T>(string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            {
                using (var reader = new JsonTextReader(sw))
                {
                    return serializer.Deserialize<T>(reader);
                }
            }
        }

        static void Main(string[] args)
        {
            var data = new DataStructure
            {
                Name = "Henry",
                Identifiers = new List<int> { 1, 2, 3, 4 }
            };
            var data1 = new DataStructure
            {
                Name = "Luis",
                Identifiers = new List<int> { 2, 3, 4, 5 }
            };
            var data2 = new DataStructure
            {
                Name = "Antonio",
                Identifiers = new List<int> { 3, 4, 5, 6 }
            };
            var data3 = new DataStructure
            {
                Name = "Manolo",
                Identifiers = new List<int> { 4, 5, 6, 7 }
            };

            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine(data);

            Console.WriteLine(data.Name);
            Console.WriteLine(data1.Name);
            Console.WriteLine(data2.Name);
            Console.WriteLine(data3.Name);

            Serialize(data, "./data.json");
            Serialize(data1, "./data1.json");
            Serialize(data2, "./data2.json");
            Serialize(data3, "./data3.json");

            var deserialized = Deserialize<DataStructure>("./data.json");
            var deserialized1 = Deserialize<DataStructure>("./data1.json");
            var deserialized2 = Deserialize<DataStructure>("./data2.json");
            var deserialized3 = Deserialize<DataStructure>("./data3.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
            Console.WriteLine(deserialized1);
            Console.WriteLine(deserialized2);
            Console.WriteLine(deserialized3);
            Console.WriteLine(deserialized.Name);
            Console.WriteLine(deserialized1.Name);
            Console.WriteLine(deserialized2.Name);
            Console.WriteLine(deserialized3.Name);

            var persona = new Persona
            {
                Name = "Henry",
                Age = 32
            };

            Serialize(persona, "./data2.json");

            var deserializedPersona = Deserialize<Persona>("./data2.json");

            Console.ReadLine();
        }
    }
}
