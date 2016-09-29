using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionUnitTesting;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Day0MeanMedianAndMode.UnitTests
{
    [TestClass]
    public class Day0MeanMedianAndModeUnitTests
    {
        string assemblyName = "Day0MeanMedianAndMode.exe";

        [TestMethod]
        public void Day0MeanMedianAndModeAssemblyShouldExist()
        {
            GetAssembly();
        }

        Assembly GetAssembly()
        {
            return ReflectionAssert.AssemblyExists(assemblyName);
        }

        [TestMethod]
        public void SolutionClassShouldExist()
        {
            GetSolutionClass();
        }

        Type GetSolutionClass()
        {
            var assembly = GetAssembly();
            return assembly.TypeExists("Day0MeanMedianAndMode", "Solution");
        }

        [TestMethod]
        public void MainMethodShouldExist()
        {
            var main = new MethodShouldExist
            {
                Name = "Main",
                shouldBeStatic = true
            };
            TestMethod(main);
        }

        public MethodInfo TestMethod(MethodShouldExist method)
        {
            var result = GetSolutionClass().MethodExists(method.Name);
            Assert.AreEqual(method.shouldBeStatic, result.IsStatic, String.Format("{0} method should {1}be static.", method.Name, method.shouldBeStatic ? "" : "not "));
           // CollectionAssert.AreEqual(method.shouldAcceptParameterTypes, result.GetParameters(), string.Format("{0} method parameters should be {1}.", method.Name, method.shouldAcceptParameterTypes);
            return result;
        }

        [TestMethod]
        public void MeanMethodShouldExist()
        {
            GetMeanMethod();
        }

        public MethodInfo GetMeanMethod()
        {
            var mean = new MethodShouldExist
            {
                Name = "Mean",
                shouldBeStatic = true,
                shouldAcceptParameters = new ParameterInfo[]
                {
                    new _ParameterInfo()
                    {
                        type = typeof(int[]),
                        name = "values" }
                },
                shouldReturnType = typeof(decimal)
            };
            return TestMethod(mean);
        }

        [TestMethod]
        public void Mean64630_11735_14216_99233_14470_4978_73429_38120_51135_67060ShouldBe43900_6()
        {
            var method = GetMeanMethod();
            var expected = 43900.6m;
            var actual = method.Invoke(null, new object[] { new int[] { 64630, 11735, 14216, 99233, 14470, 4978, 73429, 38120, 51135, 67060 } });
            Assert.AreEqual(expected, actual, "Mean of 64630 11735 14216 99233 14470 4978 73429 38120 51135 67060 should be 43900.6");
        }

        public class MethodShouldExist
        {
            public string Name { get; set; }
            public bool shouldBeStatic { get; set; }
            public Type shouldReturnType { get; set; }
            public ParameterInfo[] shouldAcceptParameters { get; set; }
        }
    }
}
