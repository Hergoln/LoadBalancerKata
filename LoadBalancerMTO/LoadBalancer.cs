namespace LoadBalancerMTO
{
    public class LoadBalancer
    {
        public static void Balance(Server[] servers, Vm[] vms)
        {
            if(vms.Length > 0)
            {
                servers[0].CurrentLoadPercentage = (double)vms[0].Size / servers[0].Capacity * 100.0d;
            }
        }
    }
}