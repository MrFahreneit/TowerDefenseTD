namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ProjectileLauncher : AWeapon
	{
		[SerializeField]
		private AProjectile _projectile = null;

		[SerializeField]
		private Transform _projectileAnchor = null;

		protected override void DoFire()
		{
			var instance = Instantiate(_projectile, _projectileAnchor.position, _projectileAnchor.rotation);
		}
	}
}