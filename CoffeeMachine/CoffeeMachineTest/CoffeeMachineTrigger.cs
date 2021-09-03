using CoffeeMachine;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoffeeMachineTest
{
    class CoffeeMachineTrigger
    {
        //Test Case 1 : Able to create 3 and unable to create 1 beverages on slot size of 4
        [SetUp]
        public void TestSetup1()
        {
            string[] args = new string[2];
            args[0] = "..\\..\\..\\ResourcesTest\\input1.json";
            args[1] = "..\\..\\..\\ResourcesTest\\output1.txt";
            Program.Main(args);
        }

        [Test]
        public void TestRun1()
        {
            string outputPath = "..\\..\\..\\ResourcesTest\\output1.txt";
            if (!File.Exists(outputPath))
                Assert.Fail();
            List<string> outputLines = File.ReadAllLines(outputPath).ToList();
            outputLines.Sort();

            List<string> compareOutputList = new List<string>();
            compareOutputList.Add("black_tea is prepared");
            compareOutputList.Add("green_tea cannot be prepared because green_mixture is not available");
            compareOutputList.Add("hot_coffee is prepared");
            compareOutputList.Add("hot_tea is prepared");

            for(int i = 0; i < 4; i++)
            {
                if (!outputLines[i].Equals(compareOutputList[i]))
                    Assert.Fail();
            }
            
            Assert.Pass();
        }

        //Test Case 2 : Unable to create any of the beverages due to invalid ingredient
        [SetUp]
        public void TestSetup2()
        {
            string[] args = new string[2];
            args[0] = "..\\..\\..\\ResourcesTest\\input2.json";
            args[1] = "..\\..\\..\\ResourcesTest\\output2.txt";
            Program.Main(args);
        }

        [Test]
        public void TestRun2()
        {
            string outputPath = "..\\..\\..\\ResourcesTest\\output2.txt";
            if (!File.Exists(outputPath))
                Assert.Fail();
            List<string> outputLines = File.ReadAllLines(outputPath).ToList();
            outputLines.Sort();

            List<string> compareOutputList = new List<string>();
            compareOutputList.Add("black_tea cannot be prepared because green_mixture is not available");
            compareOutputList.Add("green_tea cannot be prepared because green_mixture is not available");
            compareOutputList.Add("hot_coffee cannot be prepared because green_mixture is not available");
            compareOutputList.Add("hot_tea cannot be prepared because green_mixture is not available");

            for (int i = 0; i < 4; i++)
            {
                if (!outputLines[i].Equals(compareOutputList[i]))
                    Assert.Fail();
            }

            Assert.Pass();
        }
    }
}
