using Xunit;
using NHamcrest;
using NHamcrest.XUnit;
using LoadBalancerMTO;
using System;
using Tests;

using Assert = NHamcrest.XUnit.Assert;

using static LoadBalancerMTO.LoadBalancer;

namespace NUnitTestProject
{
    public class LoadBalancerMTOTests
    {
        public LoadBalancerMTOTests()
        {
        }

        [Fact]
        public void ServerIsLoadedWithNoVms_ServerStaysEmpty()
        {
            Server theServer = A(Server().WithCapacity(1));

            Balance(ServersListWith(theServer), AnEmptyVmsList());

            Assert.That(theServer, HasPercentageLoadOf(0.0d));
        }

        private ServerLoadPercentageMatcher HasPercentageLoadOf(double expectedPercentageLoad)
        {
            return new ServerLoadPercentageMatcher(expectedPercentageLoad);
        }

        private Vm[] AnEmptyVmsList()
        {
            return new Vm[] { };
        }

        private Server[] ServersListWith(params Server[] servers)
        {
            return servers;
        }

        private Server A(ServerBuilder serverBuilder)
        {
            return serverBuilder.Build();
        }

        private ServerBuilder Server()
        {
            return new ServerBuilder();
        }
    }
}