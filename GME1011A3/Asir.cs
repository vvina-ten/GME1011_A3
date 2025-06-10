using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GME1011A3;

namespace GME1011A3
{
    internal class Asir : Minion   //asir is my cat
    {

        public Asir(int health, int armour) : base(health, armour) 
        { _armour = 5; }
        

        public override void TakeDamage(int damage)
        {
            _health -= damage;
        }

        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(1, 4);
        }

        public int AsirMeow()
        {
            Console.WriteLine("** MEOW **");
            Random rng = new Random();
            return rng.Next(1, 20);
        }

        public override string ToString()
        {
            return "Asir [" + base.ToString() + "]";
        }
    
    }
}
