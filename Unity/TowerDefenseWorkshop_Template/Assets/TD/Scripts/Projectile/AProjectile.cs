namespace GSGD1
{
    using UnityEngine;

    public abstract class AProjectile : MonoBehaviour
    {
		[SerializeField]
		private bool _destroyIfGiveDamage = true;

		[SerializeField]
		private float _damage = 1f;
		[SerializeField]
		private bool isDot = false;

		[SerializeField]
		private bool doDamage = true;

		[SerializeField]
		private GameObject _ActorSpawnOnDeath = null;

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (isDot == false)
            {
				var damageable = other.GetComponentInParent<Damageable>();

				if (damageable != null)
				{
					if (doDamage == true)
					{
						damageable.TakeDamage(_damage);
					}

					if (_destroyIfGiveDamage == true)
					{
						if (_ActorSpawnOnDeath != null)
						{
							var instance = Instantiate(_ActorSpawnOnDeath, gameObject.transform.position, Quaternion.identity);
							instance.GetComponentInParent<scr_Explosion>().InitializeDamage(_damage);
						}
						Destroy(gameObject);
					}
				}
			}


		}

		public void SetDamage(float newDamage)
		{
			_damage = newDamage;
		}

        private void Start()
        {
			if (isDot == true)
            {

            }
		}
    }
}