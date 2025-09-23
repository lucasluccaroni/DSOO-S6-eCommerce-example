using System;
using System.Collections.Generic;
using System.Text;

namespace DSOO_S6_eCommerce_example
{
    internal class Sistema
    {
        private static int contadorIdCarrito = 0;
        private string razonSocial;
        private Carrito carrito;
        private List<Producto> productos;

        public Sistema(string razonSocial)
        {
            contadorIdCarrito++;
            this.razonSocial = razonSocial;
            this.productos = new List<Producto>();
        }
        // Iniciar compra
        public bool iniciarCompra(string dni)
        {
            bool resultado = false;
            if (carrito == null)
            {
                carrito = new Carrito(contadorIdCarrito, dni);
            }

            return resultado;
        }

        // Registrar producto
        public bool registrarProducto(string nombre, double precioUnitario, int stockInicial)
        {
            bool resultado = false;

            // Chequeamos que el producto no exista para poder registrarlo
            Producto productoARegistrar = buscarProducto(nombre);
            if (productoARegistrar != null)
            {
                Console.WriteLine("EL PRODUCTO YA SE ENCUENTRA REGISTRADO.");
                return resultado;
            }

            // Si el producto no existe, verificamos que la cantidad que se desa registrar sea valida
            if (stockInicial >= 0)
            {
                // Si esta todo bien, registramos el producto y lo agregamos a la lista de productos del sistema
                productoARegistrar = new Producto(nombre, precioUnitario, stockInicial);
                productos.Add(productoARegistrar);
                resultado = true;
                Console.WriteLine("PRODUCTO REGISTRADO CORRECTAMENTE.");
                return resultado;
            }

            Console.WriteLine("EL STOCK INGRESADO ES NEGATIVO.");
            return resultado;
        }


        // Buscar producto
        public Producto buscarProducto(string nombre)
        {
            Producto productoBuscado = productos.Find(p => p.Nombre == nombre);
            return productoBuscado;
        }

        // Agregar un producto al carrito
        public string agregarProductoCarrito(string nombreProducto, int cantidad)
        {
            string resultado = "";
            string compraNoIniciada = "COMPRA_NO_INICIADA.";
            string productoInvalido = "PRODUCTO_INVÁLIDO";
            string noHayStock = "NO_HAY_STOCK";
            string agregarOk = "AGREGAR_OK.";
            Producto producto;

            // 1. Chequeamos que la compra se haya iniciado (osea, que exista un carrito)
            if(carrito == null)
            {
                resultado = compraNoIniciada;
                return resultado;
            }

            // 2. Chequeamos que el producto exista
            producto = buscarProducto(nombreProducto);
            if(producto == null)
            {
                resultado = productoInvalido;
                return resultado;
            }

            // 3. Chequeamos que el producto tenga stock
            if (!producto.consultaStock(cantidad))
            {
                resultado = noHayStock;
                return resultado;
            }

            // 4. La compra se inició, el producto existe y hay stock suficiente
            // Agregamos el producto a la lista de carrito
            carrito.agregarProducto(producto);
            resultado = agregarOk;
            return resultado;
        }

        // Finalizar compra


        //Descartar compra
        public bool descartarCompra()
        {
            if (carrito == null)
            {
                return false;
            }
            carrito = null;
            return true;
        }
    }

}
