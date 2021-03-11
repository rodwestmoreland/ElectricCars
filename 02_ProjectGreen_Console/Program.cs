using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProjectGreen_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            Console.Title = "Komodo: Propulsion Type Statistics";
            ui.Run();
        }
    }
}
