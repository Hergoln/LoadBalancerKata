﻿using LoadBalancerMTO;

namespace Tests
{
    public class VmBuilder : IBuilder<Vm>
    {
        private int _size;

        public VmBuilder OfSize(int size)
        {
            this._size = size;
            return this;
        }

        public Vm Build()
        {
            return new Vm() { Size = _size };
        }

        public static VmBuilder Vm() => new VmBuilder();
    }
}