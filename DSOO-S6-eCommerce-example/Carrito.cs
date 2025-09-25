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

        public List<Producto> Items
        {
            get { return this.items; }
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
            Console.WriteLine(producto);
        }

        // Buscar producto en carrito
        public bool agregarCantidad(Producto producto, int cantidad)
        {
            bool resultado = false;
            Producto productoBuscado = items.Find(p => p.Id == producto.Id);
            if(productoBuscado != null)
            {
                productoBuscado.Cantidad += cantidad;
                resultado = true;
            }
            return resultado;
        }

        public void finalizarCompra()
        {
            double montoTotal = 0;
            this.listarItems();
            foreach(var item in items)
            {

                montoTotal = montoTotal + (item.PrecioUnitario * item.Cantidad);
            }
            Console.WriteLine("El monto total a pagar es: $" + montoTotal);
        }
    }
}
