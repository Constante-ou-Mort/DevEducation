using System;
using System.Collections.Generic;

namespace Transformers
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            var optimusPrime = TransformerFactory.CreateTransformer(
                TransformerFactory.TransformerType.OptimusPrime, new LaserWeapon(), new OpticalScanner());
            var autoBotX5 = TransformerFactory.CreateTransformer(
                TransformerFactory.TransformerType.AutoBotX5, new LaserWeapon(), new EchoScanner());

            var game = new Game(optimusPrime, autoBotX5);
            game.Battle();
            game.ShowWinner();
        }

        public class Game
        {
            private readonly Transformer _player1;
            private readonly Transformer _player2;

            public Game(Transformer player1, Transformer player2)
            {
                _player1 = player1;
                _player2 = player2;
            }

            public void Battle()
            {
                var random = new Random();

                _player1.Transform();
                _player2.Transform();

                while (_player1.IsAlive && _player2.IsAlive)
                {
                    if (random.Next(1, 3) == 1)
                    {
                        _player1.FindEnemy();
                        _player1.Run();
                        var damage = _player1.Fire();

                        _player2.ReceiveDamage(damage);
                    }
                    else
                    {
                        _player2.FindEnemy();
                        _player2.Run();
                        var damage = _player2.Fire();

                        _player1.ReceiveDamage(damage);
                    }
                }
            }

            public void ShowWinner()
            {
                Console.WriteLine($"Winner is {(_player1.IsAlive ? nameof(_player1) : nameof(_player2))}");
            }
        }

        public class TransformerFactory
        {
            public static Transformer CreateTransformer(TransformerType transformerType, Weapon weapon, Scanner scanner)
            {
                Transformer transformer = transformerType switch
                {
                    TransformerType.OptimusPrime => new OptimusPrime(weapon, scanner),
                    TransformerType.AutoBotX5 => new AutoBotX5(weapon, scanner),
                    _ => throw new ArgumentOutOfRangeException($"No implementation for this type {transformerType}.")
                };

                return transformer;
            }

            public enum TransformerType
            {
                OptimusPrime,
                AutoBotX5
            }
        }

        public abstract class Transformer
        {
            protected readonly Weapon Weapon;
            protected readonly Scanner Scanner;
            protected bool IsTransformed;

            protected int Health { get; private set; } = 100;
            public bool IsAlive { get; private set; } = true;

            protected Transformer(Weapon weapon, Scanner scanner)
            {
                Weapon = weapon;
                Scanner = scanner;
            }

            public abstract int Fire();
            public abstract void Run();
            public abstract void FindEnemy();
            public abstract void Transform();

            public void ReceiveDamage(int damage)
            {
                var currentHealth = Health - damage;

                if (currentHealth > 0)
                    Health = currentHealth;
                else
                    IsAlive = false;
            }
        }

        public abstract class SwimmingTransformer : Transformer
        {
            protected SwimmingTransformer(Weapon weapon, Scanner scanner) : base(weapon, scanner)
            {
            }

            public abstract void Swim();
        }

        public abstract class FlyingTransformer : Transformer
        {
            protected FlyingTransformer(Weapon weapon, Scanner scanner) : base(weapon, scanner)
            {
            }

            public abstract void Fly();
        }

        public class OptimusPrime : DriverTransformer
        {
            public OptimusPrime(Weapon weapon, Scanner scanner) : base(weapon, scanner)
            {
            }

            public override int Fire()
            {
                return Weapon.Fire();
            }

            public override void Run()
            {
                if (!IsTransformed)
                {
                    Console.WriteLine("Optimus is running");
                }
            }

            public override void FindEnemy()
            {
                Scanner.Scan();
            }

            public override void Transform()
            {
                if (!IsTransformed)
                {
                }
            }

            public override void Drive()
            {
                throw new NotImplementedException();
            }
        }

        public abstract class Scanner
        {
            public abstract void Scan();
        }

        public class OpticalScanner : Scanner
        {
            public override void Scan()
            {
                Console.WriteLine("Optical scanner is activated");
            }
        }

        public class EchoScanner : Scanner
        {
            public override void Scan()
            {
                Console.WriteLine("Echo scanner is activated");
            }
        }

        public abstract class Weapon
        {
            public abstract void Reload();
            public abstract int Fire();
        }

        public class LaserWeapon : Weapon
        {
            public override void Reload()
            {
                throw new NotImplementedException();
            }

            public override int Fire()
            {
                return 25;
            }
        }
    }

    internal class AutoBotX5 : Program.FlyingTransformer
    {
        public AutoBotX5(Program.Weapon weapon, Program.Scanner scanner) : base(weapon, scanner)
        {
        }

        public override int Fire()
        {
            return Weapon.Fire();
        }

        public override void Run()
        {
            Console.WriteLine("AutobotX5 is running");
        }

        public override void FindEnemy()
        {
            Scanner.Scan();
        }

        public override void Transform()
        {
            if (!IsTransformed)
            {
                IsTransformed = true;
            }
        }

        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}