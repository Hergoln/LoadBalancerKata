using LoadBalancerMTO;

namespace Tests
{
    public class ServerBuilder
    {
        private int InitCapacity;

        public ServerBuilder() {}

        public ServerBuilder WithCapacity(int capacity)
        {
            this.InitCapacity = capacity;
            return this;
        }

        public Server Build()
        {
            return new Server();
        }
    }
}