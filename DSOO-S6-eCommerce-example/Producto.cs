using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_S6_eCommerce_example
{
    internal class Producto
    {
        private static int contadorIdProducto = 0;
        private int id, cantidad;
        private string nombre;
        private double precioUnitario;

        public Producto(string nombre, double precioUnitario, int cantidad)
        {
            contadorIdProducto++;
            this.id = contadorIdProducto;
            this.nombre = nombre;
            PrecioUnitario = precioUnitario;
            this.cantidad = cantidad;
        }

        public Producto(int id, string nombre, double precioUnitario, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.PrecioUnitario = precioUnitario;
            this.Cantidad = cantidad;
        }
        
        public int Id
        {
            get { return this.id; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = verificadorCantidad(value); }
        }

        private int verificadorCantidad(int cantidad)
        {
            if(cantidad < 0)
            {
                cantidad = 0;
            }
            return cantidad;
        }

        public bool consultaStock(int cantidadRequerida)
        {
            return this.Cantidad >= cantidadRequerida;
        }
        
        public override string ToString()
        {
            return "Producto: " + Nombre + " || cantidad: " + Cantidad + " || precio unitario: $" + PrecioUnitario;
        }
    }
}
