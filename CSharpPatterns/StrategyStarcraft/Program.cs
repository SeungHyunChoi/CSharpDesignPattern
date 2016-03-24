using System;

namespace StrategyStarcraft
{
    class Program
    {
        static void Main(string[] args)
        {
            // Marine
            Unit unit = new Marine(new MoveLand(), new Attack());
            unit.Move();
            unit.Attack();

            // Medic
            unit = new Medic(new MoveLand(), new NoAttack());
            unit.Move();
            unit.Attack();

            // Wrath
            unit = new Wrath(new MoveSky(), new Attack());
            unit.Move();
            unit.Attack();

            // Medic special attack
            unit = new Marine(new MoveLand(), new SpecialAttack());
            unit.Move();
            unit.Attack();

            Console.ReadKey();
        }

        abstract class Moveable
        {
            public abstract void Move(string unitName);
        }

        class MoveLand : Moveable
        {
            public override void Move(string unitName)
            {
                Console.WriteLine("{0} Move Land", unitName);
            }
        }

        class MoveSky : Moveable
        {
            public override void Move(string unitName)
            {
                Console.WriteLine("{0} Move Sky", unitName);
            }
        }

        abstract class Attackable
        {
            public abstract void AttackEnemy(string unitName);
        } 
        class Attack : Attackable
        {
            public override void AttackEnemy(string unitName)
            {
                Console.WriteLine("{0} Attack Enemy!", unitName);
            }
        }

        class NoAttack : Attackable 
        {
            public override void AttackEnemy(string unitName)
            {
                Console.WriteLine("{0} NotAttack Enemy", unitName);
            }
        }

        class SpecialAttack : Attackable
        {
            public override void AttackEnemy(string unitName)
            {
                Console.WriteLine("{0} can Special Attack", unitName);
            }
        }

        class Unit
        {
            private Moveable moveAble;
            private Attackable attackAble;
            private string unitName;

            public Unit(Moveable moveable , Attackable attackable)
            {
                this.moveAble = moveable;
                this.attackAble = attackable;
                this.unitName = this.GetType().Name;
            }

            public Unit(Moveable moveable , Attackable attackable, string unitname)
            {
                this.moveAble = moveable;
                this.attackAble = attackable;
                this.unitName = unitname;
            }


            public void Attack()
            {
                attackAble.AttackEnemy(unitName);
            }

            public void Move()
            {
                moveAble.Move(unitName);
            }

            public Moveable MoveAble
            {
                set { this.moveAble = value; }
            }
        }

         class Marine : Unit
        {

            public Marine ( Moveable moveable , Attackable attackable ) : base( moveable , attackable )
            {

            }
        }

        class Medic : Unit
        {

            public Medic ( Moveable moveable , Attackable attackable) : base(moveable, attackable)
            {

            }
        }

        class Wrath : Unit
        {

            public Wrath(Moveable moveable, Attackable attackable) : base ( moveable, attackable )
            {

            }
        }
    }
}
