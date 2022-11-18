namespace GSGD1
{
    using UnityEngine;

    public abstract class AProjectile : MonoBehaviour
    {
		[SerializeField]
		private bool _destroyIfGiveDamage = true;

		[SerializeField]
		private int _damage = 1;

		protected virtual void OnTriggerEnter(Collider other)
		{
			var damageable = other.GetComponentInParent<Damageable>();

			if (damageable != null)
			{
				damageable.TakeDamage(_damage);

				if (_destroyIfGiveDamage == true)
				{
					Destroy(gameObject);
				}
			}
		}
	}
}