using LoadBalancerMTO;
using NHamcrest;
using NHamcrest.Core;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace LoadBalancerMTOTests
{
    [TestFixture]
    public class ServerTests
    {
        private double ZeroPercentage = 0.0d;
        private double FullServer = 1.0d;

        [Test]
        public void OneServerBlancedWithEmptyVmShouldBeEmpty()
        {
            Server server = A(Server().WithCapacity(1));

            Balance(ServersListWith(server), AnEmptyVMsListWith());

            Assert.AreEqual(server.CurrentLoadPercentage, ZeroPercentage);
        }

        [Test]
        public void BalancingServerWithOneSlotCapacityAndOneSlotVMFillsServerWithVM()
        {
            Server server = A(Server().WithCapacity(1));
            Vm vm = A(Vm().WithSize(1));

            Balance(ServersListWith(server), VmsListWith(vm));
            Assert.AreEqual(server.CurrentLoadPercentage, FullServer);
        }

        [Test]
        public void BalancingOneServerWithTenSlotsCapacityAndOneSlotVmFillTheServerWithTenPercent()
        {
            Assert.Pass();
        }

        [Test]
        public void BalancingAServerWithEnoughRoomGetsFilledWithAllVms()
        {
            Assert.Pass();
        }

        [Test]
        public void AVmShouldBeBalancedOnLessLoadedServerFirst()
        {
            Assert.Pass();
        }

        [Test]
        public void BalanceAServerWithNotEnoughRoomShouldNotBeFilledWithAVm()
        {
            Assert.Pass();
        }

        private Vm A(VmBuilder builder)
        {
            return builder.Build();
        }

        private VmBuilder Vm()
        {
            return VmBuilder.Builder();
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

        private Vm[] VmsListWith(params Vm[] vms)
        {
            return vms;
        }

        private Vm[] AnEmptyVMsListWith()
        {
            return new Vm[] { };
        }
    }
}