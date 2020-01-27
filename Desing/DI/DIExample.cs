using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.DI
{
    public class DIExample : IInjectionSomeServiceInterface
    {

        private ISomeService _someService;

        //1. in ctor
        public DIExample()
        {
            // default behavior
            this._someService = new ServiceReleasesDefault();
        }

        public DIExample(ISomeService someService)
        {
            this._someService = someService;
        }


        //2. in property/method
        public ISomeService Injection
        {
            get => this._someService ?? (this._someService = new ServiceReleasesDefault());

            set => this._someService = value;
        }

        //3. implement interface injection
        public void Inject(ISomeService service)
        {
            this._someService = service;
        }
        
        // 

    }



    // todo: adding Fabric_Method/FactoryInjection
}

