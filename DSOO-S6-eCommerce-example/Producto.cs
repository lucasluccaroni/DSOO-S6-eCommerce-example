using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_S6_eCommerce_example
{
    internal class Producto
    {
        private static int contadorGlobal = 0;
        private int id, cantidad;
        private string nombre;
        private double precioUnitario;

        public Producto(string nombre, double precioUnitario, int cantidad)
        {
            contadorGlobal++;
            this.id = contadorGlobal;
            this.nombre = nombre;
            PrecioUnitario = precioUnitario;
            this.cantidad = cantidad;
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}
