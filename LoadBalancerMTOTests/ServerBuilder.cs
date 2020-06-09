using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;
using LoadBalancerMTO;

namespace LoadBalancerMTOTests
{
    class ServerBuilder
    {
        private int Capacity;

        public Server Build()
        {
            return new Server() { Capacity = Capacity };
        }

        public ServerBuilder WithCapacity(int capacity)
        {
            this.Capacity = capacity;
            return this;
        }
    }
}
