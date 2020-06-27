using LoadBalancerMTO;

namespace Tests
{
    public class ServerBuilder : IBuilder<Server>
    {
        private int _capacity;

        public ServerBuilder WithCapacity(int capacity)
        {
            this._capacity = capacity;
            return this;
        }

        public Server Build()
        {
            return new Server() { Capacity = this._capacity };
        }

        public static ServerBuilder Server() => new ServerBuilder();
    }
}