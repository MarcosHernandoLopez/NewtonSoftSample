using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextJSonSample
{
    class Cliente
    {
        public Cliente(Guid idCliente, string nombre, string apellidos, List<Vehiculo> vehiculos)
        {
            this.idCliente = idCliente;
            Nombre = nombre;
            Apellidos = apellidos;
            Vehiculos = vehiculos;
        }

        public Cliente(){}

        public Guid idCliente { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }

        public override string ToString()
        {
            return $"Id del cliente: {idCliente}.\nNombre: {Nombre}\nApellidos: {Apellidos}\nVehículos: {Vehiculos}";
        }

    }
}
