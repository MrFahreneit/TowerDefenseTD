using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GSGD1;
using TMPro;

public class scr_UITurretMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _UITurretCreate = null;

    [SerializeField]
    private DT_GoldTurret _dt_GoldTurret = null;

    //private bool _TurretMenuCreateOpen = false;

    private GameObject _instagator = null;
    


    [SerializeField]
    private TextMeshProUGUI _priceText1 = null;
    [SerializeField]
    private TextMeshProUGUI _priceText2 = null;
    [SerializeField]
    private TextMeshProUGUI _priceText3 = null;


    private void Start()
    {
        _priceText1.text = _dt_GoldTurret.GetPriceTurret1().ToString();
        _priceText2.text = _dt_GoldTurret.GetPriceTurret2().ToString();
        _priceText3.text = _dt_GoldTurret.GetPriceTurret3().ToString();
    }

    public void OpenTurretMenu(GameObject instigator)
    {
        if(instigator != null)
        {
            _instagator = instigator;
        }
        else
        {
            _instagator = null;
        }

        _UITurretCreate.SetActive(true);
        //_TurretMenuCreateOpen = true;
        UIManager.Instance.SetMenuOpen(true);
    }

    public void chooseTurret(int turretINDEX)
    {
        int _currentPrice = 0;

       if(turretINDEX == 0)
       {
            _currentPrice = _dt_GoldTurret.GetPriceTurret1();
       }
       if (turretINDEX == 1)
       {
            _currentPrice = _dt_GoldTurret.GetPriceTurret2();
        }
       if (turretINDEX == 2)
       {
            _currentPrice = _dt_GoldTurret.GetPriceTurret3();
       }

       if(_currentPrice <= LevelReferences.Instance.Manager_Economic.GetGold())
        {
            LevelReferences.Instance.Manager_Economic.AddGold(-1 * _currentPrice);

            

            CloseTurretMenu();



            if (_instagator != null)
            {
                if (_instagator.GetComponentInParent<scr_SelectingActor>() == true)
                {
                    _instagator.GetComponentInParent<scr_SelectingActor>().CreateTurret(turretINDEX);
                }
            }

        }
    }


    public void CloseTurretMenu()
    {
        _UITurretCreate.SetActive(false);
        //_TurretMenuCreateOpen = false;
        UIManager.Instance.SetMenuOpen(false);
    }

}
