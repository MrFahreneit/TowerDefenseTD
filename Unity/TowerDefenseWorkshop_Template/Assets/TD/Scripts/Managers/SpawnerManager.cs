namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public enum SpawnerIndex
	{
		Spawner00,
		Spawner01,
		Spawner02,
	}

	public enum SpawnerStatus
	{
		Inactive = 0,
		WaveRunning
	}

	public class SpawnerManager : MonoBehaviour
	{
		[SerializeField]
		private List<EntitySpawner> _spawners = null;

		[SerializeField]
		private bool _autoStartNextWaves = false;

		[System.NonSerialized]
		private int _currentWaveSetIndex = -1;

		[System.NonSerialized]
		private int _currentWaveRunning = 0;

		[SerializeField]
		public UnityEvent<SpawnerManager, SpawnerStatus, int> WaveStatusChanged_UnityEvent = null;

		[System.NonSerialized]
		private Coroutine _waitForNextWaveCoroutine;

		public delegate void SpawnerEvent(SpawnerManager sender, SpawnerStatus status, int runningWaveCount);
		public event SpawnerEvent WaveStatusChanged = null;


		[SerializeField]
		private GameObject _arrow1 = null;
		[SerializeField]
		private GameObject _arrow2 = null;
		[SerializeField]
		private GameObject _arrow3 = null;

		private WaveDatabase waveDatabase;

		private WaveSet waveSet;

		private float waitingDuration;

		[ContextMenu("Start waves")]
		public void StartWaves()
		{
			// Start a new wave set only if there are no currently a wave running
			if (_currentWaveRunning <= 0)
			{
				StartNewWaveSet();
			}
		}

		public void StartNewWaveSet()
		{
			_currentWaveSetIndex += 1;
			waveDatabase = DatabaseManager.Instance.WaveDatabase;


			_arrow1.SetActive(false);
			_arrow2.SetActive(false);
			_arrow3.SetActive(false);

			if (waveDatabase.Waves.Count > _currentWaveSetIndex)
			{
				waveSet = waveDatabase.Waves[_currentWaveSetIndex];
				List<Wave> waves = waveSet.Waves;

				for (int i = 0, length = _spawners.Count; i < length; i++)
				{
					if (i >= waves.Count)
					{
						Debug.LogWarningFormat("{0}.StartNewWaveSet() There are more spawner ({1}) than wave ({2}), discarding wave.", GetType().Name, _spawners.Count, waves.Count);
						break;
					}
					if (waves[i] == null)
					{
						Debug.LogWarningFormat("{0}.StartNewWaveSet() Null reference found in WaveSet at index {1}, ignoring.", GetType().Name, i);
						break;
					}
					_currentWaveRunning += 1;
					var spawner = _spawners[i];
					spawner.StartWave(waves[i]);
					spawner.WaveEnded.RemoveListener(Spawner_OnWaveEnded);
					spawner.WaveEnded.AddListener(Spawner_OnWaveEnded);

					WaveStatusChanged?.Invoke(this, SpawnerStatus.WaveRunning, _currentWaveRunning);
					WaveStatusChanged_UnityEvent?.Invoke(this, SpawnerStatus.WaveRunning, _currentWaveRunning);
				}
			}
			else
			{
				// No waves left : end game
			}
		}

		private void Spawner_OnWaveEnded(EntitySpawner entitySpawner, Wave wave)
		{
			entitySpawner.WaveEnded.RemoveListener(Spawner_OnWaveEnded);

			_currentWaveRunning -= 1;

			WaveStatusChanged?.Invoke(this, SpawnerStatus.Inactive, _currentWaveRunning);
			WaveStatusChanged_UnityEvent?.Invoke(this, SpawnerStatus.Inactive, _currentWaveRunning);

			// should we run a new wave?
			if (_autoStartNextWaves == true && _currentWaveRunning <= 0)
			{
				// prevent overlapping routines
				if (_waitForNextWaveCoroutine != null)
				{
					StopCoroutine(_waitForNextWaveCoroutine);
				}
				Invoke("ShowArrowEvent", 10f);

				waveDatabase = DatabaseManager.Instance.WaveDatabase;
				waitingDuration = waveDatabase.Waves[_currentWaveSetIndex].WaitingDurationBefore;

				if (_currentWaveSetIndex - 1 > 0)
				{
					waitingDuration += waveDatabase.Waves[_currentWaveSetIndex - 1].WaitingDurationAfter;
				}

				Invoke("StartNewWaveSet", waitingDuration);
				//_waitForNextWaveCoroutine = StartCoroutine(WaitForNewWaveSet());
			}
		}

		private IEnumerator WaitForNewWaveSet()
		{
			waveDatabase = DatabaseManager.Instance.WaveDatabase;
			waitingDuration = waveDatabase.Waves[_currentWaveSetIndex].WaitingDurationBefore;
			
			if (_currentWaveSetIndex - 1 > 0)
			{
				waitingDuration += waveDatabase.Waves[_currentWaveSetIndex - 1].WaitingDurationAfter;
			}

			Debug.LogFormat("Waiting {0} seconds until next wave.", waitingDuration);
			yield return new WaitForSeconds(waitingDuration);


			_waitForNextWaveCoroutine = null;
			StartNewWaveSet();
		}



		private void ShowArrowEvent()
		{

			//1
			if (waveDatabase.Waves[_currentWaveSetIndex].GetArrow1() == true)
			{
				_arrow1.SetActive(true);

			}
			else
			{
				_arrow1.SetActive(false);
			}
			//2
			if (waveDatabase.Waves[_currentWaveSetIndex].GetArrow2() == true)
			{
				_arrow2.SetActive(true);

			}
			else
			{
				_arrow2.SetActive(false);
			}
			//3
			if (waveDatabase.Waves[_currentWaveSetIndex].GetArrow3() == true)
			{
				_arrow3.SetActive(true);

			}
			else
			{
				_arrow3.SetActive(false);
			}
		}

	}

}