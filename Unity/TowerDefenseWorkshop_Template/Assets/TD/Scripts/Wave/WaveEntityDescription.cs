namespace GSGD1
{
	using UnityEngine;

	[System.Serializable]
	public class WaveEntityDescription
	{
		[SerializeField]
		private EntityType _entityType = EntityType.None;

		[SerializeField]
		private float _extraDurationAfterSpawned = 0;

		public EntityType EntityType
		{
			get
			{
				return _entityType;
			}
		}

		public float ExtraDurationAfterSpawned
		{
			get
			{
				return _extraDurationAfterSpawned;
			}
		}
	}
}