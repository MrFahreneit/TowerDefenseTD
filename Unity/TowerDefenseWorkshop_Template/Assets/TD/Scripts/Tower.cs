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

		private float _damageTurretCurrent = 0f;
		private float _attackSpeedCurrent = 0f;
		private int _bulletNumberCurrent = 1;
		private float _spreadCurrent = 0f;

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
			_damageTurretCurrent = _towerStats.GetDamageDT();
			_attackSpeedCurrent = _towerStats.GetAttackSpeedDT();
			_bulletNumberCurrent = _towerStats.GetbulletLaunchDT();
			_spreadCurrent = _towerStats.GetSpreadDT();


			_weaponController.GetWeapon().SetDamage(_damageTurretCurrent);
			_weaponController.GetWeapon().SetAttackSpeed(_attackSpeedCurrent);
			_weaponController.GetWeapon().SetBulletNumber(_bulletNumberCurrent);
			_weaponController.GetWeapon().SetSpread(_spreadCurrent);

			
			_weaponController.GetWeapon().UpdateWeaponStat();

		}
	}
}