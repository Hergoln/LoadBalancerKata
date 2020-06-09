using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Text;

namespace LoadBalancerMTO
{
    public class Server
    {
        private double _currentLoadPercentage = 0d;
        public double CurrentLoadPercentage
        {
            get => _currentLoadPercentage;
        }
        private int _capacity = 0;
        public int Capacity
        {
            get => _capacity;
        }
        private List<Vm> _vms;
        public Vm[] Vms
        {
            get => copy();
        }

        public Server(int capacity)
        {
            this._capacity = capacity;
            this._vms = new List<Vm>();
        }

        public void Install(Vm vm)
        {
            int cumulativeSize = 0;
            _vms.Add(vm);

            foreach(Vm v in _vms)
            {
                cumulativeSize += v.Size;
            }

            _currentLoadPercentage = (double)cumulativeSize / _capacity;
        }

        private Vm[] copy()
        {
            Vm[] view = new Vm[_vms.Count];
            this._vms.CopyTo(view);
            return view;
        }
    }
}
