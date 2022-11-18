namespace GSGD1
{
	using UnityEngine;
	using UnityEngine.Assertions;
	using System.Collections;

	/// <summary>
	/// Est l'objet en charge de garder les références vers nos databases (ici des scriptable object).
	/// </summary>

	public class DatabaseManager : Singleton<DatabaseManager>
	{
		[SerializeField] private WaveDatabase _waveDatabase = null;

		public WaveDatabase WaveDatabase
		{
			get
			{
				return _waveDatabase;
			}
		}
	}
}
