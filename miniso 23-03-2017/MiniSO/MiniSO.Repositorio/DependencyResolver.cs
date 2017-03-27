using MiniSO.Common;
using MiniSO.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Repositorio
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IRepositorio, RepositorioEF<MiniStackOModel>>();
            registerComponent.RegisterTypeWithControlledLifeTime<MiniStackOModel>();
        }
    }
}
