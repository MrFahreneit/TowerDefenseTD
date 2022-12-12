using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_baseDamageable : MonoBehaviour
{

    private int _baseLife = 100;

    private int _currentBaseLife = 0;


    [SerializeField]
    private PathFollower _pathFollower = null;

    [SerializeField]
    private scr_baseLifeUI _baselifUI;



    private void Start()
    {
        _currentBaseLife = _baseLife;

    }

    public void DamageBase(int _damage)
    {
        _currentBaseLife = Mathf.Clamp((_currentBaseLife - _damage), 0, _baseLife);

        _baselifUI.OnBasedDamaged();

        if (_currentBaseLife <= 0)
        {
            //Le joueur est dead mec;
        }
    }

    public int GetBaseLife()
    {
        return _currentBaseLife;
    }



}
