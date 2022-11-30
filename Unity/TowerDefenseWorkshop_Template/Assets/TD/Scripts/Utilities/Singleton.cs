namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance = null;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = CheckForMultipleInstances();
				}
				return _instance;
			}
		}

		public static bool HasInstance
		{
			get
			{
				return _instance != null;
			}
		}

		protected virtual void Awake()
		{
			_instance = CheckForMultipleInstances();
		}

		protected virtual void Start() { }
		protected virtual void OnEnable() { }
		protected virtual void Update() { }
		protected virtual void LateUpdate() { }
		protected virtual void OnDisable() { }

		protected virtual void OnDestroy()
		{
			_instance = null;
		}

		private static T CheckForMultipleInstances()
		{
			T[] instances = FindObjectsOfType<T>();

			if (instances == null || instances.Length < 1)
			{
				throw new System.Exception(string.Format(" There is no instance of {0}.", typeof(T)));
			}

			if (instances.Length > 1)
			{
				throw new System.Exception(string.Format(" There is more than one instance of {0}.", typeof(T)));
			}
			return instances[0];
		}
	}
}