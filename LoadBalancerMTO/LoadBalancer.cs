namespace LoadBalancerMTO
{
    public class LoadBalancer
    {
        public static void Balance(Server[] servers, Vm[] vms)
        {
            if(vms.Length > 0)
            {
                servers[0].AddVm(vms[0]);
            }
        }
    }
}