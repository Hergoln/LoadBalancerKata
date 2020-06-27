﻿using System;
using System.Collections.Generic;

namespace LoadBalancerMTO
{
    public class Server
    {
        public int Capacity;
        public double CurrentLoadPercentage;
        private double MAXIMUM_LOAD = 100.0d;
        public int VmsCount => _vms.Count;

        private List<Vm> _vms;
        public Server(int capacity)
        {
            Capacity = capacity;
            _vms = new List<Vm>();
        }

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