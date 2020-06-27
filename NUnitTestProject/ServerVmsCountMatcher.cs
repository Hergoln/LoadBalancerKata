using LoadBalancerMTO;
using NHamcrest;
using NHamcrest.Core;

namespace Tests
{
    public class ServerVmsCountMatcher : Matcher<Server>
    {
        private int _expectedCount;

        public ServerVmsCountMatcher(int count)
        {
            this._expectedCount = count;
        }

        public override void DescribeMismatch(Server item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("A Server has vms count of ").AppendValue(item.VmsCount);
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendText("A Server has vms count of ").AppendValue(_expectedCount);
        }

        public override bool Matches(Server item)
        {
            return item.VmsCount == _expectedCount;
        }

        public static ServerVmsCountMatcher AVmsCountOf(int count)
        {
            return new ServerVmsCountMatcher(count);
        }
    }
}