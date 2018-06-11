using MvgAeroCe.Nodes.SiFlex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using Mvg.Runtime.InteropServices;

namespace TestConfiguration
{
    
    
    /// <summary>
    ///This is a test class for ms2BoatTest and is intended
    ///to contain all ms2BoatTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ms2BoatTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FromXml
        ///</summary>
        [TestMethod()]
        public void FromXmlTest()
        {
            ms2Boat target = new ms2Boat(); // TODO: Initialize to an appropriate value
            byte[] readModifyWriteBuffer = null; // TODO: Initialize to an appropriate value
            XElement xmlConfig = XElement.Load(@"C:\Temp\CfgVessel.xml");
            byte messageType = 5; // TODO: Initialize to an appropriate value
            byte transactionId = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;


            actual = target.FromXml(readModifyWriteBuffer, xmlConfig, messageType, transactionId);
            Assert.AreEqual(expected, actual);
        }
    }
}
