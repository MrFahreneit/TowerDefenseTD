
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

[CreateAssetMenu(menuName = "GameSup/DataBaseTowerStat", fileName = "DataBaseTowerStat")]
public class DT_TowerStats : ScriptableObject
{
    [SerializeField]
    private string _turretName = "Name";

    private enum TypeEntity { Ground, Air, GroundAir };
    [SerializeField]
    private TypeEntity _entityType;

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
    private AProjectile _projectileSpawn = null;

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
    public float GetAttackSpeedDT()
    {
        return _attackSpeed;
    }
    public float GetrangeDT()
    {
        return _range;
    }
    public int GetbulletLaunchDT()
    {
        return _bulletLaunch;
    }
    public float GetSpreadDT()
    {
        return _spread;
    }

    public float GetRadiusDT()
    {
        return _range;
    }

    public string GetName()
    {
        return _turretName;
    }
    
    public int GetMaxLevelDT()
    {
        return _maxNiv;
    }
    public int GetTypeTurretDT()
    {

        int _EntityIndex = 0;
        switch (_entityType)
        {
            case TypeEntity.Ground:
                _EntityIndex = 0; ;
                break;
            case TypeEntity.Air:
                _EntityIndex = 1; ;
                break;
            case TypeEntity.GroundAir:
                _EntityIndex = 2; ;
                break;
        }
        return _EntityIndex;
    }

    public float GetUpgradeDamagePercentNiv()
    {
        return _damagePercentNiv;
    }
    public float GetUpgradeAttackSpeedPercentNiv()
    {
        return _attackSpeedPercentNiv;
    }
    public bool GetCanEvolve()
    {
        return _canEvolve;
    }

    public AProjectile GetProjectileDT()
    {
        return _projectileSpawn;
    }

}