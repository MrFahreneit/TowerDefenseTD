using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GSGD1;

public class scr_UISpellCraft : MonoBehaviour
{
    [SerializeField]
    private DT_SpellInfo _dtSpellInfo;

    [SerializeField]
    private int SpellIndex = 1;

    [SerializeField]
    private TextMeshProUGUI _SpellName;

    private int priceA;
    private int priceB;
    private int priceC;

    [SerializeField]
    private TextMeshProUGUI _PriceAText;
    [SerializeField]
    private TextMeshProUGUI _PriceBText;
    [SerializeField]
    private TextMeshProUGUI _PriceCText;

    [SerializeField]
    private Button _CraftButton;

    private bool enoughtMoney = false;

    private void Start()
    {
        _SpellName.text = _dtSpellInfo.GetSpellName();
        Vector3 priceVector = LevelReferences.Instance.PlanteCraftEconomic.GetPrice(SpellIndex);

        priceA = (int)priceVector.x;
        priceB = (int)priceVector.y;
        priceC = (int)priceVector.z;

        _PriceAText.text = priceA.ToString();
        _PriceBText.text = priceB.ToString();
        _PriceCText.text = priceC.ToString();


    }

    private void Update()
    {
        int maxSpellCount = LevelReferences.Instance.PlanteCraftEconomic.GetMax(SpellIndex);
        int currentSpellCount = LevelReferences.Instance.PlanteCraftEconomic.GetCurrent(SpellIndex);

        Vector3 priceVector = LevelReferences.Instance.PlanteCraftEconomic.GetPrice(SpellIndex);

        priceA = (int)priceVector.x;
        priceB = (int)priceVector.y;
        priceC = (int)priceVector.z;
        Debug.Log(maxSpellCount +" +" + currentSpellCount);


        if (
            priceA <= LevelReferences.Instance.Manager_Economic.GetPlanteA() &&
            priceB <= LevelReferences.Instance.Manager_Economic.GetPlanteB() &&
            priceC <= LevelReferences.Instance.Manager_Economic.GetPlanteC()
           )
        {
            enoughtMoney = true;
        }
        else
        {
            enoughtMoney = false;
        }

        if (currentSpellCount < maxSpellCount && enoughtMoney == true)
        {
            _CraftButton.interactable = true;
        }
        else
        {
            _CraftButton.interactable = false;
        }


    }

    public void BuyPotion(int INDEX)
    {
        Vector3 priceVector = LevelReferences.Instance.PlanteCraftEconomic.GetPrice(SpellIndex);

        priceA = (int)priceVector.x;
        priceB = (int)priceVector.y;
        priceC = (int)priceVector.z;

        LevelReferences.Instance.Manager_Economic.AddPlanteA(priceA * (-1));
        LevelReferences.Instance.Manager_Economic.AddPlanteB(priceB * (-1));
        LevelReferences.Instance.Manager_Economic.AddPlanteC(priceC * (-1));

        LevelReferences.Instance.PlanteCraftEconomic.AddPotion(INDEX);
    }
}
