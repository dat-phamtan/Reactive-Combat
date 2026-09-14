using Assets.Scripts.Combat.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class TimingInputController : MonoBehaviour
{
    
    [SerializeField] private float _base;

    private ITimingSystem _timingSystem;

    public void Construct(ITimingSystem timingSystem)
    {
        _timingSystem = timingSystem;
    }

    private void Update()
    {
        
    }

    public void OnImpactFrame(flo)
}
