using Game.LimitedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests.LimititedListTests
{
    [TestClass]
    public class LimitedListAddTests
    {
        [TestMethod]
        public void Add_WhenFull_ShouldReturn_False()
        {
            const int capacity = 1;
            var list = new Game.LimitedList.LimitedList<int>(capacity);

            var ok = list.Add(1);
            var shouldBeFalse = list.Add(2);
            var actual = list.IsFull;

            Assert.IsTrue(actual);
            Assert.IsTrue(ok);
            Assert.IsFalse(shouldBeFalse);

        }
    }
}