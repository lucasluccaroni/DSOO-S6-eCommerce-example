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
    }
}
