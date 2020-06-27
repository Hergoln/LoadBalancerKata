using System.Collections.Generic;

namespace LoadBalancerMTO
{
    public class LoadBalancer
    {
        public static void Balance(Server[] servers, Vm[] vms)
        {
            foreach(Vm vm in vms)
            {
                AddToLeastFilledCapable(servers, vm);
            }
        }

        private static void AddToLeastFilledCapable(Server[] servers, Vm vm)
        {
            List<Server> capaciousServers = ExtractCapable(servers, vm);
            Server leastFilled = SelectLeastFilled(capaciousServers);
            if (leastFilled != null)
            {
                leastFilled.AddVm(vm);
            }
        }

        private static List<Server> ExtractCapable(Server[] servers, Vm vm)
        {
            List<Server> capaciousServers = new List<Server>();
            foreach (Server server in servers)
            {
                if (server.CanContain(vm))
                {
                    capaciousServers.Add(server);
                }
            }

            return capaciousServers;
        }

        private static Server SelectLeastFilled(List<Server> servers)
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