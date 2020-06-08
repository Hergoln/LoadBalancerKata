using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoadBalancerMTO
{
    class ServerBuilder
    {
        private double Capacity;

        public Server Build()
        {
            return new Server() { Capacity = Capacity };
        }

        public ServerBuilder WithCapacity(double capacity)
        {
            this.Capacity = capacity;
            return this;
        }
    }
}
