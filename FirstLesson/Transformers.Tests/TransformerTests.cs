using NUnit.Framework;

namespace Transformers.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("TC_old")]
    public class OptimusPrimeTests
    {
        [Test]
        [Category("Smoke")]
        public void Transformer_CanReceiveDamage()
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