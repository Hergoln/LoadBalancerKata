using System;

namespace LoadBalancerMTO
{
    public class ServerLoadBalancer
    {
        public ServerLoadBalancer()
        {}

        public void Balance(Server[] servers, Vm[] vms)
        {
            foreach(Vm vm in vms)
            {
                Server s = servers[0];
                foreach(Server server in servers)
                {
                    if(server.CurrentLoadPercentage < s.CurrentLoadPercentage && server.CanContain(vm))
                    {
                        s = server;
                    }
                }

                s.Install(vm);
            }
        }
    }
}