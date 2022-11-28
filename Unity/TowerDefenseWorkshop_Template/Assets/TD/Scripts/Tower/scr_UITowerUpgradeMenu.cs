using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;
using UnityEngine.UI;
using TMPro;

public class scr_UITowerUpgradeMenu : MonoBehaviour
{
    private GameObject _towerUpgraded;
    private DT_TowerStats _towerStats;

    [SerializeField]
    private TextMeshProUGUI _turretType = null;
    [SerializeField]
    private TextMeshProUGUI _turretName = null;
    [SerializeField]
    private TextMeshProUGUI _turretDamage = null;
    [SerializeField]
    private TextMeshProUGUI _turretDPS = null;
    [SerializeField]
    private TextMeshProUGUI _turretRange = null;

    [SerializeField]
    private GameObject _upgradeMenuMain = null;
    [SerializeField]
    private GameObject _upgradeMenuBasic = null;
    [SerializeField]
    private GameObject _upgradeMenuSpe = null;

    private Tower _towerInfo = null;

    public void SetInfoUpgrade(GameObject upgradedTower, Tower towerInfo)
    {
        _towerInfo = towerInfo;
        _towerInfo.SetInterfaceMenu(this);

        if (towerInfo.GetEntityType().GetEntityType() == 0)
        {
            _turretType.text = "Ground";
        }
        else if(towerInfo.GetEntityType().GetEntityType() == 1)
        {
            _turretType.text = "Air";
        }
        else if (towerInfo.GetEntityType().GetEntityType() == 2)
        {
            _turretType.text = "Ground And Air";
        }

        _turretName.text = towerInfo.GetDTTurret().GetName() + " Niv" + towerInfo.GetCurrentLevel();
        _turretDamage.text = "Power :" + towerInfo.GetDamage();
        _turretDPS.text = "DPS :" + towerInfo.GetDPS();
        _turretRange.text = "Range :" + towerInfo.GetRange();

        if(towerInfo.GetCurrentLevel() < towerInfo.GetDTTurret().GetMaxLevelDT() || towerInfo.GetDTTurret().GetCanEvolve() == true)
        {
            _upgradeMenuMain.SetActive(true);
            if(towerInfo.GetCurrentLevel() < towerInfo.GetDTTurret().GetMaxLevelDT())
            {
                _upgradeMenuBasic.SetActive(true);
                _upgradeMenuSpe.SetActive(false);
            }
            else
            {
                _upgradeMenuSpe.SetActive(true);
                _upgradeMenuBasic.SetActive(false);
            }
        }
        else
        {
            _upgradeMenuSpe.SetActive(false);
            _upgradeMenuMain.SetActive(false);
            _upgradeMenuBasic.SetActive(false);
        }

    }

    public void StartUpgrading()
    {
        _towerInfo.UpgradingEvent();
    }


}
