using System;

namespace ordenamiento
{
    class Program
    {
        public static int[] OrdenarBurbuja(int[] pVector)
        {
            int t = pVector.Length, temp;

            for (int i = 1; i < t; i++)
                for (int j = t - 1; j >= i; j--)
                {
                    if (pVector[j] < pVector[j - 1])
                    {
                        temp = pVector[j];
                        pVector[j] = pVector[j - 1];
                        pVector[j - 1] = temp;
                    }
                }

            return pVector;
        }

        public static int[] OrdenarPorInsercion(int[] pVector)
        {
            for (int i = 1; i < pVector.Length; i++)
            {
                int key = pVector[i];                  // 1
                int j = i - 1;

                while (j >= 0 && pVector[j] > key)     // 2
                {
                    //loop
                    pVector[j + 1] = pVector[j];        // 3
                    j--;
                }

                pVector[j + 1] = key;                  // 4
            }

            return pVector;
        }

        public static int[] OrdenarPorSeleccion(int[] pVector)
        {
            int i, j, pos_min;
            int i_aux;

            for (i = 0; i < pVector.Length - 1; i++)
            {
                pos_min = i;

                for (j = i + 1; j < pVector.Length; j++)
                    if (pVector[j] < pVector[pos_min])  // 1
                        pos_min = j;

                if (pos_min != i)
                {
                    i_aux = pVector[i];           // 2
                    pVector[i] = pVector[pos_min];      // 3
                    pVector[pos_min] = i_aux;     // 4
                }
            }

            return pVector;
        }

        public static void swap(int[] pVector, int i, int j)
        {
            int auxIntercambio;

            auxIntercambio = pVector[i];
            pVector[i] = pVector[j];
            pVector[j] = auxIntercambio;
        }

        public static void quicksortV5(int[] vector, int izquierdo, int derecho)
        {
            if (izquierdo >= derecho)
                return;

            int k = particionarV5(vector, izquierdo, derecho);

            quicksortV5(vector, izquierdo, k - 1);
            quicksortV5(vector, k + 1, derecho);
        }

        public static int particionarV5(int[] vector, int izquierda, int derecha)
        {
            //int idxPivote = izquierda + (derecha - izquierda) / 2;
            //int idxPivote = izquierda;
            int idxPivote = mediana(vector, izquierda, izquierda + (derecha - izquierda) / 2, derecha);
            //int idxPivote = derecha;
            int pivote = vector[idxPivote];
            int i = izquierda;
            int k = derecha;

            Console.WriteLine("");
            Console.WriteLine(" __________________________________________");
            Console.WriteLine("|    Entrando a la funcion Particionar     | ");
            Console.WriteLine("|__________________________________________|");
            Console.WriteLine("");

            Console.WriteLine("    IZQ: {0}    DER: {1}    i: {2}    k: {3}    idxPivote: {4}    PIVOTE: {5}",
                izquierda, derecha, i, k, idxPivote, pivote);
            Console.WriteLine("");
            Console.WriteLine("        " + String.Join(" ; ", vector));
            Console.WriteLine("");


            while (i < k && i <= derecha)
            {
                while (vector[i] < pivote   && i < k)
                    i++;

                while (vector[k] > pivote)
                    k--;

                if (i < k)
                    swap(vector, i, k);
            }

            if ((vector[k] > vector[idxPivote] && k < idxPivote) || (vector[k] < vector[idxPivote] && k > idxPivote))   //  add
                swap(vector, idxPivote, k);

            Console.WriteLine("    antes de salir de la funcion ... return k  = {0};", k);
            Console.WriteLine("");
            Console.WriteLine("        " + String.Join(" ; ", vector));

            return k;
        }

        private static int mediana(int[] vector, int idxA, int idxB, int idxC)
        {
            if ((vector[idxA] > vector[idxB] && vector[idxB] > vector[idxC]) || (vector[idxA] < vector[idxB] && vector[idxB] < vector[idxC]) )
                return idxB;
            else if ((vector[idxB] > vector[idxA] && vector[idxA] > vector[idxC]) ||(vector[idxB] < vector[idxA] && vector[idxA] < vector[idxC]))
                return idxA;
            else
                return idxC;
        }

        static void Main(string[] args)
        {
            //int[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] vector = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            int[] vector = { 20, 52, 45, 35, 15, 80, 76, 25 };


            Console.WriteLine();

            quicksortV5(vector, 0, vector.Length - 1);

            Console.WriteLine("");
            Console.WriteLine("    Vector Ordenado -> " + String.Join(" ; ", vector));
        }
    }
}
