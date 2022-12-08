using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

[CreateAssetMenu(menuName = "GameSup/SpellDescription", fileName = "SpellDescription")]

public class DT_SpellInfo : ScriptableObject
{
    [SerializeField]
    private string _name = "Feur";
    [SerializeField]
    private GameObject _spellPrefab;

    [SerializeField]
    private int IndexSpell = 1;

    public string GetSpellName()
    {
        return _name;
    }
    public GameObject GetSpellPrefab()
    {
        return _spellPrefab;
    }

    public int GetIndexSpell()
    {
        return IndexSpell;
    }
}
