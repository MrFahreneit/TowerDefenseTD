using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GSGD1;

public class scr_UIPlanteUpgrade : MonoBehaviour
{
    [SerializeField]
    private scr_UITowerUpgradeMenu _upgradeMenuInfo;

    [SerializeField]
    private TextMeshProUGUI _planteAPrice;
    [SerializeField]
    private TextMeshProUGUI _planteBPrice;
    [SerializeField]
    private TextMeshProUGUI _planteCPrice;

    [SerializeField]
    private Button _planteAPriceButton;
    [SerializeField]
    private Button _planteBPriceButton;
    [SerializeField]
    private Button _planteCPriceButton;

    void Update()
    {
        if (_upgradeMenuInfo.GetDTTowerStats() != null && _upgradeMenuInfo.GetTowerPrefab() != null)
        {
            int currentLevel = _upgradeMenuInfo.GetTowerPrefab().GetComponentInParent<Tower>().GetCurrentLevel();



            if (currentLevel == 3)
            {
                _planteAPrice.text = _upgradeMenuInfo.GetDTTowerStats().GetPlantePrice().x.ToString();
                _planteBPrice.text = _upgradeMenuInfo.GetDTTowerStats().GetPlantePrice().y.ToString();
                _planteCPrice.text = _upgradeMenuInfo.GetDTTowerStats().GetPlantePrice().z.ToString();

                if ((int)_upgradeMenuInfo.GetDTTowerStats().GetPlantePrice().x <= LevelReferences.Instance.Manager_Economic.GetPlanteA())
                {
                    _planteAPriceButton.interactable = true;
                }
                else
                {
                    _planteAPriceButton.interactable = false;
                }

                if ((int)_upgradeMenuInfo.GetDTTowerStats().GetPlantePrice().y <= LevelReferences.Instance.Manager_Economic.GetPlanteB())
                {
                    _planteBPriceButton.interactable = true;
                }
                else
                {
                    _planteBPriceButton.interactable = false;
                }

                if ((int)_upgradeMenuInfo.GetDTTowerStats().GetPlantePrice().z <= LevelReferences.Instance.Manager_Economic.GetPlanteC())
                {
                    _planteCPriceButton.interactable = true;
                }
                else
                {
                    _planteCPriceButton.interactable = false;
                }
            }
        }
    }
}
