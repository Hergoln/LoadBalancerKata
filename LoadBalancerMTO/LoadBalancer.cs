namespace LoadBalancerMTO
{
    public class LoadBalancer
    {
        public static void Balance(Server[] servers, Vm[] vms)
        {
            foreach(Vm vm in vms)
            {
                AddToLeastFilled(servers, vm);
            }
        }

        private static void AddToLeastFilled(Server[] servers, Vm vm)
        {
            Server leastFilled = SelectLeastFilled(servers);
            leastFilled.AddVm(vm);
        }

        private static Server SelectLeastFilled(Server[] servers)
        {
            Server leastFilled = null;
            foreach (Server server in servers)
            {
                if (leastFilled == null || server.CurrentLoadPercentage < leastFilled.CurrentLoadPercentage)
                {
                    leastFilled = server;
                }
            }

            return leastFilled;
        }
    }
}