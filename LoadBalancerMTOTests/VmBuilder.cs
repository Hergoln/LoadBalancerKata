using System;
using System.Collections.Generic;
using System.Text;
using LoadBalancerMTO;

namespace LoadBalancerMTOTests
{
    class VmBuilder
    {
        private int Size;

        private VmBuilder() { }

        public static VmBuilder Builder()
        {
            return new VmBuilder();
        }

        public VmBuilder WithSize(int size)
        {
            this.Size = size;
            return this;
        }

        public Vm Build()
        {
            return new Vm(this.Size);
        }
    }
}
