using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGrupalPoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos una maquina vending.
            MaquinaVending maquinaVending = new MaquinaVending();

            // Menu principal con las distintas opciones.
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Selccione la opcion que desee: ");
                Console.WriteLine("1. Comprar producto");
                Console.WriteLine("2. Mostrar información del producto");
                Console.WriteLine("3. Carga individual de productos");
                Console.WriteLine("4. Carga completa de productos ");
                Console.WriteLine("5. Salir");

                try
                {   
                    string opcionTeclado = Console.ReadLine();
                    if (opcionTeclado != null)
                    {
                        opcion = int.Parse(opcionTeclado);
                    }

                    switch (opcion)
                    {
                        case 1: // Comprar productos.
                            maquinaVending.ComprarProductos();
                            break;

                        case 2: // Mostrar información del producto.
                            maquinaVending.MostrarInformacionProducto();
                            break;
                        case 3: // Carga individual de productos (Admin).
                            maquinaVending.CargaIndividualProducto();
                            break;

                        case 4: // Carga completa de productos (Admin).
                            maquinaVending.CargaCompletaProductos();
                            break;
                        case 5: // Salir.
                            maquinaVending.Salir();
                            break;

                        default: // Si ha introducido un entero pero no valido.
                            Console.WriteLine("Error: Opcion no valida.");
                            Console.WriteLine("Por favor, ingrese un numero valido.");
                            break;
                    }
                }
                catch (FormatException) // Ocurre si no ha introducido un numero.
                {
                    Console.WriteLine("Error: Opcion no valida. ");
                    Console.WriteLine("Por favor, ingrese un numero valido.");
                }

                Console.WriteLine("Pulse una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 5);
        }
    }
}