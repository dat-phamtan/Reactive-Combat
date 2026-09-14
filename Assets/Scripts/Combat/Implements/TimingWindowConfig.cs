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


    //public readonly struct TimingWindowConfig
    //{
    //    public readonly float earlyStart;
    //    public readonly float earlyEnd;
    //    public readonly float perfectStart;
    //    public readonly float perfectEnd;
    //    public readonly float missStart;
    //    public readonly float missEnd;
    //    public readonly float lateStart;
    //    public readonly float lateEnd;

    //    public TimingWindowConfig(float earlyStart, float earlyEnd, float perfectStart, float perfectEnd, 
    //                              float missStart, float missEnd, float lateStart, float lateEnd)
    //    {
    //        this.earlyStart = earlyStart;
    //        this.earlyEnd = earlyEnd;
    //        this.perfectStart = perfectStart;
    //        this.perfectEnd = perfectEnd;
    //        this.missStart = missStart;
    //        this.missEnd = missEnd;
    //        this.lateStart = lateStart;
    //        this.lateEnd = lateEnd;
    //    }

    //    //public static TimingWindowConfig 
    //}
}
