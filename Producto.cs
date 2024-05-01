using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGrupalPoo
{
        public abstract class Producto
        {
            // Clase abstracta de la que heredan ProductoAlimenticio, ProductoElectronico y MaterialPrecioso.
            // Atributos.
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Unidades { get; set; }
            public double Precio { get; set; }
            public string Descripcion { get; set; }

            // Constructor.
            public Producto(int id, string nombre, int unidades, double precio, string descripcion)
            {
                Id = id;
                Nombre = nombre;
                Unidades = unidades;
                Precio = precio;
                Descripcion = descripcion;
            }

            // Metodos.
            // Metodo para mostar la información basica que tienen todos los productos.
            public void MostrarInfoBasica()
            {
                Console.WriteLine($"Id: {Id}, nombre: {Nombre}, unidades: {Unidades}, PrecioUnitario: {Precio}, Descripcion: {Descripcion}");
            }

            // Metodo abstracto implementado en las clases hijas para mostar la informacion detallada, dependiendo del tipo de producto que sea.
            public abstract void MostrarInformacion();
        }
}