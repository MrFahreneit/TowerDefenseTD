namespace GSGD1
{
	using UnityEngine;

#if UNITY_EDITOR
	using UnityEditor;
#endif //UNITY_EDITOR

	public partial class GridBehaviour : MonoBehaviour
	{
		[SerializeField]
		private int _cellCount = 10;

		[SerializeField]
		private int _cellSize = 1;

		[SerializeField]
		private bool _pivotIsCenter = false;

		private int _previousCellSize = 1;

		public Vector3 GetCellCenter(Vector3 worldCoord)
		{
			// get point
			float cellSize = _cellSize;
			worldCoord.Set(
				Mathf.Floor((worldCoord.x / cellSize) * cellSize),
				Mathf.Floor((worldCoord.y / cellSize) * cellSize),
				Mathf.Floor((worldCoord.z / cellSize) * cellSize)
			);
			return worldCoord + (_pivotIsCenter ? Vector3.zero : Vector3.one * 0.5f);
		}
	}

#if UNITY_EDITOR
	public partial class GridBehaviour : MonoBehaviour
	{
		[SerializeField] private bool _showGrid = true;
		[SerializeField] private bool _resetInfiniteLoopPreventer = true;

		[ExecuteInEditMode]
		private void OnDrawGizmos()
		{
			if (_resetInfiniteLoopPreventer == true)
			{
				return;
			}

			if (_cellSize < 1)
			{
				_cellSize = 1;
			}
			if (_cellCount < 1)
			{
				_cellCount = 1;
			}
			int coeff = 1;
			int modulo = _cellCount % _cellSize;
			if (modulo != 0 && _cellSize != _previousCellSize)
			{
				if (_previousCellSize > _cellSize)
				{
					coeff = 1;
				}
				else
				{
					coeff = -1;
				}
			}
			int iterationCount = 0;
			while (modulo != 0)
			{
				modulo = Mathf.Clamp(_cellCount, 1, int.MaxValue) % (++_cellSize * coeff);

				if (++iterationCount > 1000)
				{
					_resetInfiniteLoopPreventer = false;
					break;
				}
			}
			_previousCellSize = _cellSize;

			//Debug.LogFormat(
			//	"{0} % {1} == {2} | previous : {3}",
			//	_cellCount,
			//	_cellSize,
			//	_cellCount % _cellSize,
			//	_previousCellSize
			//);

			if (_showGrid == true)
			{
				Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

				Handles.color = Color.blue;
				int xPos = Mathf.RoundToInt(transform.position.x);
				int zPos = Mathf.RoundToInt(transform.position.z);
				for (int x = 0; x <= _cellCount; x += _cellSize)
				{
					int xPosAdded = x + xPos;
					Handles.DrawLine(new Vector3(xPosAdded, 0, zPos), new Vector3(xPosAdded, 0, _cellCount + zPos));
				}
				for (int z = 0; z <= _cellCount; z += _cellSize)
				{
					int zPosAdded = z + zPos;
					Handles.DrawLine(new Vector3(xPos, 0, zPosAdded), new Vector3(_cellCount + xPos, 0, zPosAdded));
				}
			}
		}
	}
#endif //UNITY_EDITOR
}
