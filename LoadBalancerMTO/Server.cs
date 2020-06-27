namespace LoadBalancerMTO
{
    public class Server
    {
        public int Capacity;
        public double CurrentLoadPercentage;

        public bool Contains(Vm theVm)
        {
            return true;
        }
    }
}