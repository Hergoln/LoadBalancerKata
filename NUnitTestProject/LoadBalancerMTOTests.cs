using Xunit;
using NHamcrest;
using Assert = NHamcrest.XUnit.Assert;
using LoadBalancerMTO;
using System;
using static LoadBalancerMTO.LoadBalancer;

namespace Tests
{
    public class LoadBalancerMTOTests
    {
        [Fact]
        public void EmptyServer_FilledWithNoVms_StaysEmpty()
        {
            Server theServer = A(Server().WithCapacity(1));

            Balance(ServersListWith(theServer), EmptyVmsList());

            Assert.That(theServer, HasLoadPercentageOf(0.0d));
        }

        private IMatcher<Server> HasLoadPercentageOf(double expectedLoadPercentage)
        {
            return new ServerLoadPercentageMatcher(expectedLoadPercentage);
        }

        private Vm[] EmptyVmsList()
        {
            return new Vm[] { };
        }

        private Server[] ServersListWith(params Server[] servers)
        {
            return servers;
        }

        private ServerBuilder Server()
        {
            return new ServerBuilder();
        }

        private Server A(ServerBuilder builder)
        {
            return builder.Build();
        }
    }
}