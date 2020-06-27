using LoadBalancerMTO;
using System;

namespace Tests
{
    public class ServerBuilder : IBuilder<Server>
    {
        private int _capacity;
        private double _initialLoad;

        public ServerBuilder WithCapacity(int capacity)
        {
            this._capacity = capacity;
            return this;
        }

        public Server Build()
        {
            Server newborn = new Server(_capacity);

            if(_initialLoad > 0)
            {
                int initialVmSize = (int)( _initialLoad * _capacity / 100.0d );
                Vm initialVm = VmBuilder.Vm().OfSize(initialVmSize).Build();
                newborn.AddVm(initialVm);
            }

            return newborn;
        }

        public static ServerBuilder Server() => new ServerBuilder();

        public ServerBuilder WithLoadOf(double initialLoad)
        {
            this._initialLoad = initialLoad;
            return this;
        }
    }
}