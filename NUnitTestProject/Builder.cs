using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    interface IBuilder<T>
    {
        T Build();
    }
}
