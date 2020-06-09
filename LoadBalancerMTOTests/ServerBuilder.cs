using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;
using LoadBalancerMTO;

namespace LoadBalancerMTOTests
{
    class ServerBuilder
    {
        private int _capacity;
        private double _load;

        private ServerBuilder() { }

        public Server Build()
        {
            Server newborn = new Server(_capacity);

            if(_load > 0 && _load < _capacity)
            {
                int vmSize = (int)Math.Ceiling(_load * _capacity);
                Vm existing = VmBuilder.Builder().WithSize(vmSize).Build();

                newborn.Install(existing);
            }

            return newborn;
        }

        public ServerBuilder WithCapacity(int capacity)
        {
            this._capacity = capacity;
            return this;
        }

        public ServerBuilder WithStartingLoad(double load)
        {
            this._load = load;
            return this;
        }

        public static ServerBuilder Builder()
        {
            return new ServerBuilder();
        }

    }
}
