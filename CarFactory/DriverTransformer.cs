namespace Transformers
{
        public abstract class DriverTransformer : Program.Transformer
        {
            protected DriverTransformer(Program.Weapon weapon, Program.Scanner scanner) : base(weapon, scanner)
            {
            }

            public abstract void Drive();
        }
}