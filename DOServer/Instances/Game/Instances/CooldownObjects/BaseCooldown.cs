using System;
using Darkorbit.Instances.Game.Events;

namespace Darkorbit.Instances.Game.Instances.CooldownObjects
{
    public abstract class BaseCooldown
    {
        public DateTime CooldownEnd;

        public event EventHandler<CooldownLaunchedEvent> CooldownLaunchEvent;
        public event EventHandler<CooldownFinishedEvent> CooldownFinishedEvent;

        /// <summary>
        /// Starting the cooldown
        /// </summary>
        /// <param name="cooldownEndTime">Cooldown's ending which will cause it to dequeue from the global ticker</param>
        public void StartCooldown(Cooldown cooldown, DateTime cooldownEndTime)
        {
            cooldown.CooldownsTicking.Enqueue(this);
                
            CooldownEnd = cooldownEndTime;
            CooldownLaunchEvent?.Invoke(this, new CooldownLaunchedEvent());
        }
        
        /// <summary>
        /// Can be used for intervals in between the cooldowns
        /// </summary>
        public virtual void Tick()
        {
            
        }

        /// <summary>
        /// Cooldown finished
        /// </summary>
        public void Finish()
        {
            CooldownFinishedEvent?.Invoke(this, new CooldownFinishedEvent());
        }
    }
}