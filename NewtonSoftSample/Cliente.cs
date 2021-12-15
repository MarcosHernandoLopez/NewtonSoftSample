using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoftSample
{
    class Cliente
    {
        Guid idCliente { get; set; }
        String Nombre { get; set; }
        String Apellidos { get; set; }
        List<Vehiculo> Vehiculos { get; set; }

    }
}
