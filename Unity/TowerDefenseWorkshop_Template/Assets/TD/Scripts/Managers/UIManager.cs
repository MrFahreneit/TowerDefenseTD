namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class UIManager : Singleton<UIManager>
	{
		[SerializeField]
		private scr_UITurretMenu _TurretPlaceMenu;
		[SerializeField]
		private scr_TowerUpgradeCanva _TurretUpgradeMenu;

		private bool _aMenuIsOpen = false;

		public scr_UITurretMenu GetUITurretMenu()
        {
			return _TurretPlaceMenu;

		}

		public scr_TowerUpgradeCanva GetUITowerUpgrade()
        {
			return _TurretUpgradeMenu;
        }

		public bool GetMenuOpen()
        {
			return _aMenuIsOpen;

		}
		public void SetMenuOpen(bool menuOpen)
		{
			_aMenuIsOpen = menuOpen;

		}
	}
}