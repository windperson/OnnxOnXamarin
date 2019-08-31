using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnnxOnXamarin.DependencyServices
{
    public interface IShuttleAutoLand
    {
        Task<bool> CanUseAutoLanding(int inputSTABILITY, int inputERROR, int inputSIGN, int inputWIND, int inputMAGNITUDE, int inputVISIBILITY);
    }
}
