namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public class ProjectileLauncher : AWeapon
	{


		[SerializeField]
		private Transform _projectileAnchor = null;
		public UnityEvent ShootUnityEvent;

		protected override void DoFire()
		{
			ShootUnityEvent.Invoke();

			for (int i = 0; i < _bulletNB; i++)
			{
				
				var instance = Instantiate(_projectile, _projectileAnchor.position, _projectileAnchor.rotation);
				instance.SetDamage(_damageProjectile);
				instance.SetProjectileTarget(_targetWeapon);
				instance.transform.rotation = Quaternion.Euler(0, Random.Range(_spreadAmount * -1, _spreadAmount), 0) * instance.transform.rotation;
			}
		}

	}



}