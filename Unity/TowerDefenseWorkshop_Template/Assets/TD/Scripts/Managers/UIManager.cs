namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class UIManager : Singleton<UIManager>
	{
		[SerializeField]
		private scr_UITurretMenu _TurretMenu;

		public scr_UITurretMenu GetUITurretMenu()
        {
			return _TurretMenu;

		}
	}
}