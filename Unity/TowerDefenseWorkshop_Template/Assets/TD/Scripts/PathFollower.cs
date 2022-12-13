namespace GSGD1
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using Unity.Collections;
	using UnityEngine;

	public class PathFollower : MonoBehaviour
	{

		// Variables 


		[SerializeField]
		private Path _path = null;

		[SerializeField]
		private float _moveSpeed = 1f;

		[SerializeField]
		private float _rotateSpeed = 1f;

		[SerializeField]
		private float _distanceThreshold = 0.5f;

		[SerializeField]
		private int _currentPathIndex = 0;

		[SerializeField]
		private bool _enemyInBase = false;

		[SerializeField]
		private int enemyDamage = 1;

		//Fonctions



		public int GetDamage()
        {
			return enemyDamage;
        }
		public void SetCanMove(bool canMove)
		{
			this.enabled = canMove;
		}

		public void SetPath(Path path, bool teleportToFirstWaypoint = true)
		{
            _path = path;
			if (teleportToFirstWaypoint == true)
			{
				Transform firstWaypoint = _path.FirstWaypoint;
				if (firstWaypoint != null)
				{
                    transform.position = firstWaypoint.position;
				}
			}
		}

		private void Update()
		{
			if(_path.Waypoints.Count <= _currentPathIndex)
            {
				gameObject.transform.position = new Vector3(0, -10, 0);

				if(LevelReferences.Instance.BaseDamageable != null)
                {
					LevelReferences.Instance.BaseDamageable.DamageBase(enemyDamage);
				}
				

				Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
            }

			if (_path == null || _currentPathIndex -1 >= _path.Waypoints.Count)
			{
                _enemyInBase = true;

            }



			if (_path.Waypoints[_currentPathIndex] != null)
            {
				Vector3 nextDestination = _path.Waypoints[_currentPathIndex].position;
				if (Vector3.Distance(transform.position, nextDestination) < _distanceThreshold)
				{
					_currentPathIndex = _currentPathIndex + 1;
					return;

				}
				MoveTo(nextDestination);
				LookAt(nextDestination);

			}




			


        }

		private void MoveTo(Vector3 position)
		{
			Vector3 movement = (position - transform.position).normalized * _moveSpeed * Time.deltaTime;
			transform.position += movement;
		}

		private void LookAt(Vector3 position)
		{
			//transform.LookAt(position, Vector3.up);

			Vector3 direction = position - transform.position;
			direction.y = 0;
			Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
			transform.rotation =  Quaternion.Slerp(transform.rotation, rotation, _rotateSpeed * Time.deltaTime);
		}

		public bool EnemyInBase()
		{
			return _enemyInBase;
		}


	}
}