namespace GSGD1
{
	using UnityEngine;

	[System.Serializable]
	public class Timer
	{
		#region Enums
		public enum State
		{
			Stopping,
			Stopped,
			Started,
			Starting,
			Paused
		}
		#endregion Enums

		#region Fields
		[SerializeField]
		private float _duration = 0f;

		[SerializeField]
		private bool _stopWhenCompleted = true;

		[System.NonSerialized]
		private State _state = State.Stopped;

		[System.NonSerialized]
		private float _remainingTime = 0f;

		[System.NonSerialized]
		private float _progress = 0f;
		#endregion Fields

		#region Events
		public delegate void onStopCallback();
		private onStopCallback _onStopCallback = null;
		public event onStopCallback OnStopCallback
		{
			add
			{
				_onStopCallback -= value;
				_onStopCallback += value;
			}
			remove
			{
				_onStopCallback -= value;
			}
		}

		public delegate void EndCallback();
		private EndCallback _onEndCallback = null;
		public event EndCallback OnEndCallback
		{
			add
			{
				_onEndCallback -= value;
				_onEndCallback += value;
			}
			remove
			{
				_onEndCallback -= value;
			}
		}
		#endregion Events

		#region Properties
		public State CurrentState
		{
			get { return _state; }
		}

		public bool IsRunning
		{
			// return every state where we should have a coherent Progress.
			// We include Started and Stopping in order to have respectively 0 and 1 Progress, otherwise we have only the intermediate values. 
			get { return _state == State.Starting || _state == State.Started || _state == State.Stopping; }
		}

		public float Progress
		{
			get { return _progress; }
		}
		#endregion Properties

		#region Ctor
		public Timer() { }

		public Timer(float duration, bool stopWhenCompleted = true)
		{
			Set(duration, stopWhenCompleted);
		}
		#endregion Ctor

		#region Methods

		#region Public
		public Timer Set(float duration, bool stopWhenCompleted = true)
		{
			_duration = duration;
			_state = State.Stopped;
			_remainingTime = 0f;
			_stopWhenCompleted = stopWhenCompleted;
			OnSet(duration, stopWhenCompleted);
			return this;
		}

		public void Start()
		{
			OnPreStart();
			_state = State.Starting;
		}

		public void Resume()
		{
			_state = State.Started;
			OnResume();
		}

		public void Pause()
		{
			_state = State.Paused;
			OnPause();
		}

		public void Stop()
		{
			Stop(true);
		}

		public bool Update()
		{
			switch (_state)
			{
				case State.Starting:
				{
					_state = State.Started;
					return false;
				}
				case State.Started:
				{
					_remainingTime += Time.deltaTime;
					if (_remainingTime > _duration)
					{
						_remainingTime = _duration;
						_state = State.Stopping;
					}
					_progress = _remainingTime / _duration;
					return false;
				}
				case State.Stopping:
				{
					OnUpdateTimerReached();
					if (_stopWhenCompleted == true)
					{
						Stop();
						_state = State.Stopped;
					}
					else
					{
						_remainingTime = 0f;
						_state = State.Started;
					}
					return true;
				}
				case State.Stopped:
				case State.Paused:
				default: return false;
			}
		}
		#endregion Public

		#region Protected
		protected void Stop(bool throwCallback)
		{
			_state = State.Stopped;
			_remainingTime = _progress = 0f;
			if (throwCallback == true)
			{
				OnStop();
				if (_onStopCallback != null)
				{
					_onStopCallback();
				}
			}
		}

		protected virtual void OnSet(float duration, bool stopWhenCompleted) { }
		protected virtual void OnPreStart() { }
		protected virtual void OnResume() { }
		protected virtual void OnPause() { }
		protected virtual void OnStop() { }
		protected virtual void OnUpdateTimerReached()
		{
			if (_onEndCallback != null)
			{
				_onEndCallback();
			}
		}
		#endregion Protected
		#endregion Methods
	}
}