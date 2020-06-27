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
            this._expectedLoadPercentage = expectedLoadPercentage;
        }

        public override void DescribeMismatch(Server item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("A server with current laod percentage of").AppendValue(item.CurrentLoadPercentage);
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendText("Server load percentage matcher");
        }

        public override bool Matches(Server item)
        {
            return Abs(item.CurrentLoadPercentage - _expectedLoadPercentage) < 0.01d;
        }

        public static IMatcher<Server> HasLoadPercentageOf(double expectedLoadPercentage) => new ServerLoadPercentageMatcher(expectedLoadPercentage);
    }
}