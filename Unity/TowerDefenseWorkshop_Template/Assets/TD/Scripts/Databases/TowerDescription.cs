namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(menuName = "GameSup/Tower Description", fileName ="TowerDescription")]
	public class TowerDescription : ScriptableObject
	{
		[SerializeField]
		private Tower _prefab = null;

		[SerializeField]
		private Sprite _icon = null;

		[SerializeField]
		private Color _iconColor = Color.white;

		public Tower Prefab => _prefab;
		public Sprite Icon => _icon;
		public Color IconColor => _iconColor;

		public Tower Instantiate()
		{
			return GameObject.Instantiate(_prefab);
		}
	}
}