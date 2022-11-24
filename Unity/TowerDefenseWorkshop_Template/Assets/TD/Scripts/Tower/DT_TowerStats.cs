
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

[CreateAssetMenu(menuName = "GameSup/DataBaseTowerStat", fileName = "DataBaseTowerStat")]
public class DT_TowerStats : ScriptableObject
{
    [SerializeField]
    private string _turretName = "Name";
    [SerializeField]
    private int TypeIndex = 0;
    [SerializeField]
    private int _niv = 1;
    [SerializeField]
    private float _damage = 1f;
    [SerializeField]
    private float _attackSpeed = 1f;
    [SerializeField]
    private float _range = 5f;
    [SerializeField]
    private int _bulletLaunch = 1;
    [SerializeField]
    private float _spread = 0f;

    [SerializeField]
    private int _maxNiv = 3;
    [SerializeField]
    private bool _canEvolve = true;
    [SerializeField]
    private float _damagePercentNiv = 0.5f;
    [SerializeField]
    private float _attackSpeedPercentNiv = 0.2f;

    [SerializeField]
    private GameObject _Spe1Pefab = null;
    [SerializeField]
    private GameObject _Spel2Pefab = null;
    [SerializeField]
    private GameObject _Spe3Pefab = null;

    public float GetDamageDT()
    {
        return _damage;
    }
}
