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

		[SerializeField]
		private SphereCollider _colliderRange = null;

		private int _currentLevel = 1;
		private int _maxLevel = 1;

		private float _damageTurretCurrent = 0f;
		private float _attackSpeedCurrent = 0f;
		private int _bulletNumberCurrent = 1;
		private float _spreadCurrent = 0f;
		private float _radiusRange = 5f;

		private scr_UITowerUpgradeMenu _UIUpgradeMenu = null;


		private void Awake()
		{
			enabled = true;
			UpdateStats(false);
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
				_weaponController.GetWeapon().SetTarget(_damageableDetector.GetNearestDamageable().gameObject);
			}
            else
            {
				_weaponController.GetWeapon().SetTarget(null);

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

		private void UpdateStats(bool upgraded)
		{
			if (upgraded == false)
			{
				_damageTurretCurrent = _towerStats.GetDamageDT();
				_attackSpeedCurrent = _towerStats.GetAttackSpeedDT();
				_bulletNumberCurrent = _towerStats.GetbulletLaunchDT();
				_spreadCurrent = _towerStats.GetSpreadDT();
				_radiusRange = _towerStats.GetRadiusDT();
				_maxLevel = _towerStats.GetMaxLevelDT();

				_damageableDetector.SetEntityID(_towerStats.GetTypeTurretDT());
				_weaponController.GetWeapon().SetProjectile(_towerStats.GetProjectileDT());
			}


			_colliderRange.radius = _radiusRange;
			_weaponController.GetWeapon().SetDamage(_damageTurretCurrent);
			_weaponController.GetWeapon().SetAttackSpeed(_attackSpeedCurrent);
			_weaponController.GetWeapon().SetBulletNumber(_bulletNumberCurrent);
			_weaponController.GetWeapon().SetSpread(_spreadCurrent);


			_weaponController.GetWeapon().UpdateWeaponStat();

		}

		public void UpgradingEvent()
		{
			_currentLevel = _currentLevel + 1;
			_damageTurretCurrent = _damageTurretCurrent + _towerStats.GetUpgradeDamagePercentNiv() * _damageTurretCurrent;
			_attackSpeedCurrent = Mathf.Clamp((_attackSpeedCurrent - _towerStats.GetUpgradeAttackSpeedPercentNiv() * _attackSpeedCurrent), 0.1f, 999f);

			UpdateStats(true);
			_UIUpgradeMenu.SetInfoUpgrade(gameObject, this);
		}


		public DT_TowerStats GetDTTurret()
		{
			return _towerStats;
		}

		public int GetCurrentLevel()
		{
			return _currentLevel;
		}
		public float GetDamage()
		{
			return _damageTurretCurrent;

		}
		public float GetDPS()
		{
			return _attackSpeedCurrent;

		}
		public float GetRange()
		{
			return _radiusRange;

		}
		public scr_Type GetEntityType()
		{
			return _typeEntity;

		}
		public void SetInterfaceMenu(scr_UITowerUpgradeMenu _interface)
		{
			_UIUpgradeMenu = _interface;
		}
	}
}