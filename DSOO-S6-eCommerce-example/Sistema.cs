using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_S6_eCommerce_example
{
    internal class Sistema
    {
        private string razonSocial;
        private int idUltimoCarrito;
        private int idUltimoProducto;
        private Carrito carrito;
        private List<Producto> productos;

        public Sistema(string razonSocial)
        {
            this.razonSocial = razonSocial;
            this.productos = new List<Producto>();
            this.idUltimoCarrito = 0;
            this.idUltimoProducto = 0;
        }
    public bool iniciarCompra(string dni)
        {
            bool resultado = false;
            if (carrito == null)
            {
                carrito = new Carrito(this.idUltimoCarrito++, dni);

            }



            return resultado;
        }

    }

}
