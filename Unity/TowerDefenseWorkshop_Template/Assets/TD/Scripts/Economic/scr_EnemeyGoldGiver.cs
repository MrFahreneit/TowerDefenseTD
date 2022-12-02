using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

//D.Magno
//Donne des golds dans un ennemi meurt

public class scr_EnemeyGoldGiver : MonoBehaviour
{
    [SerializeField]
    private int _goldDeath = 5;

    [SerializeField]
    private scr_GoldMultiplier _goldMultiSript = null;

    private void OnDestroy()
    {
        if(LevelReferences.HasInstance == true)
        {
            LevelReferences.Instance.Manager_Economic.AddGold(
                (Mathf.RoundToInt(_goldDeath * _goldMultiSript.GetMultiplier()))
                );
        }
    }
}
