using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace PracticaGrupalPoo
{
    internal class MaterialPrecioso : Producto
    {
        // Clase hija que hereda de la Superclase Producto.
        // Atributos propios.
        public string TipoMaterial { get; set; }
        public double Peso { get; set; }

        // Constructor.
        public MaterialPrecioso(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, double peso)
            : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            Peso = peso;
        }

        // Metodo sobreescrito que muestra la información detallada de la clase MaterialPrecioso.
        public override void MostrarInformacion()
        {
            Console.WriteLine($"MaterialPrecioso: Id: {Id}, nombre: {Nombre}, unidades: {Unidades}, PrecioUnitario: {Precio}, Descripcion: {Descripcion}, TipoMaterial: {TipoMaterial}, Peso (Gramos): {Peso}");
        }
    }
}
