namespace GSGD1
{
	using UnityEngine;

#if UNITY_EDITOR
	using UnityEditor;
#endif //UNITY_EDITOR

	public class GridPicker : MonoBehaviour
	{
		[SerializeField]
		private Transform _highlighter = null;

		[SerializeField]
		private GridBehaviour _grid = null;

		[SerializeField]
		private LayerMask _layerMask;

		private Vector3 _hitPosition = Vector3.zero;
		private Vector3 _cellPosition = Vector3.zero;
		private Transform _computedGridPosition = null;

		private Cell _lastFoundCell = null;

		public Transform GetGridPosition
		{
			get
			{
				if (enabled == true && _computedGridPosition == null)
				{
					_computedGridPosition = ComputeGridPosition();
				}
				return _computedGridPosition;
			}
		}

		public Vector3 HitPosition
		{
			get
			{
				return _hitPosition;
			}
		}

		public Vector3 CellPosition
		{
			get
			{
				return _cellPosition;
			}
		}

		public Cell LastFoundCell
		{
			get
			{
				return _lastFoundCell;
			}
		}

		private void OnDestroy()
		{
			_computedGridPosition = null;
		}

		private void LateUpdate()
		{
			_computedGridPosition = null;
			_lastFoundCell = null;
		}

		public bool TryGetCell(out Cell cell)
		{
			Transform hitTransform = GetGridPosition;
			if (hitTransform != null)
			{
				_lastFoundCell = cell = hitTransform.GetComponentInParent<Cell>();
				return cell != null;
			}
			return cell = null;
		}
		public void Activate(bool isActive, bool showHighlighter = true)
		{
			enabled = isActive;
			if (_highlighter != null)
			{
				_highlighter.gameObject.SetActive(isActive && showHighlighter);
			}
			_computedGridPosition = null;
		}

		private Transform ComputeGridPosition()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, float.MaxValue, _layerMask))
			{
				Vector3 highlightPosition = _grid.GetCellCenter(hit.point);
				highlightPosition.y = hit.point.y /*+ 0.1f*/;

				_cellPosition = highlightPosition;
				_hitPosition = hit.point;
				if (_highlighter != null)
				{
					_highlighter.transform.position = highlightPosition;
					_highlighter.gameObject.SetActive(true);
				}

				//Debug.Log(hit.transform.name);

				return hit.transform;
			}
			else
			{
				if (_highlighter != null)
				{
					_highlighter.gameObject.SetActive(false);
				}
				//Debug.Log("found nothing");
				return null;
			}
		}

		#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			var color = Handles.color;
			Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
			Handles.color = Color.blue;
			{
				Camera cam = Camera.main;
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				Handles.DrawLine(ray.origin, ray.origin + (ray.direction * 100));
			}
			Handles.color = color;
		}
		#endif //UNITY_EDITOR

	}
}
