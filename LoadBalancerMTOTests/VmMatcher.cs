using NHamcrest;
using NHamcrest.Core;
using LoadBalancerMTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoadBalancerMTOTests
{
    class VmMatcher : Matcher<Vm>
    {
        private Vm _expected;

        public VmMatcher(Vm expected)
        {
            this._expected = expected;
        }

        public override bool Matches(Vm item)
        {
            return item.Size == _expected.Size;
        }
    }
}
