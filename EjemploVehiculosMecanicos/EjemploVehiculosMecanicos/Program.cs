using System;

namespace EjemploVehiculosMecanicos
{
    class Program
    {
        static void Main(string[] args)
        {

            int numeroDeVehiculos = 20;
            int numeroDeMecanicos = 4;

            // A tener en cuenta que para que se vea como funciona la concurrencia hay console.write en el codigo
            // Si se pone un numero muy elevado de vehiculos y se pretende medir tiempos recomiendo quitarlo.
            // Es solo un ejemplo

            Vehiculo[] listaDeVehiculos = CrearListaDeVehiculos(numeroDeVehiculos);



            // * Solo un thread
            Master master = new Master(listaDeVehiculos, 1);
            DateTime before = DateTime.Now;
            master.TrabajarSobreVehiculos();
            DateTime after = DateTime.Now;
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);

            // * Varios thread y division equivalente
            master = new Master(listaDeVehiculos, numeroDeMecanicos);
            before = DateTime.Now;
            master.TrabajarSobreVehiculos();
            after = DateTime.Now;
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);




            listaDeVehiculos = CrearListaDeVehiculos(numeroDeVehiculos-1);
            // * Varios thread y division no equivalente
            master = new Master(listaDeVehiculos, numeroDeMecanicos);
            before = DateTime.Now;
            master.TrabajarSobreVehiculos();
            after = DateTime.Now;
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);


        }

        /// <summary>
        /// Crea una lista de vehiculos y le da como identificador a cada vehiculo su indice en la lista
        /// </summary>
        /// <param name="numeroDeVehiculos">El tamaño de la lista solicitada</param>
        /// <returns>La lista de vehiculos</returns>
        public static Vehiculo[] CrearListaDeVehiculos(int numeroDeVehiculos)
        {
            Vehiculo[] listaDeVehiculos = new Vehiculo[numeroDeVehiculos];
            Random random = new Random();
            for (int i = 0; i < numeroDeVehiculos; i++)
                listaDeVehiculos[i] = new Vehiculo(i);
            return listaDeVehiculos;
        }
    }
}
