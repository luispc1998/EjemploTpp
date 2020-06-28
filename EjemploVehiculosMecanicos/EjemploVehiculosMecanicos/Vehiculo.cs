using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploVehiculosMecanicos
{
    public class Vehiculo
    {

        private int id;

        public int Id { get { return this.id; } set { this.id = value; } }

        public Vehiculo(int identificador)
        {
            this.Id = identificador;
        }
    }
}
