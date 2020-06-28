using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploVehiculosMecanicos
{
    class Mecanico
    {
        private int id;

        public int Id { get { return this.id; } set { this.id = value; } }

        public Mecanico(int identificador)
        {
            this.Id = identificador;
        }
        public void operacion(Vehiculo vehiculo)
        {
            Console.WriteLine("El mecánico " + this.Id + " trabaja en el vehiculo " + vehiculo.Id);
        }

    }
}
