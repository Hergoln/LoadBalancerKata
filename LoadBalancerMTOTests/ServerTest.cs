using NHamcrest;
using NHamcrest.Core;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace LoadBalancerMTO
{
    [TestFixture]
    public class ServerTests
    {
        private double ZeroPercentage = 0.0d;

        [Test]
        public void OneServerBlancedWithEmptyVmShouldBeEmpty()
        {
            Server server = A(Server().WithCapacity(1));

            Balance(ServersListWith(server), AnEmptyVMsListWith());

            Assert.AreEqual(ZeroPercentage, server.CurrentLoadPercentage);
        }

        private void Balance(Server[] servers, Vm[] vms)
        {
            new ServerLoadBalancer().Balance(servers, vms);
        }

        private Server A(ServerBuilder builder)
        {
            return builder.Build();
        }

        private ServerBuilder Server()
        {
            return new ServerBuilder();
        }

        private Server[] ServersListWith(params Server[] servers)
        {
            return servers;
        }

        private Vm[] AnEmptyVMsListWith()
        {
            return new Vm[] { };
        }
    }
}