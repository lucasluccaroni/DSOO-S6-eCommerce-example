using System;

namespace DSOO_S6_eCommerce_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema lacoste = new Sistema("Lacoste");

            
            Console.WriteLine("\n~~~~~~~~ Registro productos ~~~~~~~~");
            Console.WriteLine("--- Casos de éxito ---");
            lacoste.registrarProducto("Chomba", 150.20, 100);
            lacoste.registrarProducto("Pantalon", 200.20, 100);
            lacoste.registrarProducto("Zapatos", 350.10, 2);
            
            Console.WriteLine("\n--- Intento registrar un producto que ya existe ---");
            lacoste.registrarProducto("Chomba", 150.50, 100);

            Console.WriteLine("\n--- Intento registrar un producto con stock negativo ---");
            lacoste.registrarProducto("Buzo", 400.20, -10);


            Console.WriteLine("\n~~~~~~~~ Agregar producto al carrito ~~~~~~~~");

            Console.WriteLine("Intento fallido 1: La compra no fue inicada.");
            string intentoFallidoUno = lacoste.agregarProductoCarrito("Chomba", 10);
            Console.WriteLine(intentoFallidoUno);


            // Iniciamos la compra para el resto del algoritmo.
            lacoste.iniciarCompra("41723225");

            Console.WriteLine("\nIntento fallido 2: El producto no existe.");
            string intentoFallidoDos = lacoste.agregarProductoCarrito("Campera", 1);
            Console.WriteLine(intentoFallidoDos);

            Console.WriteLine("\nIntento fallido 3: No hay stock suficiente.");
            string intentoFallidoTres = lacoste.agregarProductoCarrito("Zapatos", 3);
            Console.WriteLine(intentoFallidoTres);

            Console.WriteLine("\nCaso exito 1: Producto agregado correctamente.");
            string casoExitoUno = lacoste.agregarProductoCarrito("Pantalon", 3);
            Console.WriteLine(casoExitoUno);

            //Console.WriteLine("\nCaso exito 2: Producto agregado correctamente.");
            //string casoExitoDos = lacoste.agregarProductoCarrito("Chomba", 1);
            //Console.WriteLine(casoExitoDos);

            //Console.WriteLine("\nCaso exito 2: Le agrego cantidad a un producto existente en el carrito.");
            //string casoExitoTres = lacoste.agregarProductoCarrito("Pantalon", 2);
            //Console.WriteLine(casoExitoTres);



            lacoste.listarCarrito();

            Console.WriteLine("\nCaso exito 2: Producto agregado correctamente.");
            string casoExitoDos = lacoste.agregarProductoCarrito("Chomba", 1);
            Console.WriteLine(casoExitoDos);


            lacoste.listarCarrito();

            Console.WriteLine("\n~~~~~~~~ Finalizar compra ~~~~~~~~");
            lacoste.finalizarCompra();
        }
    }
}
