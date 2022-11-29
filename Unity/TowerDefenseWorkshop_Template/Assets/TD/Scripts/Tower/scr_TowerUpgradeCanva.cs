using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_TowerUpgradeCanva : MonoBehaviour
{

    private GameObject _instagator = null;

    [SerializeField]
    private GameObject _UITurretUpgrade = null;

    public void OpenTurretUpgradeMenu(GameObject instigator)
    {
        if (instigator != null)
        {
            _instagator = instigator;
        }
        else
        {
            _instagator = null;
        }

        _UITurretUpgrade.SetActive(true);
        _UITurretUpgrade.GetComponent<scr_UITowerUpgradeMenu>().SetInfoUpgrade(
            instigator,
            instigator.GetComponentInParent<Tower>());
        //_TurretMenuCreateOpen = true;
        UIManager.Instance.SetMenuOpen(true);
    }

    public void CloseTurretUpgradeMenu()
    {
        _UITurretUpgrade.SetActive(false);
        //_TurretMenuCreateOpen = false;
        UIManager.Instance.SetMenuOpen(false);
    }
}
