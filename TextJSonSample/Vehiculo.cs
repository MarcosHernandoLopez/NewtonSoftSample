using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextJSonSample
{
    class Vehiculo
    {
        public Vehiculo(Guid idVehiculo, string matricula, string modelo, Color color, Cliente cliente)
        {
            this.idVehiculo = idVehiculo;
            Matricula = matricula;
            Modelo = modelo;
            this.color = color;
            this.cliente = cliente;
        }

        public Vehiculo() { }


        public Guid idVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public Color color { get; set; }

        [JsonIgnore]
        public Cliente cliente { get; set; }

        public override string ToString()
        {
            return $"Id del vehículo: {idVehiculo}.\nMatrícula del vehículo: {Matricula}.\nModelo del vehículo: {Modelo}.\nColor del vehículo: {color}";
        }
    }
}
