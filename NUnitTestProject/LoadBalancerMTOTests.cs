using System;
using Xunit;
using NHamcrest;
using Assert = NHamcrest.XUnit.Assert;
using LoadBalancerMTO;

using static LoadBalancerMTO.LoadBalancer;
using static Tests.ServerBuilder;
using static Tests.VmBuilder;
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

        [Fact]
        public void EmptyServer_FilledWithOneVmServersCapacitySize_FullyFills()
        {
            Server theServer = A(Server().WithCapacity(1));
            Vm theVm = A(Vm().OfSize(1));

            Balance(AServersListWith(theServer), AVmsListWith(theVm));

            Assert.That(theServer, HasLoadPercentageOf(100.0d));
            Assert.True(theServer.Contains(theVm));
        }

        private Vm[] AVmsListWith(params Vm[] vms) => vms;

        private Vm[] AVmsEmptyList() => new Vm[] { };

        private Server[] AServersListWith(params Server[] servers) => servers;

        private T A<T>(IBuilder<T> builder) => builder.Build();
    }
}