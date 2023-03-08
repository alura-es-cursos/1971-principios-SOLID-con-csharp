using System;

namespace Alura.SubastaOnline.CLI
{
    class Program
    {
        private static void MostrarComandos()
        {
            Console.WriteLine("\nComandos disponibles\n");
            Console.WriteLine("  listar - lista de las subastas registradas");
            Console.WriteLine("  detalle <Id de la subasta> - mostrar los detalles de la subasta identificada por <Id de la subasta>");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("subasta-adm - v1.0");
            Console.WriteLine("=================");
            Console.WriteLine("Interface de linea de comando para administración de subastas");

            if (args.Length == 0)
            {
                MostrarComandos();
                return;
            } else if (args[0] == "listar")
            {
                // listar subastas
                

            } else if (args[0] == "detalhe")
            {
                // detalle de la subasta

            }
        }
    }
}
