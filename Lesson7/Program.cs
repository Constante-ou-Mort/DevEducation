using System;

namespace Lesson7
{
    internal class Program
    {
        private static void Main()
        {
            var socialNetwork = new SocialNetwork(new User());

            var audiA5 = new AudiA5("red", new ElectricEngine());

            while (true)
                socialNetwork.AskMenuOptions();
        }


        public class AudiA5 : Car
        {
            public string Color { get; set; }
            public IEngine Engine { get; set; }

            public AudiA5(string color, IEngine engine)
            {
                Engine = engine;
                Color = color;
            }

            public override void Drive()
            {
                throw new NotImplementedException();
            }
        }

        public abstract class Car
        {
            public abstract void Drive();

            public virtual void Fly()
            {

            }
        }

        public interface ICar
        {
            public string Color { get; set; }
            public IEngine Engine { get; set; }

            void Drive();
        }

        public interface IEngine
        {
            public int Horses { get; }
        }

        public class ElectricEngine : IEngine
        {
            public int Horses { get; } = 700;
            public bool IsEco { get; } = true;
        }

        public class BenzineEngine : IEngine
        {
            public int Horses { get; } = 35;
            public bool IsEco { get; } = false;
        }

        public class DiaselEngine 
        {
            public int Horses { get; } = 40;
            public bool IsEco { get; } = false;
        }
    }
}