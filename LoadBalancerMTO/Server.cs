using System;
using System.Collections.Generic;

namespace LoadBalancerMTO
{
    public class Server
    {
        public int Capacity { get; }
        public double _currentLoadPercentage;
        public double CurrentLoadPercentage => _currentLoadPercentage;
        public readonly static double MAXIMUM_LOAD = 100.0d;
        public int VmsCount => _vms.Count;

        private List<Vm> _vms;
        public Server(int capacity)
        {
            Capacity = capacity;
            _vms = new List<Vm>();
        }

        public bool Contains(Vm theVm)
        {
            return _vms.Contains(theVm);
        }

        internal bool CanContain(Vm vm)
        {
            return CurrentLoadPercentage + LoadOfVm(vm) <= MAXIMUM_LOAD;
        }

        public void AddVm(Vm vm)
        {
            _currentLoadPercentage += LoadOfVm(vm);
            this._vms.Add(vm);
        }

        private double LoadOfVm(Vm vm)
        {
            return (double)vm.Size / Capacity * MAXIMUM_LOAD;
        }
    }
}