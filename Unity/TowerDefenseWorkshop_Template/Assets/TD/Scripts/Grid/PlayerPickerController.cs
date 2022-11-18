namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class PlayerPickerController : MonoBehaviour
	{
		[SerializeField]
		private GridBehaviour _grid = null;

		[SerializeField]
		private GridPicker _gridPicker = null;

		[System.NonSerialized]
		private IPickerGhost _ghost = null;

		[System.NonSerialized]
		private bool _isActive = false;

		public void Activate(bool isActive)
		{
			_isActive = isActive;
			_gridPicker.Activate(isActive, true);
		}

		public void ActivateWithGhost(IPickerGhost ghost)
		{
			_ghost = ghost;
			Activate(true);
		}

		public void DestroyGhost()
		{
			if (_ghost != null)
			{
				Destroy(_ghost.GetTransform().gameObject);
				_ghost = null;
			}
		}

		public bool TrySetGhostAsCellChild()
		{
			if (_gridPicker.TryGetCell(out Cell cell) == true)
			{
				if (cell.HasChild == false)
				{
					if (cell.SetChild(_ghost as ICellChild) == true)
					{
						_ghost = null;
						return true;
					}
				}
			}
			return false;
		}

		private void Update()
		{
			if (_isActive == true)
			{
				if (_gridPicker.TryGetCell(out Cell cell) == true)
				{
					_ghost.GetTransform().position = _grid.GetCellCenter(_gridPicker.CellPosition);
				}
				else if (_ghost != null)
				{
					_ghost.GetTransform().position = _gridPicker.HitPosition;
				}
			}

		}


		[ContextMenu("Activate")]
		private void DoActivate() => Activate(true);

		[ContextMenu("Deactivate")]
		private void DoDeactivate() => Activate(false);

	}
}