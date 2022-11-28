namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ProjectileLauncher : AWeapon
	{


		[SerializeField]
		private Transform _projectileAnchor = null;

		protected override void DoFire()
		{

			for (int i = 0; i < _bulletNB; i++)
			{
				
				var instance = Instantiate(_projectile, _projectileAnchor.position, _projectileAnchor.rotation);
				instance.SetDamage(_damageProjectile);
				instance.transform.rotation = Quaternion.Euler(0, Random.Range(_spreadAmount * -1, _spreadAmount), 0) * instance.transform.rotation;
			}
		}

	}



}