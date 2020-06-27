namespace LoadBalancerMTO
{
    public class LoadBalancer
    {
        public static void Balance(Server[] servers, Vm[] vms)
        {
            foreach(Vm vm in vms)
            {
                Server leastFilled = null;
                foreach(Server server in servers)
                {
                    if(leastFilled == null || server.CurrentLoadPercentage < leastFilled.CurrentLoadPercentage)
                    {
                        leastFilled = server;
                    }
                }

                leastFilled.AddVm(vm);
            }
        }
    }
}