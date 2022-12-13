using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlanteShowPrice : MonoBehaviour
{
    [SerializeField]
    private GameObject _plantePriceCanva;

    [SerializeField]
    private scr_DebrisPlante debrisScript;

    public void ShowPrice(bool show)
    {
        if(show == true && debrisScript.GetFriend() == true)
        {
            _plantePriceCanva.SetActive(true);
        }
        else
        {
            _plantePriceCanva.SetActive(false);
        }
    }
}
