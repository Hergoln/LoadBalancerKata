using System;

namespace LoadBalancerMTO
{
    public class Server
    {
        public int Capacity;
        public double CurrentLoadPercentage;
        private double MAXIMUM_LOAD = 100.0d;

        public bool Contains(Vm theVm)
        {
            return true;
        }

        public void AddVm(Vm vm)
        {
            this.CurrentLoadPercentage = (double)vm.Size / this.Capacity * MAXIMUM_LOAD;
        }
    }
}