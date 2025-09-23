using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_S6_eCommerce_example
{
    internal class Carrito
    {
        
        private int id;
        private string dni;
        private List<Producto> items;

        public Carrito(int id, string dni)
        {
            this.id = id;
            this.dni = dni;
            items = new List<Producto>();
        }

        public void listarItems()
        {
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void agregarProducto(Producto producto)
        {
            items.Add(producto);
        }

        public void finalizarCompra()
        {
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
