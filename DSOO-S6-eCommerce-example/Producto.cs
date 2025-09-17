using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_S6_eCommerce_example
{
    internal class Producto
    {
        private int id, cantidad;
        private string nombre;
        private double precioUnitario;

        public Producto(int id, string nombre, double precioUnitario, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioUnitario = precioUnitario;
            this.cantidad = cantidad;
        }
    }
}
