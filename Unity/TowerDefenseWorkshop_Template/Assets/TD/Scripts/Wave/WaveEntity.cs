namespace GSGD1
{
	using GSGD1;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class WaveEntity : MonoBehaviour
	{
		[SerializeField]
		private PathFollower _pathFollower = null;

		public void SetPath(Path path, bool teleportToFirstWaypoint = true)
		{
			_pathFollower.SetPath(path, teleportToFirstWaypoint);
		}
	}
}