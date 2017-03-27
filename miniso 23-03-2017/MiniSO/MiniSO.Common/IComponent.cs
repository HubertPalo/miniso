using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSO.Common
{
    public interface IComponent
    {
        void SetUp(IRegisterComponent registerComponent);
    }
}
