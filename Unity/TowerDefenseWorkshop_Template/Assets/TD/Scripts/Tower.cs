namespace GSGD1
{
	using GSGD1;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Facade for Tower subsystems
	/// </summary>
	public class Tower : MonoBehaviour, IPickerGhost, ICellChild
	{
		[SerializeField]
		private WeaponController _weaponController = null;

		[SerializeField]
		private DamageableDetector _damageableDetector = null;

		[SerializeField]
		private scr_Type _typeEntity = null;

		[SerializeField]
		private DT_TowerStats _towerStats = null;


		private void Awake()
		{
			enabled = true;
			_damageableDetector.SetEntityID(_typeEntity.GetEntityType());
			UpdateStats();
		}

		public void Enable(bool isEnabled)
		{
			enabled = isEnabled;
		}

		private void Update()
		{
			if (_damageableDetector.HasAnyDamageableInRange() == true)
			{
				Damageable damageableTarget = _damageableDetector.GetNearestDamageable();
				//_weaponController.LookAt(damageableTarget.GetAimPosition());
				//_weaponController.Fire();

				_weaponController.LookAtAndFire(damageableTarget.GetAimPosition());
			}
		}

		// Interfaces
		public Transform GetTransform()
		{
			return transform;
		}

		public void OnSetChild()
		{
			Enable(true);
		}

		private void UpdateStats()
        {
			_weaponController.GetWeapon().SetDamage(_towerStats.GetDamageDT());

		}
	}
}