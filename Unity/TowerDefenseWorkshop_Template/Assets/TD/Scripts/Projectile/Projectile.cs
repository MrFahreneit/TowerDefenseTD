namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Projectile : AProjectile
	{
		[SerializeField]
		private scr_SoundsCaller _ProjectileSpawnSound = null;

		[SerializeField]
		private scr_ParticleSpawner _ProjectileSpawnParticle = null;

		[SerializeField]
		private float _moveSpeed = 5f;

		[SerializeField]
		private float _rotateSpeed = 500f;

		[SerializeField]

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
        }
		private void Update()
		{
			if (_followingTarget == true && _target != null)
			{

			}
            else
            {
				MoveForward();
			}
		}

		private void MoveForward()
		{
			transform.position = transform.position + _moveSpeed * Time.deltaTime * transform.forward;
		}

        private void FixedUpdate()
        {
			if (_followingTarget == true && _target != null)
			{
				HomingMove();
			}
		}

		private void HomingMove()
        {

			if(_target != null)
            {
				//rb.velocity = transform.forward * _moveSpeed;
				//Vector3 _deviatedPrediction = new Vector3(0, 0, 0);
				//Debug.Log(_target);
				//var heading = _target.transform.position - transform.position;
				//var rotation = Quaternion.LookRotation(_target.transform.position);
				//rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));

				//rb.velocity = transform.forward * _moveSpeed;
				//var rotation = Quaternion.LookRotation(_target.transform.position - transform.position);
				//rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
				//Debug.Log(rotation);

				Vector3 targetDirection = _target.GetComponent<Damageable>().GetAimPosition() - transform.position;

				Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _rotateSpeed * Time.deltaTime, 5F);

				transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed, Space.Self);

				transform.rotation = Quaternion.LookRotation(newDirection);
			}
			else
            {
				Debug.Log("epogroi");

			}
		}
    }
}