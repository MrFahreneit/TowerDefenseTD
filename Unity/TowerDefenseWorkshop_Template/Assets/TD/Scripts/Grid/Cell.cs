namespace GSGD1
{
	using UnityEngine;

	public interface ICellChild
	{
		Transform GetTransform();
		void OnSetChild();
	}

	public class Cell : MonoBehaviour
	{
		private ICellChild _towerChild = null;

		public bool HasChild
		{
			get
			{
				return _towerChild != null;
			}
		}

		public bool SetChild(ICellChild cellChild)
		{
			if (cellChild == null)
			{
				return false;
			}
			var childTransform = cellChild.GetTransform();
			childTransform.SetParent(transform);
			childTransform.localPosition = Vector3.zero;
			cellChild.OnSetChild();
			_towerChild = cellChild;

			return true;
		}
	}
}