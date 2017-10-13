using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Test_Base : ITest_Base
    {

    }
    internal class Test_A : Test_Base, ITest_A
    {

    }

    internal class Test_B : Test_Base, ITest_B
    {

    }

    internal class Test_C : Test_Base
    {

    }

    internal class Test_A_A : Test_A
    {

    }

    internal class Test_A_B : Test_A
    {

    }

    internal interface ITest_Base
    {

    }
    internal interface ITest_A
    {

    }

    internal interface ITest_B
    {

    }
}
