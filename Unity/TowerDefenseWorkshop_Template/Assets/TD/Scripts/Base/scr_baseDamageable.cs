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

    [SerializeField]
    private GameObject _Defeat;



    private void Start()
    {
        _currentBaseLife = _baseLife;

    }

    public void DamageBase(int _damage)
    {
        _currentBaseLife = Mathf.Clamp((_currentBaseLife - _damage), 0, 100);
        Debug.Log("DamagedDeal" + _damage);

        _baselifUI.OnBasedDamaged();

        if (_currentBaseLife <= 0)
        {
            _Defeat.SetActive(true);
        }
    }

    public int GetBaseLife()
    {
        return _currentBaseLife;
    }



}
