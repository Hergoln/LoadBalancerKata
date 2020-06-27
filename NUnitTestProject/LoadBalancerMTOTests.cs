using System;
using Xunit;
using NHamcrest;
using Assert = NHamcrest.XUnit.Assert;
using LoadBalancerMTO;

using static LoadBalancerMTO.LoadBalancer;
using static Tests.ServerBuilder;
using static Tests.ServerLoadPercentageMatcher;

namespace Tests
{
    public class LoadBalancerMTOTests
    {
        [Fact]
        public void EmptyServer_FilledWithNoVms_StaysEmpty()
        {
            Server theServer = A(Server().WithCapacity(1));

            Balance(AServersListWith(theServer), AVmsEmptyList());

            Assert.That(theServer, HasLoadPercentageOf(0.0d));
        }

        private Vm[] AVmsEmptyList() => new Vm[] { };

        private Server[] AServersListWith(params Server[] servers) => servers;

        private Server A(ServerBuilder builder) => builder.Build();
    }
}