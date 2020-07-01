using LoadBalancerMTO;
using NHamcrest;
using NHamcrest.Core;

using static System.Math;

namespace Tests
{
    public class ServerLoadPercentageMatcher : Matcher<Server>
    {
        private double _expectedLoadPercentage;
        public ServerLoadPercentageMatcher(double expectedLoadPercentage)
        {
            _expectedLoadPercentage = expectedLoadPercentage;
        }

        public override void DescribeMismatch(Server item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("Server has load percentage ").AppendValue(item.currentLoadPercentage);
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendText("Expected load percentage of the server ").AppendValue(_expectedLoadPercentage);
        }

        public override bool Matches(Server item)
        {
            return Abs(item.currentLoadPercentage - _expectedLoadPercentage) < 0.01;
        }
    }
}