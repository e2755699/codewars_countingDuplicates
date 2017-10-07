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

        [TestMethod]
        public void Input_empty_shouldReturn_zero()
        {
            AssertShouldBe(0, "");
        }
    }

    public class CountingDuplicates
    {
        public int Accum(string str)
        {
            var duplicates = 0;
            str.ToList().ForEach(x =>
            {
                if (IsDuplicate(str, x))
                {
                    str = ReplaceDuplicateChar(str, x);
                    duplicates++;
                }
            });
            
            return duplicates;
        }

        private string ReplaceDuplicateChar(string source, char idt)
        {
            var a =  source.Where(x =>
                !IsCharEqual(x, idt));
            return string.Concat(a);
        }

        private bool IsDuplicate(string source, char idt)
        {
            return source.Count(x => IsCharEqual(x, idt)) > 1;
        }

        private static bool IsCharEqual(char charA, char charB)
        {
            return string.Equals(charB.ToString(), charA.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
