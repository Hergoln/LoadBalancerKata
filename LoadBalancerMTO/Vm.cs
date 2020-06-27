namespace LoadBalancerMTO
{
    public class Vm
    {
        private int _size;
        public int Size => _size;
        public Vm(int size)
        {
            _size = size;
        }
    }
}