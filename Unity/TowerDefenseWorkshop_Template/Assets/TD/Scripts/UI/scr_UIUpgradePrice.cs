using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GSGD1;

public class scr_UIUpgradePrice : MonoBehaviour
{
    [SerializeField]
    private scr_UITowerUpgradeMenu _upgradeMenuInfo;

    [SerializeField]
    private TextMeshProUGUI _priceText;

    [SerializeField]
    private Button _upgradeButton;

    private void Update()
    {
        if(_upgradeMenuInfo.GetDTTowerStats() != null && _upgradeMenuInfo.GetTowerPrefab() != null)
        {
            int currentLevel = _upgradeMenuInfo.GetTowerPrefab().GetComponentInParent<Tower>().GetCurrentLevel();



            if(currentLevel == 1)
            {
                _priceText.text = _upgradeMenuInfo.GetDTTowerStats().GetUpgradePrice1().ToString();

                if(LevelReferences.Instance.Manager_Economic.GetGold() >= _upgradeMenuInfo.GetDTTowerStats().GetUpgradePrice1())
                {
                    _upgradeButton.interactable = true;
                }
                else
                {
                    _upgradeButton.interactable = false;
                }
            }
            if(currentLevel == 2)
            {
                _priceText.text = _upgradeMenuInfo.GetDTTowerStats().GetUpgradePrice2().ToString();

                if (LevelReferences.Instance.Manager_Economic.GetGold() >= _upgradeMenuInfo.GetDTTowerStats().GetUpgradePrice2())
                {
                    _upgradeButton.interactable = true;
                }
                else
                {
                    _upgradeButton.interactable = false;
                }
            }


        }
    }
}
