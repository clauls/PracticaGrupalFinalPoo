using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGrupalPoo
{
    internal class MaquinaVending
    {
        // Atributos.
        // Declaramos una constante del numero de slots maximo que es 12.
        private static int SLOTS_MAXIMOS = 12;
        // Creamos una lista de productos.
        List<Producto> productos = new List<Producto>();

        // Constructor.
        public MaquinaVending()
        {
            productos = new List<Producto>();
        }
    
        // Metodo para añadir producto, al cual le pasamos por parametro el producto y posteriormente lo añadimos a la lista de productos.
        public void AddProducto(Producto producto)
        {
            productos.Add(producto);
        }

        // Metodo para mostrar los productos disponibles.
        public void MostrarProductosDisponibles()
        {
            // Recorremos la lista de productos y vamos mostrando la informacion basica de cada uno.
            foreach (Producto producto in productos)
            {
                producto.MostrarInfoBasica();
            }
        }
        public void ComprarProductos()
        {
            // Lista para almacenar los id de los productos seleccionados para comprar.
            List<int> idsProductosCesta = new List<int>();
            // Variable para controlar si el usuario sigue seleccionando productos.
            bool estoySeleccionandoProductos = true;

            // Bucle para permitir al usuario seleccionar productos hasta que decida salir.
            while (estoySeleccionandoProductos)
            {
                // Mostramos los productos disponibles para que el usuario elija.
                MostrarProductosDisponibles();
                Console.WriteLine("Introduzca el ID del producto que desee comprar:");
                // Leemos el ID del producto ingresado por el usuario.
                int idBuscar = int.Parse(Console.ReadLine());
                // Buscamos el producto en la lista de productos por su ID.
                Producto prod = productos.Find(p => p.Id == idBuscar);
                // Verificamos si el producto existe.
                if (prod == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                }
                else
                {
                    // Calculamos las unidades disponibles para el producto, restando las unidades del producto menos las que hemos añadido a la cesta de ese tipo.
                    int unidadesDisponibles = prod.Unidades - idsProductosCesta.FindAll(identificador => identificador == prod.Id).Count;
                    // Verificamos si hay unidades disponibles para agregar a la cesta.
                    if (unidadesDisponibles > 0)
                    {
                        // Agregamos el ID del producto a la cesta.
                        idsProductosCesta.Add(prod.Id);
                    }
                    else
                    {
                        Console.WriteLine("Ya no quedan unidades...");
                    }
                }

                // Preguntamos al usuario si desea elegir otro producto.
                Console.WriteLine("Desea elegir otro producto (Y/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "N")
                {
                    estoySeleccionandoProductos = false;
                }
            }

            // Solicitamos la forma de pago al usuario.
            Console.WriteLine("Introduzca su forma de pago: efectivo(E) / tarjeta(T)");
            string formapago = Console.ReadLine().ToUpper();
            // Procesamos el pago según la forma seleccionada.
            if (formapago == "E")
            {
                FuncionalidadCliente.PagarEfectivo(idsProductosCesta, productos);
            }
            else
            {
                FuncionalidadCliente.PagarTarjeta(idsProductosCesta, productos);
            }
        }

        // Método para mostrar la información de un producto específico.
        public void MostrarInformacionProducto()
        {
            // Mostramos los productos disponibles para que el usuario seleccione uno.
            MostrarProductosDisponibles();
            Console.WriteLine("Introduzca el ID del producto: ");
            // Leemos el ID del producto ingresado por el usuario.
            int idBuscar = int.Parse(Console.ReadLine());
            // Buscamos el producto en la lista de productos por su ID.
            Producto prod = productos.Find(p => p.Id == idBuscar);
            // Verificamos si el producto existe.
            if (prod == null)
            {
                Console.WriteLine("Producto no encontrado.");
            }
            else
            {
                // Mostramos la información del producto.
                prod.MostrarInformacion();
            }
        }

        // Método para realizar la carga individual de información de un producto.
        public void CargaIndividualProducto()
        {
            // Verificar si el acceso del administrador es válido.
            bool permitido = FuncionalidadAdmin.ComprobarAccesoAdmin();
            if (!permitido)
            {
                Console.WriteLine("Acceso erroneo.");
                return;
            }

            // Mostramos el menú de carga individual de productos.
            FuncionalidadAdmin.MostrarMenuCargaIndividual();
            Console.WriteLine("Introduzca opcion: ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                // Aumentamos las unidades de un producto existente.
                Console.WriteLine("Introduzca el ID del producto: ");
                int idBuscar = int.Parse(Console.ReadLine());
                Producto prod = productos.Find(p => p.Id == idBuscar);
                if (prod == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                }
                else
                {
                    // Solicitamos la cantidad de unidades a aumentar.
                    Console.WriteLine("Introduce el numero de unidades a aumentar: ");
                    int unidadesAumento = int.Parse(Console.ReadLine());
                    // Aumentamos las unidades del producto.
                    prod.Unidades = prod.Unidades + unidadesAumento;
                    Console.WriteLine("Unidades aumentadas.");
                }
            }
            else if (opcion == 2)
            {
                // Establecemos unidades a cero para un producto existente.
                Console.WriteLine("Introduzca el ID del producto: ");
                int idBuscar = int.Parse(Console.ReadLine());
                Producto prod = productos.Find(p => p.Id == idBuscar);
                if (prod == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                }
                else
                {
                    // Establecemos las unidades del producto a cero.
                    prod.Unidades = 0;
                    Console.WriteLine("Unidades establecidas a 0.");
                }
            }
            else if (opcion == 3)
            {
                // Agregamos un nuevo producto si hay espacio disponible en la máquina.
                if ((SLOTS_MAXIMOS - productos.Count) <= 0)
                {
                    Console.WriteLine("No hay espacio disponible en la maquina para agregar mas productos.");
                    return;
                }

                // Generamos el siguiente ID para el nuevo producto.
                int siguienteId = productos.Count == 0 ? 1 : productos.Last().Id + 1;
                // Cargamos la información del nuevo producto.
                Producto p = FuncionalidadAdmin.CargarProductoIndividual(siguienteId);
                if (p != null)
                {
                    // Agregamos el nuevo producto a la lista de productos.
                    AddProducto(p);
                }
            }
            else
            {
                Console.WriteLine("Opcion no contemplada...");
            }
        }

        // Método para realizar la carga completa de información de productos desde un archivo CSV.
        public void CargaCompletaProductos()
        {
            // Verificamos si el acceso del administrador es válido.
            bool permitido = FuncionalidadAdmin.ComprobarAccesoAdmin();
            if (!permitido)
            {
                Console.WriteLine("Acceso erroneo.");
                return;
            }

            // Solicitamos la ruta del archivo CSV al usuario.
            string rutaFichero = FuncionalidadAdmin.IntroducirRutaFicheroCSV();
            if (rutaFichero != null)
            {
                // Cargamos los productos desde el archivo CSV.
                List<Producto> productosCarga = FuncionalidadAdmin.CargarProductosDesdeCSV(rutaFichero);
                if (productosCarga.Count > SLOTS_MAXIMOS)
                {
                    Console.WriteLine($"Como máximo se pueden cargar más de {SLOTS_MAXIMOS} productos.");
                }
                else
                {
                    // Actualizamos la lista de productos con los productos cargados desde el archivo CSV.
                    productos = productosCarga;
                    Console.WriteLine("Productos cargados correctamente.");
                }
            }
        }

        // Método para salir del programa.
        public void Salir()
        {
            Console.WriteLine("Gracias por utilizar nuestros servicios.");
            Console.WriteLine("Vuelva pronto.");
        }
    }
}