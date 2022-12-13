using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GSGD1;

public class scr_PriceUIPlante : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _priceText;

    [SerializeField]
    private scr_DebrisPlante debrisScript;

    // Update is called once per frame
    void Update()
    {
        _priceText.text = debrisScript.GetPrice().ToString();
        if(LevelReferences.Instance.Manager_Economic.GetGold() >= debrisScript.GetPrice())
        {
            _priceText.color = Color.white;
        }
        else
        {
            _priceText.color = Color.red;
        }
    }
}
