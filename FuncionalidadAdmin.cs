using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticaGrupalPoo
{
    internal class FuncionalidadAdmin
    {
        // Todos los metodos son static porque no necesitamos instanciar el objeto.
        public static string IntroducirRutaFicheroCSV()
        {
            // Pedimos la ruta absoluta del fichero y la devolvemos como string.
            Console.WriteLine("Introduzca la ruta del fichero csv a cargar: ");
            // Guardamos la ruta y la devolvemos.
            string ruta = Console.ReadLine();
            return ruta;
        }

        // Metodo para cargar un nuevo producto.
        // Le pasamos el siguienteId calculado y nos devuelve un producto dependiendo del tipo que seleccione.
        public static Producto CargarProductoIndividual(int siguienteId)
        {
            // Pedimos la informacion general del producto.
            Console.WriteLine("Ingrese los detalles del nuevo producto:");
            Console.WriteLine("Introduzca el nombre del producto");
            string nombre = Console.ReadLine();
            Console.WriteLine("Introduzca las unidades disponibles:");
            int unidades = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca el precio unitario:");
            double precioUnitario = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Introduzca la descripcion: ");
            string descripcion = Console.ReadLine();
            Console.WriteLine("Tipo de producto (1: Material precioso, 2: Producto alimenticio, 3:Producto electronico:");
            int tipo = int.Parse(Console.ReadLine());

            Producto producto = null;

            switch(tipo)
            {
                case 1:
                    // Pedimos la informacion especifica de los materiales preciosos.
                    Console.WriteLine("Tipo de material:");
                    string tipoMaterial = Console.ReadLine();
                    Console.WriteLine("Peso en gramos:");
                    double gramos = double.Parse(Console.ReadLine());
                    // Instanciamos un material precioso con las atributos introducidos.
                    producto = new MaterialPrecioso(siguienteId, nombre, unidades, precioUnitario, descripcion, tipoMaterial, gramos);
                    break;

                case 2:
                    // Pedimos la informacion especifica de los productos alimenticios.
                    Console.WriteLine("Informacion nutricional:");
                    string infoNutricional = Console.ReadLine();
                    // Instanciamos un producto alimenticio con las atributos introducidos.
                    producto = new ProductoAlimenticio(siguienteId, nombre, unidades, precioUnitario, descripcion, infoNutricional);
                    break;

                case 3:
                    // Pedimos la informacion especifica de los productos electronicos.
                    Console.WriteLine("Tipo de materiales:");
                    string tipoMateriales = Console.ReadLine();
                    Console.WriteLine("Incluye pilas (1/0):");
                    bool incluyePilas = Convert.ToBoolean(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Precargado (1/0):");
                    bool precargado = Convert.ToBoolean(int.Parse(Console.ReadLine()));
                    // Instanciamos un producto electronico con las atributos introducidos.
                    producto = new ProductoElectronico(siguienteId, nombre, unidades, precioUnitario, descripcion, tipoMateriales, incluyePilas, precargado);
                    break;
            }
            // Devolvemos el producto dependiendo del tipo que haya seleccionado.  
            return producto;
        }

        // Metodo para cargar propductos desde un CSV.
        // Le pasamos la ruta del fichero absoluto y os devuelve un listado de productos leidos de un CSV .
        public static List<Producto> CargarProductosDesdeCSV(string rutaFichero)
        {
            List<Producto> productos = new List<Producto>();

            int id = 1;

            try
            {
                // Utilizamos el StreamReader para leer el archivo CSV.
                string path = @"" + rutaFichero;
                using (StreamReader reader = new StreamReader(path))
                {
                    // Obviamos la linea de cabeceras en el CSV.
                    reader.ReadLine(); 
                    // Leemos cada linea del archivo hasta el final de este.
                    while (!reader.EndOfStream)
                    {
                        // Al leer una linea del archivo la dividimos en campos usando el ";" como delimitador.
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            string[] values = line.Split(';');

                            // guardamos los valores de cada campo.
                            int tipoProducto = Convert.ToInt32(values[0]);
                            string nombreProducto = values[1];
                            int unidadesProducto = Convert.ToInt32(values[2]);
                            double precioUnitarioProducto = Convert.ToDouble(values[3]);
                            string descripcionProducto = values[4];
                            string materiales = values[5];

                            Producto producto = null;

                            switch (tipoProducto)
                            {
                                case 1: // MaterialPrecioso.
                                    string numericPartPeso = Regex.Replace(values[6], @"[^\d]", "");
                                    double peso = Convert.ToDouble(numericPartPeso);
                                    producto = new MaterialPrecioso(id, nombreProducto, unidadesProducto, precioUnitarioProducto, descripcionProducto, materiales, peso);
                                    break;
                                case 2: // ProductoAlimenticio.
                                    string informacionNutricional = values[7];
                                    producto = new ProductoAlimenticio(id, nombreProducto, unidadesProducto, precioUnitarioProducto, descripcionProducto, informacionNutricional);
                                    break;
                                case 3: // ProductoElectronico.
                                    bool incluyePilas = Convert.ToBoolean(Convert.ToInt32(values[8]));
                                    bool precargado = Convert.ToBoolean((Convert.ToInt32(values[9])));
                                    producto = new ProductoElectronico(id, nombreProducto, unidadesProducto, precioUnitarioProducto, descripcionProducto, materiales, incluyePilas, precargado);
                                    break;
                            }
                            // Añadimos el producto a la lista si es distinto de nulo.
                            if (producto != null)
                            {
                                productos.Add(producto);
                                id++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al cargar productos desde el archivo CSV: {ex.Message}.");
            }
            // Devolvemos la lista de productos cargados del CSV.
            return productos;
        }

        // Metodo donde pedimos una password y comprobamos que sea admin1234.
        public static bool ComprobarAccesoAdmin()
        {
            Console.WriteLine("Introduzca la password de admin: ");

            string passwordLeida = Console.ReadLine();
            return passwordLeida == "admin1234";
        }

        // SubMenu especifico del menu de carga individual.
        public static void MostrarMenuCargaIndividual()
        {
            Console.WriteLine("1. Aumentar unidades de un producto existente. ");
            Console.WriteLine("2. Poner las unidades a 0 de un producto existente. ");
            Console.WriteLine("3. Agregar producto nuevo. ");
            Console.WriteLine();
        }
    }
}
