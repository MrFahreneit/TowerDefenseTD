namespace GSGD1
{
	using UnityEngine;
	using UnityEngine.Events;

	public class Damageable : MonoBehaviour
	{
		[SerializeField]
		private float _health = 1f;

		[SerializeField]
		private bool _destroyIfKilled = true;

		[SerializeField]
		private Transform _aimPosition = null;

		[SerializeField]
		private scr_Type _enemyType = null;
		private int _enemyTypeID = 0;

		[SerializeField]
		private bool _inviciFrame = false;


		public delegate void DamageableEvent(Damageable caller, float currentHealth, float damageTaken);
		private event DamageableEvent _damageTaken = null;

		public event DamageableEvent DamageTaken
		{
			add
			{
				_damageTaken -= value;
				_damageTaken += value;
			}
			remove
			{
				_damageTaken -= value;
			}
		}

		public UnityEvent DamageTakenUnityEvent;

		public Vector3 GetAimPosition()
		{
			return _aimPosition.position;
		}

		public void TakeDamage(float damage)
		{
			if(_inviciFrame == false)
            {
				_health -= damage;

				_inviciFrame = true;

				Invoke("RemoveInviciFrame", 0.12f);

				if (_health <= 0)
				{
					_damageTaken?.Invoke(this, _health, damage);


					if (_destroyIfKilled == true)
					{
						DoDestroy();
					}

				}
                else
                {
					DamageTakenUnityEvent.Invoke();
				}

			}


		}

		private void DoDestroy()
		{
			Destroy(gameObject);
		}

        private void Start()
        {
			_enemyTypeID = _enemyType.GetEntityType();
		}

		public int GetEntityID()
        {
			return _enemyTypeID;

		}

		private void RemoveInviciFrame()
        {
			_inviciFrame = false;

		}

		public bool GetInviciFrame()
        {
			return _inviciFrame;
		}
    }
}