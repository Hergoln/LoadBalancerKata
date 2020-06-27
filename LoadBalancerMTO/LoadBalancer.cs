namespace LoadBalancerMTO
{
    public class LoadBalancer
    {
        public static void Balance(Server[] servers, Vm[] vms)
        {
            foreach(Vm vm in vms)
            {
                servers[0].AddVm(vm);
            }
        }
    }
}