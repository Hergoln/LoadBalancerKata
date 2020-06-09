using System;
using System.Collections.Generic;
using System.Text;

namespace LoadBalancerMTO
{
    public class Vm
    {
        private int _size;
        public int Size
        {
            get => _size;
        }

        public Vm(int size)
        {
            this._size = size;
        }
    }
}
