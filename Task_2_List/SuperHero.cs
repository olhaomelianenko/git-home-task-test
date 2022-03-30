using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_List
{
    internal class SuperHero
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        public override string ToString()
        {
            return $"{Name} AKA '{Alias}'";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            SuperHero objSuperHero = (SuperHero)obj;
            if (Name.Equals(objSuperHero.Name) && Alias.Equals(objSuperHero.Alias))
            {
                return true;
            }
            return false;
        }
    }
}
