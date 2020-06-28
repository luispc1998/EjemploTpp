
namespace EjemploVehiculosMecanicos {

    /// <summary>
    /// Computes the addition of the square values of part of a vector
    /// </summary>
    internal class Worker {

        /// <summary>
        /// La lista de vehiculos
        /// </summary>
        private Vehiculo[] listaDeVehiculos;

        /// <summary>
        /// Limites inferior y superior de la lista que especifican que vehiculos
        /// son manejados por el mecanico
        /// </summary>
        private int fromIndex, toIndex;


        /* En caso de que tuvieramos que devolver un valor a master lo podríamos hacer así
            /// <summary>
            /// Resultado de la operación
            /// </summary>
            private long result;
        

            internal long Result {
                get { return this.result; }
            }

        */

        /// <summary>
        /// El mecanico que tenemos en este nodo esclavo
        /// </summary>
        private Mecanico mecanico;


        internal Worker(Vehiculo[] vector, int idMecanico, int fromIndex, int toIndex) {
            this.listaDeVehiculos = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            this.mecanico = new Mecanico(idMecanico);
        }

        /// <summary>
        /// Method that computes the addition of the squares
        /// </summary>
        internal void Compute() {

            for (int i = this.fromIndex; i <= this.toIndex; i++)
                mecanico.operacion(this.listaDeVehiculos[i]);
        }

    }

}
