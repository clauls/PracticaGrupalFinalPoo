using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGrupalPoo
{
    internal class ProductoAlimenticio : Producto
    {
        // Clase hija que hereda de la Superclase Producto.
        // Atributo propio.
        public String InformacionNutricional { get; set; }

        // Constructor.
        public ProductoAlimenticio(int id, string nombre, int unidades, double precioUnitario, string descripcion, string informacionNutricional)
            : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            InformacionNutricional = informacionNutricional;
        }

        // Metodo sobreescrito que muestra la información detallada de la clase ProductoAlimenticio.
        public override void MostrarInformacion()
        {
            Console.WriteLine($"ProductoAlimenticio: Id: {Id}, nombre: {Nombre}, unidades: {Unidades}, PrecioUnitario: {Precio}, Descripcion: {Descripcion}, InformacionNutricional: {InformacionNutricional}");
        }
    }
}