using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_UISpecialize : MonoBehaviour
{
    [SerializeField]
    private scr_UITowerUpgradeMenu _upgradeScript = null;
    [SerializeField]
    private scr_TowerUpgradeCanva _canvaUpgrade = null;

    public void UpgradeSpecializeTurret(int Spe)
    {
        DT_TowerStats towerStats = _upgradeScript.GetDTTowerStats();
        GameObject TowerUpgraded = _upgradeScript.GetTowerPrefab();
        if(Spe == 0)
        {

            Instantiate(towerStats.GetSpe1DT(), TowerUpgraded.transform.position, TowerUpgraded.transform.rotation);
            Destroy(TowerUpgraded);
        }
        else if(Spe == 1)
        {
            Instantiate(towerStats.GetSpe2DT(), TowerUpgraded.transform.position, TowerUpgraded.transform.rotation);
            Destroy(TowerUpgraded);
        }
        else if(Spe == 2)
        {
            Instantiate(towerStats.GetSpe3DT(), TowerUpgraded.transform.position, TowerUpgraded.transform.rotation);
            Destroy(TowerUpgraded);
        }

        _canvaUpgrade.CloseTurretUpgradeMenu();
    }
}
