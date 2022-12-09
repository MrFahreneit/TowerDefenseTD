using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scr_DefeatUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _defeatScreen;

    public void IsDefeat()
    {

        _defeatScreen.SetActive(true);


    }
}
