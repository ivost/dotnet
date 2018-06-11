using System;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvg.Runtime.InteropServices;
using MvgAeroCe.Nodes.SiFlex;

namespace TestConfiguration
{


    /// <summary>
    ///This is a test class for wlsNodePoleTest and is intended
    ///to contain all wlsNodePoleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class wlsNodePoleTest
    {

        private TestContext testContextInstance;        
        private static byte[] actual;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                Console.WriteLine("TestContext");

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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            
        }


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
            wlsNodePole target = new wlsNodePole(); // TODO: Initialize to an appropriate value
            XElement xmlConfig = new XElement("Cfg",
                    new XAttribute("auxInput.debounceOn", 0),
                    new XAttribute("auxInput.debounceOff", 1),
                    new XAttribute("photocell.threshold", 2),
                    new XAttribute("photocell.hysteresis", 3),
                    new XAttribute("photocell.debounceTime", 4),
                    new XAttribute("lamp.minOffTime", 5),
                    new XAttribute("lamp.minOnTime", 6),
                    new XAttribute("lamp.minLampCurrentA", 7),
                    new XAttribute("lamp.minLampCurrentB", 8),
                    new XAttribute("lamp.minLampCurrentC", 9),
                    new XAttribute("lamp.minLampCurrentD", 0),
                    new XAttribute("lamp.minLampBallastA", 1),
                    new XAttribute("lamp.minLampBallastB", 2),
                    new XAttribute("lamp.minLampBallastC", 3),
                    new XAttribute("lamp.minLampBallastD", 4),
                    new XAttribute("lamp.underCurrentHysteresis", 5),
                    new XAttribute("lamp.underCurrentDebounce", 6),
                    new XAttribute("lamp.underCurrentBlankingTime", 7),
                    new XAttribute("autonomy.lampEnable", 0x0f),
                    new XAttribute("autonomy.timeModeEnable", 0),
                    new XAttribute("autonomy.photocellModeEnable", 1),
                    new XAttribute("autonomy.startTime", 11),
                    new XAttribute("autonomy.stopTime", 12),
                    new XAttribute("autonomy.radioTimeout", 1800),
                    new XAttribute("outputConfig.initialState_auxOutput", 1),
                    new XAttribute("outputConfig.polarity_auxOutput", 1),
                    new XAttribute("outputConfig.initialState_lamps", 0x0f),
                    new XAttribute("outputConfig.polarity_lamps", 0x0f),
                    new XAttribute("alert.powerup", 1),
                    new XAttribute("alert.auxInputChanged", 0),
                    new XAttribute("alert.photocellStateChange", 1),
                    new XAttribute("alert.lampFailure", 0),
                    new XAttribute("alert.ballastFailure", 0),
                    new XAttribute("alert.radioTimeout", 0),
                    new XAttribute("alert.configDefault", 0),
                    new XAttribute("alert.lampRecovery", 0),
                    new XAttribute("addr.panId", "4321"),
                    new XAttribute("addr.shortId", "9999"),
                    new XAttribute("addr.longId", "0"),
                    new XAttribute("calibration.zeroOffsetA", 5),
                    new XAttribute("calibration.zeroOffsetB", 10),
                    new XAttribute("calibration.zeroOffsetC", 15),
                    new XAttribute("calibration.zeroOffsetD", 20));

            Console.WriteLine(xmlConfig.ToString());

            actual = target.FromXml(null, xmlConfig, 5, 0);

            wlsNodePole.tConfiguration cfg = MarshalEx.ByteArrayToStructure<MvgAeroCe.Nodes.SiFlex.wlsNodePole.tConfiguration>(actual);
            Assert.AreEqual(cfg.messageType, 5);
            Assert.AreEqual(cfg.auxInput_debounceOn, 0);
            Assert.AreEqual(cfg.auxInput_debounceOff, 1);
            Assert.AreEqual(cfg.photocell_threshold, 2);
            Assert.AreEqual(cfg.photocell_hysteresis, 3);
            Assert.AreEqual(cfg.photocell_debounceTime, 4);
            Assert.AreEqual(cfg.lamp_minOffTime, 5);
            Assert.AreEqual(cfg.lamp_minOnTime, 6);

            Assert.AreEqual(cfg.lamp_minLampCurrent[0], 7);
            Assert.AreEqual(cfg.lamp_minLampCurrent[1], 8);
            Assert.AreEqual(cfg.lamp_minLampCurrent[2], 9);
            Assert.AreEqual(cfg.lamp_minLampCurrent[3], 0);

            Assert.AreEqual(1, cfg.lamp_minLampBallast[0]);
            Assert.AreEqual(2, cfg.lamp_minLampBallast[1]);
            Assert.AreEqual(3, cfg.lamp_minLampBallast[2]);
            Assert.AreEqual(4, cfg.lamp_minLampBallast[3]);

            Assert.AreEqual(5, cfg.lamp_underCurrentHysteresis);
            Assert.AreEqual(6, cfg.lamp_underCurrentDebounce);
            Assert.AreEqual(7, cfg.lamp_underCurrentBlankingTime);
            Assert.AreEqual(0x20f, cfg.autonomy);
            Assert.AreEqual((uint)11, cfg.autonomy_startTime);
            Assert.AreEqual((uint)12, cfg.autonomy_stopTime);
            Assert.AreEqual((uint)1800, cfg.autonomy_radioTimeout);

            Assert.AreEqual(1, cfg.outputConfig);
            Assert.AreEqual(5, cfg.alert);

            Assert.AreEqual(0x1234, cfg.addr_longId);
            Assert.AreEqual(0x9999, cfg.addr_shortId);
            Assert.AreEqual((ulong)0, cfg.addr_longId);

            //string xml = SerializeObject<wlsNodePole.tConfiguration>(Encoding.UTF8, cfg);
            //Console.WriteLine(xml);


        }


        [TestMethod()]
        public void FromXmlReadModifyWriteTest()
        {
            wlsNodePole target = new wlsNodePole(); // TODO: Initialize to an appropriate value


            //Now test the same but pass the buffer as if it was a readModifyWrite
            XElement xmlConfig = new XElement("Cfg",
                    new XAttribute("auxInput_debounceOn", 255));

            actual = target.FromXml(actual, xmlConfig, 4, 0);         
            wlsNodePole.tConfiguration cfg = MarshalEx.ByteArrayToStructure<MvgAeroCe.Nodes.SiFlex.wlsNodePole.tConfiguration>(actual);

            Assert.AreEqual(255, cfg.auxInput_debounceOn);

            cfg = MarshalEx.ByteArrayToStructure<MvgAeroCe.Nodes.SiFlex.wlsNodePole.tConfiguration>(actual);
            string xml = Utility.SerializeObject<wlsNodePole.tConfiguration>(Encoding.UTF8, cfg);

            Console.WriteLine(xml);


        }

        [TestMethod()]
        public void FromXmlDefaultTest()
        {
            wlsNodePole target = new wlsNodePole(); // TODO: Initialize to an appropriate value


            XElement xmlConfig = new XElement("Cfg");

            actual = target.FromXml(null, xmlConfig, 4, 0);
            wlsNodePole.tConfiguration cfg = MarshalEx.ByteArrayToStructure<MvgAeroCe.Nodes.SiFlex.wlsNodePole.tConfiguration>(actual);

            Assert.AreEqual(cfg.alert, 0);

            cfg = MarshalEx.ByteArrayToStructure<MvgAeroCe.Nodes.SiFlex.wlsNodePole.tConfiguration>(actual);
            string xml = Utility.SerializeObject<wlsNodePole.tConfiguration>(Encoding.UTF8, cfg);

            Console.WriteLine(xml);


        }







        /// <summary>
        ///A test for FromXml
        ///</summary>
        [TestMethod()]
        public void FromXmlTest1()
        {
            wlsNodePole target = new wlsNodePole(); // TODO: Initialize to an appropriate value
            XElement xmlConfig = new XElement("Cfg",
                    new XAttribute("auxInput.debounceOn", 0),
                    new XAttribute("auxInput.debounceOff", 1),
                    new XAttribute("photocell.threshold", 2),
                    new XAttribute("photocell.hysteresis", 3),
                    new XAttribute("photocell.debounceTime", 4),
                    new XAttribute("lamp.minOffTime", 5),
                    new XAttribute("lamp.minOnTime", 6),
                    new XAttribute("lamp.minLampCurrentA", 7),
                    new XAttribute("lamp.minLampCurrentB", 8),
                    new XAttribute("lamp.minLampCurrentC", 9),
                    new XAttribute("lamp.minLampCurrentD", 0),
                    new XAttribute("lamp.minLampBallastA", 1),
                    new XAttribute("lamp.minLampBallastB", 2),
                    new XAttribute("lamp.minLampBallastC", 3),
                    new XAttribute("lamp.minLampBallastD", 4),
                    new XAttribute("lamp.underCurrentHysteresis", 5),
                    new XAttribute("lamp.underCurrentDebounce", 6),
                    new XAttribute("lamp.underCurrentBlankingTime", 7),
                    new XAttribute("autonomy.lampEnable", 0x0f),
                    new XAttribute("autonomy.timeModeEnable", 0),
                    new XAttribute("autonomy.photocellModeEnable", 1),
                    new XAttribute("autonomy.startTime", 11),
                    new XAttribute("autonomy.stopTime", 12),
                    new XAttribute("autonomy.radioTimeout", 1800),
                    new XAttribute("outputConfig.initialState_auxOutput", 1),
                    new XAttribute("outputConfig.polarity_auxOutput", 1),
                    new XAttribute("outputConfig.initialState_lamps", 0x0f),
                    new XAttribute("outputConfig.polarity_lamps", 0x0f),
                    new XAttribute("alert.powerup", 1),
                    new XAttribute("alert.auxInputChanged", 0),
                    new XAttribute("alert.photocellStateChange", 1),
                    new XAttribute("alert.lampFailure", 0),
                    new XAttribute("alert.ballastFailure", 0),
                    new XAttribute("alert.radioTimeout", 0),
                    new XAttribute("alert.configDefault", 0),
                    new XAttribute("alert.lampRecovery", 0),
                    new XAttribute("addr.panId", "4321"),
                    new XAttribute("addr.shortId", "9999"),
                    new XAttribute("addr.longId", "0"),
                    new XAttribute("calibration.zeroOffsetA", 5),
                    new XAttribute("calibration.zeroOffsetB", 10),
                    new XAttribute("calibration.zeroOffsetC", 15),
                    new XAttribute("calibration.zeroOffsetD", 20));

            Console.WriteLine(xmlConfig.ToString());

            actual = target.FromXml(null, xmlConfig, 5, 0);

            wlsNodePole.tConfiguration cfg = MarshalEx.ByteArrayToStructure<MvgAeroCe.Nodes.SiFlex.wlsNodePole.tConfiguration>(actual);
            Assert.AreEqual(cfg.messageType, 5);
            Assert.AreEqual(cfg.auxInput_debounceOn, 0);
            Assert.AreEqual(cfg.auxInput_debounceOff, 1);
            Assert.AreEqual(cfg.photocell_threshold, 2);
            Assert.AreEqual(cfg.photocell_hysteresis, 3);
            Assert.AreEqual(cfg.photocell_debounceTime, 4);
            Assert.AreEqual(cfg.lamp_minOffTime, 5);
            Assert.AreEqual(cfg.lamp_minOnTime, 6);

            Assert.AreEqual(cfg.lamp_minLampCurrent[0], 7);
            Assert.AreEqual(cfg.lamp_minLampCurrent[1], 8);
            Assert.AreEqual(cfg.lamp_minLampCurrent[2], 9);
            Assert.AreEqual(cfg.lamp_minLampCurrent[3], 0);

            Assert.AreEqual(1, cfg.lamp_minLampBallast[0]);
            Assert.AreEqual(2, cfg.lamp_minLampBallast[1]);
            Assert.AreEqual(3, cfg.lamp_minLampBallast[2]);
            Assert.AreEqual(4, cfg.lamp_minLampBallast[3]);

            Assert.AreEqual(5, cfg.lamp_underCurrentHysteresis);
            Assert.AreEqual(6, cfg.lamp_underCurrentDebounce);
            Assert.AreEqual(7, cfg.lamp_underCurrentBlankingTime);
            Assert.AreEqual(0x20f, cfg.autonomy);
            Assert.AreEqual((uint)11, cfg.autonomy_startTime);
            Assert.AreEqual((uint)12, cfg.autonomy_stopTime);
            Assert.AreEqual((uint)1800, cfg.autonomy_radioTimeout);

            Assert.AreEqual(1, cfg.outputConfig);
            Assert.AreEqual(5, cfg.alert);

            Assert.AreEqual(0x1234, cfg.addr_longId);
            Assert.AreEqual(0x9999, cfg.addr_shortId);
            Assert.AreEqual((ulong)0, cfg.addr_longId);

            //string xml = SerializeObject<wlsNodePole.tConfiguration>(Encoding.UTF8, cfg);
            //Console.WriteLine(xml);
        }

        /// <summary>
        ///A test for FromXml
        ///</summary>
        [TestMethod()]
        public void FromXmlTest2()
        {
            wlsNodePole target = new wlsNodePole(); // TODO: Initialize to an appropriate value
            byte[] readModifyWriteBuffer = null; // TODO: Initialize to an appropriate value
            XElement xmlConfig = null; // TODO: Initialize to an appropriate value
            byte messageType = 0; // TODO: Initialize to an appropriate value
            byte transactionId = 0; // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.FromXml(readModifyWriteBuffer, xmlConfig, messageType, transactionId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
