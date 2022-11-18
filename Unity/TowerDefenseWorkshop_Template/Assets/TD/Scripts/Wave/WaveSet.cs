namespace GSGD1
{
	using System.Collections.Generic;
	using UnityEngine;

#if UNITY_EDITOR
	using UnityEditor;
#endif //UNITY_EDITOR

	[CreateAssetMenu(menuName = "GameSup/WaveSet")]
	public class WaveSet : ScriptableObject
	{
		[Header("Wave index is the spawner index : _waves[0] will be spawner00, _wave[1] spawner01, etc...")]
		[SerializeField]
		private List<Wave> _waves = null;

		[SerializeField]
		private float _waitingDurationBefore = 0f;

		[SerializeField]
		private float _waitingDurationAfter = 5f;

		public List<Wave> Waves => _waves;

		public float WaitingDurationBefore => _waitingDurationBefore;
		public float WaitingDurationAfter => _waitingDurationAfter;

		public float GetWaveDuration()
		{
			float duration = 0;
			for (int i = 0, length = _waves.Count; i < length; i++)
			{
				duration += _waves[i].GetWaveDuration();
			}
			return duration + _waitingDurationBefore + _waitingDurationAfter;
		}
	}

#if UNITY_EDITOR
	[CustomEditor(typeof(WaveSet))]
	public class WaveSetEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			serializedObject.Update();

			var waveDatabase = (serializedObject.targetObject as WaveSet);

			EditorGUILayout.Space(24);
			EditorGUILayout.TextArea(string.Format("Duration : {0} seconds", waveDatabase.GetWaveDuration().ToString()));
		}
	}
#endif //UNITY_EDITOR

}