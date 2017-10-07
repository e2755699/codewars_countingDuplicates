using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace codewars_countingDuplicates
{
    [TestClass]
    public class Kata
    {
        [TestMethod]
        public void Input_a_shouldRetrun0()
        {
            var expect = 0;
            var actual = "a";
            AssertShouldBe(expect, actual);
        }

        private static void AssertShouldBe(int expect, string actual)
        {
            var count = new CountingDuplicates().Accum(actual);
            Assert.AreEqual(expect, count);
        }

        [TestMethod]
        public void Input_aa_shouldReturn1()
        {
            AssertShouldBe(1, "aa");
        }

        [TestMethod]
        public void Input_bb_shouldReturn1()
        {
            AssertShouldBe(1, "bb");
        }

        [TestMethod]
        public void Input_abb_shouldReturn1()
        {
            AssertShouldBe(1, "abb");
        }

        [TestMethod]
        public void Input_aabb_shouldReturn1()
        {
            AssertShouldBe(2, "aabb");
        }

        [TestMethod]
        public void Input_aA_shouldReturn1()
        {
            AssertShouldBe(1, "aA");
        }

        [TestMethod]
        public void Input_Indivisibilities_shouldReturn()
        {
            AssertShouldBe(2, "Indivisibilities");
        }
    }

    public class CountingDuplicates
    {
        public int Accum(string str)
        {
            var duplicateTimes = 0;
            str.ToList().ForEach(x =>
            {
                if (isDuplicateChar(str, x))
                {
                    str = ReplaceDuplicateChar(str, x);
                    duplicateTimes++;
                }
            });
            
            return duplicateTimes;
        }

        private string ReplaceDuplicateChar(string str, char @char)
        {
            var a =  str.Where(x =>
                !string.Equals(x.ToString(), @char.ToString(), StringComparison.CurrentCultureIgnoreCase));
            return string.Concat(a);
            //return str.Replace(@char.ToString().ToUpper(), "").Replace(@char.ToString().ToLower(), ""); ;
        }

        private bool isDuplicateChar(string str, char @char)
        {
            return str.Count(x => string.Equals(@char.ToString(), x.ToString(), StringComparison.CurrentCultureIgnoreCase)) > 1;
        }
    }
}
