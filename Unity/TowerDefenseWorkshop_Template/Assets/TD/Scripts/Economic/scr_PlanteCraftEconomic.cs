using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlanteCraftEconomic : MonoBehaviour
{
    #region variabledesoufrancetuermoi

    [Header("Price")]
    [SerializeField]
    private Vector3 _SpellPrice1;
    [SerializeField]
    private Vector3 _SpellPrice2;
    [SerializeField]
    private Vector3 _SpellPrice3;
    [SerializeField]
    private Vector3 _SpellPrice4;
    [SerializeField]
    private Vector3 _SpellPrice5;
    [SerializeField]
    private Vector3 _SpellPrice6;

    [Header("Max")]
    [SerializeField]
    private int _SpellMax1;
    [SerializeField]
    private int _SpellMax2;
    [SerializeField]
    private int _SpellMax3;
    [SerializeField]
    private int _SpellMax4;
    [SerializeField]
    private int _SpellMax5;
    [SerializeField]
    private int _SpellMax6;

    [Header("Current")]
    private int _SpellCurrent1;
    private int _SpellCurrent2;
    private int _SpellCurrent3;
    private int _SpellCurrent4;
    private int _SpellCurrent5;
    private int _SpellCurrent6;



    #endregion

    public Vector3 GetPrice(int INDEX)
    {
        Vector3 PriceChoosed = new Vector3(0, 0, 0);

        if(INDEX == 1)
        {
            PriceChoosed = _SpellPrice1;
        }
        if (INDEX == 2)
        {
            PriceChoosed = _SpellPrice2;
        }
        if (INDEX == 3)
        {
            PriceChoosed = _SpellPrice3;
        }
        if (INDEX == 4)
        {
            PriceChoosed = _SpellPrice4;
        }
        if (INDEX == 5)
        {
            PriceChoosed = _SpellPrice5;
        }
        if (INDEX == 6)
        {
            PriceChoosed = _SpellPrice6;
        }

        return PriceChoosed;

    }

    public int GetMax(int INDEX)
    {
        int maxChoosed = 1;

        if (INDEX == 1)
        {
            maxChoosed = _SpellMax1;
        }
        if (INDEX == 2)
        {
            maxChoosed = _SpellMax2;
        }
        if (INDEX == 3)
        {
            maxChoosed = _SpellMax3;
        }
        if (INDEX == 4)
        {
            maxChoosed = _SpellMax4;
        }
        if (INDEX == 5)
        {
            maxChoosed = _SpellMax5;
        }
        if (INDEX == 6)
        {
            maxChoosed = _SpellMax6;
        }

        return maxChoosed;
    }

    public void AddPotion(int INDEX)
    {
        if (INDEX == 1)
        {
            _SpellCurrent1++;
        }
        if (INDEX == 2)
        {
            _SpellCurrent2++;
        }
        if (INDEX == 3)
        {
            _SpellCurrent3++;
        }
        if (INDEX == 4)
        {
            _SpellCurrent4++;
        }
        if (INDEX == 5)
        {
            _SpellCurrent5++;
        }
        if (INDEX == 6)
        {
           _SpellCurrent6++;
        }
    }
}
