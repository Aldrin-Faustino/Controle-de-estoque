using System;

namespace Controle_de_estoque_core
{
    class Program
    {
        public static void Main (string[] args)
        {
            InterfaceDeControle menu = new InterfaceDeControle ();

            menu.Menu();

        }
    }
}