namespace GSGD1
{
	using UnityEngine;

	[System.Serializable]
	public class WaveEntityData
	{
		[SerializeField]
		private WaveEntity _waveEntityPrefab = null;

		[SerializeField]
		private EntityType _entityType = EntityType.None;

		public WaveEntity WaveEntityPrefab => _waveEntityPrefab;
		public EntityType EntityType => _entityType;
	}
}