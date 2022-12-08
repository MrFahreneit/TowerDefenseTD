namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class LevelReferences : Singleton<LevelReferences>
	{
		[SerializeField]
		private PlayerPickerController _playerPickerController = null;

		[SerializeField]
		private SpawnerManager _spawnerManager = null;

		[SerializeField]
		private scr_Manager_Economic _EconomicManager = null;

		[SerializeField]
		private scr_baseDamageable _BaseDamageable = null;

		[SerializeField]
		private scr_PlanteCraftEconomic _planteCraftEconomic = null;

		public PlayerPickerController PlayerPickerController => _playerPickerController;
		public SpawnerManager SpawnerManager => _spawnerManager;
		public scr_Manager_Economic Manager_Economic => _EconomicManager;
		public scr_baseDamageable BaseDamageable => _BaseDamageable;
		public scr_PlanteCraftEconomic PlanteCraftEconomic => _planteCraftEconomic;
	}
}