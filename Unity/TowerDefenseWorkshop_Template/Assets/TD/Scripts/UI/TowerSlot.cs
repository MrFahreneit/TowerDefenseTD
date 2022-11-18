namespace GSGD1
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class TowerSlot : MonoBehaviour
	{
		[SerializeField]
		private TowerDescription _towerDescription = null;

		[SerializeField]
		private Button _button = null;

		[SerializeField]
		private Image _icon = null;

		public TowerDescription TowerDescription => _towerDescription;

		public delegate void TowerSlotEvent(TowerSlot sender);
		public event TowerSlotEvent OnTowerSlotClicked = null;

		private void Awake()
		{
			UpdateSlot();
		}

		[ContextMenu("Update Slot")]
		public void UpdateSlot()
		{
			if (_towerDescription == null)
			{
				Debug.LogErrorFormat("{0}.UpdateSlot() Missing _towerDescription reference in {1}.", GetType().Name, name);
				return;
			}

			_icon.sprite = _towerDescription.Icon;
			_icon.color = _towerDescription.IconColor;
		}

		private void OnEnable()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
			_button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			OnTowerSlotClicked?.Invoke(this);
		}
	}
}