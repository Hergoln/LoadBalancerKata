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
                Server s = null;
                foreach(Server server in servers)
                {
                    if(server.CanContain(vm))
                    {
                        if(s == null || server.CurrentLoadPercentage < s.CurrentLoadPercentage)
                        {
                            s = server;
                        }
                    }
                }

                if(s != null)
                    s.Install(vm);
            }
        }
    }
}