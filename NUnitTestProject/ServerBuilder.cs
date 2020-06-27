using LoadBalancerMTO;
using System;
using static LoadBalancerMTO.Server;

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
            AddInitVm(newborn);
            return newborn;
        }

        private void AddInitVm(Server newborn)
        {
            if (_initialLoad > 0)
            {
                int initialVmSize = (int)(_initialLoad * _capacity / MAXIMUM_LOAD);
                Vm initialVm = VmBuilder.Vm().OfSize(initialVmSize).Build();
                newborn.AddVm(initialVm);
            }
        }

        public static ServerBuilder Server() => new ServerBuilder();

        public ServerBuilder WithLoadOf(double initialLoad)
        {
            this._initialLoad = initialLoad;
            return this;
        }
    }
}