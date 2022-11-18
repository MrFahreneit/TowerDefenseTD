namespace GSGD1
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public class EntitySpawner : MonoBehaviour
	{
		[SerializeField]
		private Transform _instancesRoot = null;

		[SerializeField]
		private Path _path = null;

		[System.NonSerialized]
		private Timer _timer = new Timer();

		[System.NonSerialized]
		private Wave _wave = null;

		[System.NonSerialized]
		private List<WaveEntity> _runtimeWaveEntities = new List<WaveEntity>();

		public UnityEvent<EntitySpawner, Wave> WaveStarted = null;
		public UnityEvent<EntitySpawner, Wave> WaveEnded = null;
		public UnityEvent<EntitySpawner, WaveEntity> EntitySpawned = null;

		//public event System.Action<EntitySpawner, WaveEntity> EntityDestroyed = null;

		public void StartWave(Wave wave)
		{
			_wave = new Wave(wave);
			_timer.Set(wave.DurationBetweenSpawnedEntity).Start();
			WaveStarted?.Invoke(this, wave);
			InstantiateNextWaveElement();
		}

		private WaveEntity InstantiateEntity(WaveEntity entityPrefab)
		{
			WaveEntity entityInstance = Instantiate(entityPrefab, _instancesRoot);
			_runtimeWaveEntities.Add(entityInstance);
			EntitySpawned?.Invoke(this, entityInstance);
			return entityInstance;
		}

		private void InstantiateNextWaveElement()
		{
			if (_wave.HasWaveElementsLeft == true)
			{
				var nextEntity = _wave.GetNextWaveElement();

				if (DatabaseManager.Instance.WaveDatabase.GetWaveElementFromType(nextEntity.EntityType, out WaveEntity outEntity) == true)
				{
					outEntity = InstantiateEntity(outEntity);
					outEntity.SetPath(_path);
					_timer.Set(_wave.DurationBetweenSpawnedEntity + nextEntity.ExtraDurationAfterSpawned).Start();
				}
				else
				{
					Debug.LogErrorFormat("{0}.UpdateWave() cannot GetWaveElementFromType {1}, no corresponding type found in database.", GetType().Name, nextEntity.EntityType);
					return;
				}
			}
			else
			{
				WaveEnded?.Invoke(this, _wave);
			}
		}

		private void Update()
		{
			UpdateWave();
		}

		private void UpdateWave()
		{
			if (_timer != null)
			{
				bool shouldInstantiateEntity = _timer.Update();

				if (shouldInstantiateEntity == true)
				{
					InstantiateNextWaveElement();
				}
			}
		}
	}
}