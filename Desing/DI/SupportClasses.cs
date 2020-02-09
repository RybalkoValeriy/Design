using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.DI
{
    public interface ISomeService
    {

    }
    
    public class ServiceReleasesDefault : ISomeService 
    {

    }
    
    public class ServiceReleasesMock : ISomeService 
    {

    }

    public interface IInjectionSomeServiceInterface
    {
        void Inject(ISomeService service);
    }

    public class FabricMethod
    {
        public virtual ISomeService Create()
        {
            return new ServiceReleasesDefault();
        }
    }

    public class FabricMock : FabricMethod
    {
        public override ISomeService Create()
        {
            return new ServiceReleasesMock();
        }
    }

}
