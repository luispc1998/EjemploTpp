using System;
using System.Threading;


namespace EjemploVehiculosMecanicos {

    /// <summary>
    /// Distribuye los diversos vehiculos a los mecanicos
    /// </summary>
    public class Master {

        /// <summary>
        /// The vector whose modulus is going to be computed.
        /// </summary>
        private Vehiculo[] listaDeVehiculos;

        /// <summary>
        /// Numero de mecanicos, equivalente al numero de threads
        /// </summary>
        private int numeroDeMecanicos;

        public Master(Vehiculo[] vector, int numeroDeMecanicos) {
            if (numeroDeMecanicos < 1 || numeroDeMecanicos > vector.Length)
                throw new ArgumentException("Check para que no metan cosas tontas");

            this.listaDeVehiculos = vector;
            this.numeroDeMecanicos = numeroDeMecanicos;
        }

        /// <summary>
        /// Aquí damos la orden para que se realice la operación en cuestión
        /// </summary>
        /// Se sigue una aproximación en el codigo de ejemplo que consiste en dividir el trabajo en grupos seguidos
        ///  de vehiculos para los mecanicos. Dada una lista de 9 vehiculos para 
        public void TrabajarSobreVehiculos() {

            // * Creamos los esclavos, serían equivalente a los mecanicos. Desde el esclavo se podría llamar a un objeto mecanico
            // Eso ya depende de como queramos diseñar y delegar las resposabilidades.

            Worker[] workers = new Worker[this.numeroDeMecanicos];

            int elementsPerThread = this.listaDeVehiculos.Length/numeroDeMecanicos; // 9/4 = 2


            // Todos los esclavos van a tener el mismo numero de coches, menos el último que puede que tenga que trabajar más
            // Si suponemos 9 vehiculos y 4 mecanicos, todos trabajarían sobre 2 coches, menos el último que trajaría sobre 3
            for(int i=0; i < this.numeroDeMecanicos; i++)
                workers[i] = new Worker(this.listaDeVehiculos, i,
                    i*elementsPerThread, 
                    (i<this.numeroDeMecanicos-1) ? (i+1)*elementsPerThread-1: this.listaDeVehiculos.Length-1 // last one
                    );


            // * Threads are concurrently started
            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); // Creamos los threads
                threads[i].Name = "Mecanico: " + (i+1); // we name then (optional)
                threads[i].Priority = ThreadPriority.Normal; // we assign them a priority (optional)
                threads[i].Start();   // Que empiecen a trabajar
            }
            // Esperamos a que terminen todos los threads
            foreach (Thread thread in threads)
                thread.Join();


            // Si tuvieran que devolver algo deberíamos encargarnos aquí, pero para este pequeño ejemplo no parece que haga falta.

            /* Este es un ejemplo en caso de que computasen un modulo. Es importante que el valor resultante del esclavo quede en una propiedad 
             * accesible desde el master
                long result = 0;
                foreach (Worker worker in workers)
                    result += worker.Result;
                return Math.Sqrt(result);

            */
        }

    }

}
