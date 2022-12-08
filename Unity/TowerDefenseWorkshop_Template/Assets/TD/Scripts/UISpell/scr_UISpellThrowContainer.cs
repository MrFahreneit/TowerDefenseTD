using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GSGD1;

public class scr_UISpellThrowContainer : MonoBehaviour
{
    [SerializeField]
    private DT_SpellInfo dt_spellInfo;

    [SerializeField]
    private int Index = 1;

    [SerializeField]
    private TextMeshProUGUI _spellName;

    [SerializeField]
    private Button _usePotion;
    [SerializeField]
    private TextMeshProUGUI _spellCurrentText;
    [SerializeField]
    private TextMeshProUGUI _spellMaxText;

    private DT_SpellInfo GetDataTable()
    {
        return dt_spellInfo;
    }

    private void Start()
    {
        _spellName.text = dt_spellInfo.GetSpellName();
    }

    private void Update()
    {
        _spellCurrentText.text = LevelReferences.Instance.PlanteCraftEconomic.GetCurrent(Index).ToString();
        _spellMaxText.text = LevelReferences.Instance.PlanteCraftEconomic.GetMax(Index).ToString();

        if(LevelReferences.Instance.PlanteCraftEconomic.GetCurrent(Index) > 0)
        {
            _usePotion.interactable = true;
        }
        else
        {
            _usePotion.interactable = false;
        }
    }
}
