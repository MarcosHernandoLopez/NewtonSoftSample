using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextJSonSample
{
    internal class Program
    {
        public static async Task Serialize<T>(T obj, string path)
        {
            string jsonString = JsonSerializer.Serialize(obj);

            using FileStream createStream = File.Create(path);
            await JsonSerializer.SerializeAsync<T>(createStream, obj);
            await createStream.DisposeAsync();


            //File.WriteAllText(filePath, jsonString);
        }

        public static async Task<T> Deserialize<T>(string path)
        {
            using FileStream createStream = File.OpenRead(path);

            var obj = await JsonSerializer.DeserializeAsync<T>(createStream);

            return obj;
        }

        static async Task Main(string[] args)
        {
            var cl1 = new Cliente()
            {
                idCliente = Guid.NewGuid(),
                Nombre = "Marcos",
                Apellidos = "Hernando López",
            };

            cl1.Vehiculos = new List<Vehiculo>(
                   new[] {
                       new Vehiculo
                       {
                           idVehiculo = Guid.NewGuid(),
                           Matricula = "0000-AAA",
                           Modelo = "Mercedes",
                           color = Color.Azul,
                           cliente = cl1
                       },
                       new Vehiculo
                       {
                           idVehiculo = Guid.NewGuid(),
                           Matricula = "0000-BBB",
                           Modelo = "BMW",
                           color = Color.Rojo,
                           cliente = cl1
                       }
                   });

            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine(cl1);

            await Serialize(cl1, "./fichero.json");

            var deserialized = await Deserialize<Cliente>("./fichero.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
            Console.ReadLine();
        }
    }
}