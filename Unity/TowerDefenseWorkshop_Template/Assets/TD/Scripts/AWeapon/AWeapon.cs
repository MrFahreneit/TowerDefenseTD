namespace GSGD1
{
	using UnityEngine;

	public abstract class AWeapon : MonoBehaviour
	{
		[SerializeField]
		private Timer _timer = null;

		[SerializeField]
		protected AProjectile _projectile = null;

		[SerializeField]
		protected float _damageProjectile = 1f;
		[SerializeField]
		protected float _attackspeed = 1;
		[SerializeField]
		protected int _bulletNB = 1;
		[SerializeField]
		protected float _spreadAmount = 0f;

		[SerializeField]
		protected GameObject _targetWeapon = null;

		public virtual bool CanFire()
		{
			return _timer.IsRunning == false;
		}

		protected virtual void Update()
		{
			_timer.Update();
		}
		public void Fire()
		{
			if (CanFire() == true)
			{
				_timer.Start();
				DoFire();
			}
		}

		protected abstract void DoFire();

		public void UpdateWeaponStat()
        {
			_timer.Start();
			_timer.Set(_attackspeed, true);
		}

		public void SetDamage(float newDamage)
        {
			_damageProjectile = newDamage;
		}
		public void SetBulletNumber(int newBulletNumber)
        {
			_bulletNB = newBulletNumber;
		}
		public void SetSpread(float newSpread)
		{
			_spreadAmount = newSpread;
		}
		public void SetAttackSpeed(float newSpeed)
        {
			_attackspeed = newSpeed;
        }

		public void SetProjectile(AProjectile newProjectile)
		{
			_projectile = newProjectile;

		}
		public void SetTarget(GameObject newTarget)
        {
			_targetWeapon = newTarget;

		}
	}
}