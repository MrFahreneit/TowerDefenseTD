namespace GSGD1
{
    using UnityEngine;

    public abstract class AProjectile : MonoBehaviour
    {
		[SerializeField]
		private bool _destroyIfGiveDamage = true;

		[SerializeField]
		private float _dotDelay = 0.25f;

		[SerializeField]
		private float _lifeTime = 5f;

		[SerializeField]
		private float _damage = 1f;
		[SerializeField]
		private bool isDot = false;
		[SerializeField]
		private SphereCollider _collider = null;

		[SerializeField]
		private bool doDamage = true;

		[SerializeField]
		private GameObject _ActorSpawnOnDeath = null;

		[SerializeField]
		private scr_FragSpawner _frag = null;

		[SerializeField]
		protected bool _followingTarget = false;
		protected GameObject _target = null;

		private Collider[] hitColliders = null;
		private bool hasSpawned = false;

		[SerializeField]
		protected scr_SoundsCaller _ProjectileSpawnSound = null;

		[SerializeField]
		protected scr_ParticleSpawner _ProjectileSpawnParticle = null;

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (isDot == false)
            {
				var damageable = other.GetComponentInParent<Damageable>();

				if (damageable != null && damageable.GetInviciFrame() == false)
				{
					if (doDamage == true)
					{
						damageable.TakeDamage(_damage);
					}

					if (_destroyIfGiveDamage == true)
					{
						if (_ActorSpawnOnDeath != null && hasSpawned == false)
						{
							hasSpawned = true;
							var instance = Instantiate(_ActorSpawnOnDeath, gameObject.transform.position, Quaternion.identity);
							if (instance.GetComponentInParent<scr_Explosion>() == true)
							{
								instance.GetComponentInParent<scr_Explosion>().InitializeDamage(_damage);
								instance.GetComponentInParent<scr_Explosion>().SetHooked(_target);

							}
							if (instance.GetComponentInParent<AProjectile>() == true)
							{
								instance.GetComponentInParent<AProjectile>().SetDamage(_damage);
							}

						}

						if (_frag != null)
						{
								_frag.SpawnFrag();

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
		public float GetDamage()
        {
			return _damage;

		}
		public void SetProjectileTarget(GameObject newTarget)
        {
			_target = newTarget;

		}


		private void Start()
        {
			if (_ProjectileSpawnSound != null)
			{
				_ProjectileSpawnSound.SpawnSound(true);
			}

			if (_ProjectileSpawnParticle != null)
			{
				_ProjectileSpawnParticle.SpawnParticle();
			}


			Invoke("LifeTimeEnd", _lifeTime);

			if (isDot == true)
            {
				DotDamage();
            }
		}


		private void DotDamage()
        {

			hitColliders = null;

			hitColliders = Physics.OverlapSphere(gameObject.transform.position, _collider.radius);

			foreach (var hitCollider in hitColliders)
			{
				Debug.Log(hitCollider);
				if (hitCollider.GetComponentInParent<Damageable>() == true)
				{
					hitCollider.GetComponentInParent<Damageable>().TakeDamage(_damage);

				}

			}
			hitColliders = null;

			Invoke("DotDamage", _dotDelay);
        }

		private void LifeTimeEnd()
        {
			if (_ActorSpawnOnDeath != null && hasSpawned == false)
			{
				hasSpawned = true;
				var instance = Instantiate(_ActorSpawnOnDeath, gameObject.transform.position, Quaternion.identity);
				if (instance.GetComponentInParent<scr_Explosion>() == true)
				{
					instance.GetComponentInParent<scr_Explosion>().InitializeDamage(_damage);

				}
				if (instance.GetComponentInParent<AProjectile>() == true)
				{
					instance.GetComponentInParent<AProjectile>().SetDamage(_damage);
				}

			}
			if (_frag != null)
			{
				_frag.SpawnFrag();

			}
			Destroy(gameObject);
        }
    }
}