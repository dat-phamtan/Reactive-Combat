using Assets.Scripts.Combat.Implements;
using Assets.Scripts.Combat.Interfaces;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class TimingInputController : MonoBehaviour
{

    [SerializeField] private ReactiveBarView _barView;

    private float _elapsed;
    private float _duration;
    private bool _isTracking;
    private ITimingSystem _timingSystem;
    private ICombatInputProvider _inputProvider;

    public void Construct(ITimingSystem timingSystem, ICombatInputProvider inputProvider)
    {
        _timingSystem = timingSystem;
        _inputProvider = inputProvider;

        _timingSystem.OnResult += HandleResult;
        _inputProvider.OnActionPressed += HandleInput;
    }

    public void BeginWindow(TimingWindowConfig config)
    {
        _elapsed = 0;
        _duration = config.duration;
        _isTracking = true;
        _timingSystem.OpenWindow(config);
        _barView.Show(config.duration);
    }

    public void Update()
    {
        if (!_isTracking)
            return;
        _elapsed += Time.deltaTime;
        _barView.UpdateProgress(_elapsed);

        if (!_timingSystem.IsWindowOpen)
        {
            _isTracking = false;
            return;
        }

        if (_elapsed >= _duration)
        {
            _timingSystem.CloseWindow(_elapsed); 
        }
    }

    private void HandleInput(CombatInputAction action)
    {
        if (!_isTracking || action != CombatInputAction.Confirm)
            return;
        _timingSystem.RegisterInput(_elapsed);
    }

    private void HandleResult(TimingResult result)
    {
        _isTracking = false;
        _barView.ShowResult(result);
    }

    private void OnDestroy()
    {
        _timingSystem.OnResult -= HandleResult;
        _inputProvider.OnActionPressed -= HandleInput;
    }
}
