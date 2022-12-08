using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;
using UnityEngine.Events;

public class scr_SpellForwardReceiver : MonoBehaviour
{
    [SerializeField]
    private Timer _timerReset;

    private int _forwarder = 0;

    [SerializeField]
    private float _timeSpeed = 5f;

    [SerializeField]
    private float speedFactorScale = 0.5f;

    private float _currentScale = 1f;

    public UnityEvent<float> TimerScaleHasChanged;

    public void StartFastForward()
    {

        _forwarder = _forwarder + 1;

        _currentScale = 1 + _forwarder * speedFactorScale;
        _timerReset.Set(_timeSpeed, true);
        _timerReset.Start();
        TimerScaleHasChanged.Invoke(_currentScale);

    }

    // Update is called once per frame
    void Update()
    {
        _timerReset.Update();

        if (_forwarder > 0)
        {
            if (_timerReset.IsRunning == false)
            {
                _timerReset.Stop();
                StopFastForward();
            }
        }
    }

    private void StopFastForward()
    {
        _currentScale = 1f;
        _forwarder = 0;
        TimerScaleHasChanged.Invoke(0);
    }
}
