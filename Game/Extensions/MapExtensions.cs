using Game.Entities.Creatures;
using Game.GameWorld;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Extensions
{
    internal static class MapExtensions
    {
        internal static IDrawable CreatureAtExtension(this List<Creature> creatures, Cell cell)
        {
            IDrawable result = cell;
            foreach (Creature creature in creatures)
            {
                if (creature.Cell == cell)
                {
                    result = creature;
                    break;
                }
            }

            return result;
        } 
        
        [return: MaybeNull]
        internal static IDrawable CreatureAtExtension2(this List<Creature> creatures, Cell cell)
        {
            //IDrawable? result = null;
            //foreach (Creature creature in creatures)
            //{
            //    if (creature.Cell == cell)
            //    {
            //        result = creature;
            //        break;
            //    }
            //}

            //return result;

            return creatures.FirstOrDefault(creature => creature.Cell == cell);
        }

       
    }
}
