using Microsoft.Practices.Unity;
using MiniSO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Comando
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<Test>();
            
            ComponentLoader.LoadContainer(container, ".\\", "MiniSO.*.dll");
            var program = container.Resolve<Test>();
            program.init();
        }
    }
}
