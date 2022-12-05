using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_UISpellThrowContainer : MonoBehaviour
{
    [SerializeField]
    private DT_SpellInfo dt_spellInfo;

    [SerializeField]
    private TextMeshProUGUI _spellName;

    private DT_SpellInfo GetDataTable()
    {
        return dt_spellInfo;
    }

    private void Start()
    {
        _spellName.text = dt_spellInfo.GetSpellName();
    }
}
