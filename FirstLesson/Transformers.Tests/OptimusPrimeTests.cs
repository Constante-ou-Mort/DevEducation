using NUnit.Framework;

namespace Transformers.Tests
{
    [TestFixture]
    [Category("TC_old")]
    public class TransformerTests
    {
        [Test]
        [TestCase("Compliance Manager", null)]
        [TestCase("Compliance Manager", null)]
        [TestCase("Compliance Manager", null)]
        [TestCase("Compliance Manager", null)]
        [TestCase("Compliance Manager", null)]
        public void Transformer_CanReceiveDamage(string managerType, string value)
        {
            //ARRANGE
            const int criticalDamage = 100;
            var transformer = new Program.OptimusPrime(new Program.LaserWeapon(), new Program.EchoScanner());
            
            //ACT
            transformer.ReceiveDamage(criticalDamage);

            //ASSERT
            Assert.IsFalse(transformer.IsAlive);
        }

        [Test]
        public void Transformer_CanReceive2Damage()
        {
            //ARRANGE
            const int criticalDamage = 100;
            var transformer = new Program.OptimusPrime(new Program.LaserWeapon(), new Program.EchoScanner());

            //ACT
            transformer.ReceiveDamage(criticalDamage);

            //ASSERT
            Assert.IsFalse(transformer.IsAlive);
        }
    }
}