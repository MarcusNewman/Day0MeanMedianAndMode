using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionUnitTesting;
using System.Reflection;

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
        public void ClassShouldExist()
        {
            GetClass();
        }

        Type GetClass()
        {
            var assembly = GetAssembly();
            return assembly.TypeExists("Day0MeanMedianAndMode", "Solution");
        }

        [TestMethod]
        public void MainMethodShouldExist()
        {
            GetClass().MethodExists("Main");
        }

        [TestMethod]
        public void MeanMethodShouldExist()
        {
            GetMeanMethod();
        }

        private MethodInfo GetMeanMethod()
        {
            return GetClass().MethodExists("Mean");
        }

        [TestMethod]
        public void Mean64630_11735_14216_99233_14470_4978_73429_38120_51135_67060ShouldBe43900_6()
        {
            var expected = 43900.6m;
            var values = new int[] { 64630, 11735, 14216, 99233, 14470, 4978, 73429, 38120, 51135, 67060 };
            GetMeanMethod().TestMethod(null, new object[] { values }, expected);
        }

        [TestMethod]
        public void MedianMethodShouldExist()
        {
            GetMedianMethod();

        }

        private MethodInfo GetMedianMethod()
        {
            return GetClass().MethodExists(
                methodName: "Median",
                shouldBeStatic: true,
                shouldReturnType: typeof(decimal),
                parameterTypesAndNames: new System.Collections.Generic.List<Tuple<Type, string>>
                {
                    Tuple.Create(typeof(int[]), "values")
                });
        }

        [TestMethod]
        public void Median312ShouldBe2()
        {
            var expected = 2m;
            var values = new int[] { 3, 1, 2 };
            GetMedianMethod().TestMethod(null, new object[] { values }, expected);
        }

        [TestMethod]
        public void Median3124ShouldBe2()
        {
            var expected = 2.5m;
            var values = new int[] { 3, 1, 2, 4 };
            GetMedianMethod().TestMethod(null, new object[] { values }, expected);
        }

        [TestMethod]
        public void ModeMethodShouldExist()
        {
            GetModeMethod();

        }

        private MethodInfo GetModeMethod()
        {
            return GetClass().MethodExists(
                methodName: "Mode",
                shouldBeStatic: true,
                shouldReturnType: typeof(int),
                parameterTypesAndNames: new System.Collections.Generic.List<Tuple<Type, string>>
                {
                    Tuple.Create(typeof(int[]), "values")
                });
        }

        [TestMethod]
        public void Mode234ShouldBe2()
        {
            var expected = 2;
            var values = new int[] { 2, 3, 4 };
            GetModeMethod().TestMethod(null, new object[] { values }, expected);
        }

        [TestMethod]
        public void Mode2344ShouldBe4()
        {
            var expected = 4;
            var values = new int[] { 2, 3, 4, 4 };
            GetModeMethod().TestMethod(null, new object[] { values }, expected);
        }
    }
}
