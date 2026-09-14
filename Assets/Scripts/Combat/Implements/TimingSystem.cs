using Assets.Scripts.Combat.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Combat.Implements
{
    public class TimingSystem : ITimingSystem
    {
        private TimingWindowConfig _timeConfig;
        private bool _alreadyEvaluated;
        public event Action<TimingResult> OnResult;

        public bool IsWindowOpen { get; private set; }
        
        

        public void OpenWindow(TimingWindowConfig timeConfig)
        {
            _timeConfig = timeConfig;
            _alreadyEvaluated = false;
            IsWindowOpen = true;
        }

        public void RegisterInput(float elapsedSinceWindowOpen)
        {
            if (!IsWindowOpen || _alreadyEvaluated)
                return;

            var result = ClassifyTimingResult(elapsedSinceWindowOpen);
            EvaluateTimingResult(result);

        }

        public void CloseWindow(float elapsedSinceWindowOpen)
        {
            if (!IsWindowOpen || _alreadyEvaluated)
                return;

            EvaluateTimingResult(TimingResult.Miss);
        }


        //helper
        private TimingResult ClassifyTimingResult(float time)
        {
            float normalTime = _timeConfig.duration * (1 - _timeConfig.perfectRatio);
            if (time >= _timeConfig.duration)
                return TimingResult.Miss;

            if (time <= normalTime)
                return TimingResult.Normal;
            else
                return TimingResult.Perfect;
        }

        private void EvaluateTimingResult(TimingResult result)
        {
            _alreadyEvaluated = true;
            IsWindowOpen = false;
            OnResult?.Invoke(result);
        }
    }
}
