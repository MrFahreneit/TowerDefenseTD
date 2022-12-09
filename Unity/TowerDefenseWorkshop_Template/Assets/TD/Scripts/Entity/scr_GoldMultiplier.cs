using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_GoldMultiplier : MonoBehaviour
{

    private float _multiplierPercent = 1f;

    [SerializeField]
    private float _addMulti = 0.25f;

    [SerializeField]
    private MeshRenderer _goldActive = null;


    public void AddAMultiplier()
    {
        _multiplierPercent = _multiplierPercent + _addMulti;
        _goldActive.enabled = true;
    }

    public float GetMultiplier()
    {
        return _multiplierPercent;
    }

}
