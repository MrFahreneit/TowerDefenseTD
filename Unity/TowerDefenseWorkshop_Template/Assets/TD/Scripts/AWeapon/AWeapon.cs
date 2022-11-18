namespace GSGD1
{
	using UnityEngine;

	public abstract class AWeapon : MonoBehaviour
	{
		[SerializeField]
		private Timer _timer = null;

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

	}

}