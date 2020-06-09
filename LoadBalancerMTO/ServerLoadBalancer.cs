namespace LoadBalancerMTO
{
    public class ServerLoadBalancer
    {
        public ServerLoadBalancer()
        {}

        public void Balance(Server[] servers, Vm[] vms)
        {
            for(int i = 0; i < vms.Length; i++)
            {
                servers[i].Install(vms[i]);
            }
        }
    }
}