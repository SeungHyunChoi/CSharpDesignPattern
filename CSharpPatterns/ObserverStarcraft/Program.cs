using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverStarcraft
{
    class Program
    {
        static void Main(string[] args)
        {
            Marine ourMarine = new Marine("아군 마린", 100);
            ourMarine.Attach(new Mainscreen());
            ourMarine.Attach(new StatusScreen());
            ourMarine.Attach(new EnemyScreen());

            ourMarine.Health = 60;
            ourMarine.Health = 40;

            Console.ReadKey();
        }

        abstract class Unit
        {
            private string name;
            private int health;
            private List<UnitViewer> unitViewers = new List<UnitViewer>();

            public Unit(string name, int health)
            {
                this.name = name;
                this.health = health;
            }

            public void Attach(UnitViewer investor)
            {
                unitViewers.Add(investor);
            }

            public void Detach(UnitViewer investor)
            {
                unitViewers.Remove(investor);
            }

            public void Notify()
            {
                foreach (UnitViewer unitviewr in unitViewers)
                {
                    unitviewr.Update(this);
                }
            }

            public int Health
            {
                get { return health; }
                set
                {
                    health = value;
                    Notify();
                }
            }

            public string Name
            {
                get { return name; }
            }
        }

        class Marine : Unit
        {
            public Marine(string name, int health) : base(name, health)
            {
            }
        }

        interface UnitViewer
        {
            void Update(Unit unit);
        }

        class Mainscreen : UnitViewer
        {
            private Unit unit;

            public void Update(Unit _unit)
            {
                unit = _unit;
                Console.WriteLine("메인화면 {0} 상태 변경 : 체력 {1}", unit.Name, unit.Health.ToString());
            }

            public Unit Unit
            {
                get { return unit;  }
                set { unit = value; }
            }
        }

        class StatusScreen : UnitViewer
        {
            private Unit unit;

            public void Update(Unit _unit)
            {
                this.unit = _unit;
                Console.WriteLine("상태창 {0} 상태 변경 : 체력 {1}", this.unit.Name, this.unit.Health.ToString());
            }

            public Unit Unit
            {
                get { return unit;  }
                set { unit = value; }
            }
        }

        class EnemyScreen : UnitViewer
        {
            private Unit unit;

            public void Update (Unit _unit)
            {
                this.unit = _unit;
                Console.WriteLine("적 상태창 {0} 상태 변경 : 체력 {1}", this.unit.Name, this.unit.Health.ToString()); 
            }
        }
    }
}
