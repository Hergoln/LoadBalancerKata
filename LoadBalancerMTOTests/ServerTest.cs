using LoadBalancerMTO;
using NUnit.Framework;
using NHamcrest;
using NHamcrest.Core;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Linq;

namespace LoadBalancerMTOTests
{
    [TestFixture]
    public class ServerTests
    {
        private double ZeroPercentage = 0.0d;
        private double FullServer = 1.0d;


        [SetUp]
        public void Init()
        {
            ZeroPercentage = 0.0d;
            FullServer = 1.0d;
        }

        [Test]
        public void OneServerBlancedWithEmptyVmShouldBeEmpty()
        {
            Server server = A(Server().WithCapacity(1));

            Balance(ServersListWith(server), EmptyVmsList());

            Assert.AreEqual(server.CurrentLoadPercentage, ZeroPercentage);
        }

        [Test]
        public void BalancingServerWithOneSlotCapacityAndOneSlotVMFillsServerWithVM()
        {
            Server server = A(Server().WithCapacity(1));
            Vm vm = A(Vm().WithSize(1));
            Vm[] vms = VmsListWith(vm);
            Balance(ServersListWith(server), vms);

            Assert.AreEqual(server.CurrentLoadPercentage, FullServer);
            Assert.True(ServerVmMatches(server, vms));
        }

        [Test]
        public void BalancingOneServerWithTenSlotsCapacityAndOneSlotVmFillTheServerWithTenPercent()
        {
            Server server = A(Server().WithCapacity(10));
            Vm vm = A(Vm().WithSize(1));

            Balance(ServersListWith(server), VmsListWith(vm));

            Assert.AreEqual(server.CurrentLoadPercentage, 0.1d);
        }

        [Test]
        public void BalancingAServerWithEnoughRoomGetsFilledWithAllVms()
        {
            Server server = A(Server().WithCapacity(10));
            Vm vm1 = A(Vm().WithSize(1));
            Vm vm2 = A(Vm().WithSize(4));
            Vm vm3 = A(Vm().WithSize(5));
            Vm[] vms = VmsListWith(vm1, vm2, vm3);

            Balance(ServersListWith(server), vms);

            Assert.AreEqual(server.CurrentLoadPercentage, FullServer);
            Assert.True(ServerVmMatches(server, vms));
        }

        [Test]
        public void AVmShouldBeBalancedOnLessLoadedServerFirst()
        {
            double loadedStartingLoad = 0.4d;
            int laodedCap = 10;
            int emptyCap = 10;
            Server loaded = A(Server().WithCapacity(laodedCap).WithStartingLoad(loadedStartingLoad));
            Server empty = A(Server().WithCapacity(emptyCap));
            Vm vm = A(Vm().WithSize(5));

            Balance(ServersListWith(loaded, empty), VmsListWith(vm));

            Assert.AreEqual(loaded.CurrentLoadPercentage, loadedStartingLoad);
            Assert.AreEqual(empty.CurrentLoadPercentage, 0.5d);
            Assert.True(ServerVmMatches(empty, vm));
        }

        [Test]
        public void BalanceAServerWithNotEnoughRoomShouldNotBeFilledWithAVm()
        {
            
        }

        public bool ServerVmMatches(Server server, params Vm[] vms)
        {
           foreach(Vm vm in vms)
           {
                if (!server.Vms.Contains(vm))
                {
                    return false;
                }
           }

            return true && server.Vms.Length == vms.Length;
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
            return ServerBuilder.Builder();
        }

        private Server[] ServersListWith(params Server[] servers)
        {
            return servers;
        }

        private Vm[] VmsListWith(params Vm[] vms)
        {
            return vms;
        }

        private Vm[] EmptyVmsList()
        {
            return new Vm[] { };
        }
    }
}