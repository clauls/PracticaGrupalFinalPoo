using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGrupalPoo
{
    internal class FuncionalidadCliente
    {
        // Metodo para pagar en efectivo que recibe dos listas.
        // La primera, con los id introducidos a comprar (puede contener repetidos si hay mas de 1 unidad de un mismo producto).
        // la segunda, con los productos disponibles de la clase MaquinaVending para poder actualizar el stock.
        public static void PagarEfectivo(List<int> idsProductosPagar, List<Producto> productosDisponibles)
        {
            double totalAPagar = 0;
            // Recorremos la lista de los id introducidos a comprar acumulando el importe que debe posteriormente abonar en la variable totalAPagar.
            foreach (int id in idsProductosPagar)
            {
                Producto prod = productosDisponibles.Find(p => p.Id == id);
                totalAPagar = totalAPagar + prod.Precio;
            }

            double totalpagado = 0;
            Console.WriteLine($"Precio total: {totalAPagar}");
            // Seguimos pidiendo que inserte el dinero restante hasta que sea igual o superior al del producto.
            while (totalpagado < totalAPagar)
            {
                Console.WriteLine("Introduzca moneda: ");
                double moneda = Convert.ToDouble(Console.ReadLine());
                totalpagado += moneda;
                Console.WriteLine($"Total pagado: {totalpagado}");
            }

            // Cuando se finaliza el pago mostramos un mensaje y disminuimos la cantidad de unidades de productos que se hayan comprado.
            Console.WriteLine("Pago completado. Dispensando productos...");
            foreach (int id in idsProductosPagar)
            {
                Producto prod = productosDisponibles.Find(p => p.Id == id);
                prod.Unidades--;
            }
        }

        // Metodo para pagar con tarjeta que recibe dos listas.
        // La primera, con los id introducidos a comprar (puede contener repetidos si hay mas de 1 unidad de un mismo producto).
        // la segunda, con los productos disponibles de la clase MaquinaVending para poder actualizar el stock.
        public static void PagarTarjeta(List<int> idsProductosPagar, List<Producto> productosDisponibles)
        {
            double totalAPagar = 0;
            // Recorremos la lista de los id introducidos a comprar acumulando el importe que debe posteriormente abonar en la variable totalAPagar.
            foreach (int id in idsProductosPagar)
            {
                Producto prod = productosDisponibles.Find(p => p.Id == id);
                totalAPagar = totalAPagar + prod.Precio;
            }
            // Mostramos el precio que debe abonar.
            Console.WriteLine($"Precio total: {totalAPagar}");
            // Pedimos los datos de la tarjeta.
            Console.WriteLine("Introduzca el numero de la tarjeta:");
            string cardNumber = Console.ReadLine();
            Console.WriteLine("Introduzca la fecha de expiración (MM/YY):");
            string fechaExpiracion = Console.ReadLine();
            Console.WriteLine("Introduzca el CVV:");
            string CVV = Console.ReadLine();

            // Cuando se finaliza el pago, mostramos un mensaje y disminuimos la cantidad de unidades de productos que se hayan comprado.
            Console.WriteLine("Pago completado. Dispensando productos...");
            foreach (int id in idsProductosPagar)
            {
                Producto prod = productosDisponibles.Find(p => p.Id == id);
                prod.Unidades--;
            }
        }
    }
}