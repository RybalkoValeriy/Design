using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.DI
{
    interface IService1 { void Doing1(); }

    class Service1 : IService1
    {
        public void Doing1()
        {
            throw new NotImplementedException();
        }
    }
    interface IService2 { void Doing2(); }

    class Service2 : IService2
    {
        public void Doing2()
        {
            throw new NotImplementedException();
        }
    }

    // it is consumer class for services
    class Consumer
    {
        private IService1 service1;
        private ServiceLocator serviceLocator = new ServiceLocator();
        public Consumer()
        {
            service1 = serviceLocator.GetService1(false);
        }
    }

    // it is class sources for services;
    class ServiceLocator
    {
        public IService1 GetService1(bool ItIsStub)
        {
            if (ItIsStub) 
                return new StubSrv1();

            return new Service1();
        }

        // same code for service2
    }

    // fake classes
    class StubSrv1 : IService1
    {
        public void Doing1()
        {
            throw new NotImplementedException();
        }
    }

    class StubSrv2 : IService2
    {
        public void Doing2()
        {
            throw new NotImplementedException();
        }
    }
}
