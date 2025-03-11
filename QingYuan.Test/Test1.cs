using QingYuan.Common.Encrypt;

namespace QingYuan.Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hash = Salt.Generate();
            Console.WriteLine(hash);
        }
    }
}
