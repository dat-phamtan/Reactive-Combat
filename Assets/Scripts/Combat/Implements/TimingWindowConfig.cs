using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Combat.Implements
{
    public struct TimingWindowConfig
    {
        public float duration;
        public float perfectRatio;

        public TimingWindowConfig(float duration, float perfectRatio)
        {
            this.duration = duration;
            this.perfectRatio = perfectRatio;
        }
    }
}
