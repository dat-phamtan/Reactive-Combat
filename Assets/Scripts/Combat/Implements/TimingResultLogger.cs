using Assets.Scripts.Combat.Interfaces;
using System;
using UnityEngine;
using VContainer.Unity;

namespace Assets.Scripts.Combat.Implements
{
    public class TimingResultLogger : IStartable, IDisposable
    {
        private readonly ITimingSystem _timingSystem;

        public TimingResultLogger(ITimingSystem timingSystem)
        {
            _timingSystem = timingSystem;
        }

        public void Start()
        {
            _timingSystem.OnResult += HandleTimingResult;
        }

        public void Dispose()
        {
            _timingSystem.OnResult -= HandleTimingResult;
        }

        private void HandleTimingResult(TimingResult result)
        {
            //Debug.Log($"{result} at {Time.time}s");
        }
    }
}
