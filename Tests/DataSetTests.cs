using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DataSetTests
    {
        private AutoMoqer mocker;
        private DataSet classUnderTest;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMoqer();
            classUnderTest = mocker.Create<DataSet>();
        }
    }
}
