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
            LevelReferences.Instance.Manager_Economic.AddPlanteA(-1*(int)(_upgradeScript.GetDTTowerStats().GetPlantePrice().x));
            Instantiate(towerStats.GetSpe1DT(), TowerUpgraded.transform.position, TowerUpgraded.transform.rotation);
            Destroy(TowerUpgraded);
        }
        else if(Spe == 1)
        {
            LevelReferences.Instance.Manager_Economic.AddPlanteB(-1 * (int)(_upgradeScript.GetDTTowerStats().GetPlantePrice().y));
            Instantiate(towerStats.GetSpe2DT(), TowerUpgraded.transform.position, TowerUpgraded.transform.rotation);
            Destroy(TowerUpgraded);
        }
        else if(Spe == 2)
        {
            LevelReferences.Instance.Manager_Economic.AddPlanteC(-1 * (int)(_upgradeScript.GetDTTowerStats().GetPlantePrice().z));
            Instantiate(towerStats.GetSpe3DT(), TowerUpgraded.transform.position, TowerUpgraded.transform.rotation);
            Destroy(TowerUpgraded);
        }

        _canvaUpgrade.CloseTurretUpgradeMenu();
    }
}
