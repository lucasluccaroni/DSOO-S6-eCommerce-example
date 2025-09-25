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

        // Constructor
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
                resultado = true;
            }
            return resultado;
        }

        // Registrar producto
        public bool registrarProducto(string nombre, double precioUnitario, int stockInicial)
        {
            bool resultado = false;

            // Chequeamos que el producto no exista para poder registrarlo
            Producto productoARegistrar = this.buscarProducto(nombre);
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

        // Listar productos
        public void listarProductos()
        {
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }
        }

        // Agregar un producto al carrito
        public string agregarProductoCarrito(string nombreProducto, int cantidad)
        {
            string resultado = "";
            string compraNoIniciada = "COMPRA_NO_INICIADA.";
            string productoInvalido = "PRODUCTO_INVÁLIDO";
            string noHayStock = "NO_HAY_STOCK";
            string agregarOk = "AGREGAR_OK.";
            Producto productoEnSistema;
            Producto productoParaCarrito;

            // 1. Chequeamos que la compra se haya iniciado (osea, que exista un carrito)
            if(carrito == null)
            {
                resultado = compraNoIniciada;
                return resultado;
            }

            // 2. Chequeamos que el producto exista
            productoEnSistema = buscarProducto(nombreProducto);
            if(productoEnSistema == null)
            {
                resultado = productoInvalido;
                return resultado;
            }

            // 3. Chequeamos que el producto tenga stock
            if (!productoEnSistema.consultaStock(cantidad))
            {
                resultado = noHayStock;
                return resultado;
            }

            // Creamos una instancia del producto que va a ir en el carrito
            productoParaCarrito = new Producto(productoEnSistema.Id,
                productoEnSistema.Nombre,
                productoEnSistema.PrecioUnitario,
                cantidad);
            
            // 4. Chequeamos si el producto ya forma parte de los items del carrito.
            // Si es asi, le sumamos la cantidad nueva al producto
            bool elProductoYaEstaEnCarrito = carrito.agregarCantidad(productoParaCarrito, cantidad);
            if (elProductoYaEstaEnCarrito)
            {
                resultado = agregarOk;
                return resultado;
            }

            // 5. La compra se inició, el producto existe, hay stock suficiente y el producto no esta en el carrito
            carrito.agregarProducto(productoParaCarrito);
            resultado = agregarOk;
            return resultado;
        }

        // Finalizar compra
        public bool finalizarCompra()
        {
            bool resultado = false;
            if (carrito == null || carrito.Items.Count == 0)
            {
                return resultado;
            }
            foreach (var item in carrito.Items)
            {
                Producto productoEnStock = productos.Find(p => p.Id == item.Id);
                if (productoEnStock != null)
                {
                    productoEnStock.Cantidad = productoEnStock.Cantidad - item.Cantidad;
                }
            }   
            carrito.finalizarCompra();
            return this.descartarCompra();
        }

        
        // Eliminar carrito / descartarCompra
        public bool descartarCompra()
        {
            if (carrito == null)
            {
                return false;
            }
            carrito = null;
            return true;
        }

        public void listarCarrito()
        {
            Console.WriteLine("\n--- LISTAR CARRITO ---");
            carrito.listarItems();
        }
    }
}
