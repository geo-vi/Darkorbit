using System;
using System.Collections.Concurrent;
using Darkorbit.Instances.Game.Instances.CooldownObjects;
using Darkorbit.Instances.Game.Interfaces;

namespace Darkorbit.Instances.Game.Instances
{
    public class Cooldown : ITick
    {
        private int Id;

        private Character Character;
        
        public ConcurrentQueue<BaseCooldown> CooldownsTicking = new ConcurrentQueue<BaseCooldown>();
        
        public Cooldown(Character character)
        {
            Character = character;
            
            Init();
        }
        
        public int GetId()
        {
            return Id;
        }

        private void Init()
        {
            //todo: Initialise Ticker
        }
        
        public void Tick()
        {
            foreach (var cooldown in CooldownsTicking)
            {
                if (cooldown.CooldownEnd > DateTime.Now) continue;

                cooldown.Finish();
            }
        }
    }
}