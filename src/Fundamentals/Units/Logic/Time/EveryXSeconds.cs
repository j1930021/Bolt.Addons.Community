﻿
using Ludiq;
using UnityEngine;

namespace Bolt.Addons.Community.Fundamentals
{
    /// <summary>
    /// Called whenever a specified number of seconds have elapsed.
    /// </summary>
    [UnitCategory("Events\\Time")]
    [RenamedFrom("Bolt.Addons.Community.Logic.Units.OnEveryXSeconds")]
    public sealed class OnEveryXSeconds : GlobalEventUnit, IOnTimerElapsed, IUnityUpdateLoop
    {
        public OnEveryXSeconds() { }

        [DoNotSerialize]
        private float timer;

        [DoNotSerialize]
        private bool triggered;

        [DoNotSerialize]
        private float _seconds;

        /// <summary>
        /// The number of seconds to await.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("Delay")]
        public ValueInput seconds { get; private set; }

        /// <summary>
        /// Whether to ignore the time scale.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("Unscaled")]
        public ValueInput unscaledTime { get; private set; }

        protected override void Definition()
        {
            base.Definition();

            seconds = ValueInput(nameof(seconds), 0f);
            unscaledTime = ValueInput(nameof(unscaledTime), false);
        }

        public override void StartListening()
        {
            base.StartListening();

            timer = 0;
            triggered = false;
            _seconds = seconds.GetValue<float>();
        }

        public void Update()
        {
            if (!isListening)
            {
                return;
            }

            //Requery the time to run for, in case we're wired to a dynamic value.
            _seconds = seconds.GetValue<float>();

            timer += unscaledTime.GetValue<bool>() ? Time.unscaledDeltaTime : Time.deltaTime;

            if (timer >= _seconds)
            {
                timer = 0;
                Trigger();
            }
        }
    }
}