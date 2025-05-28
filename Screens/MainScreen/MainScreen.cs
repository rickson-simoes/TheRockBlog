using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.MainScreen
{
    public class MainScreen
    {
        public void Main()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("Please choose an option");
            Console.WriteLine("1 - Create an User");
            Console.WriteLine("=================================");
            var opt = Console.ReadLine();
            var readOpt = int.TryParse(opt, out int optSelected);

            if (readOpt || optSelected != 0)
            {
                switch(optSelected)
                {
                    case 1:
                        Console.WriteLine("Screen: Create an user");
                        // fazer a tela de usuario.
                        break;
                }

            }
        }
    }
}
