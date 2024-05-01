using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGrupalPoo
{
    internal class ProductoElectronico : Producto
    {
        // Clase hija que hereda de la Superclase Producto.
        // Atributos propios.
        public String? TipoMaterialesUtilizados { get; set; }
        public bool IncluyePilas { get; set; }
        public bool Precargado { get; set; }

        // Constructor.
        public ProductoElectronico(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterialesUtilizados, bool incluyePilas, bool precargado)
            : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterialesUtilizados = tipoMaterialesUtilizados;
            IncluyePilas = incluyePilas;
            Precargado = precargado;
        }

        // Metodo sobreescrito que muestra la información detallada de la clase ProductoElectronico.
        public override void MostrarInformacion()
        {
            Console.WriteLine($"ProductoElectronico: Id: {Id}, nombre: {Nombre}, unidades: {Unidades}, PrecioUnitario: {Precio}, Descripcion: {Descripcion}, TipoMaterialesUtilizados: {TipoMaterialesUtilizados}, IncluyePilas: {IncluyePilas}, Precargado: {Precargado}");
        }
    }
}

