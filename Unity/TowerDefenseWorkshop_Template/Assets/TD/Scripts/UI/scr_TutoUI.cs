using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_TutoUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _tutoStep;

    [SerializeField]
    private GameObject _tuto;

    public int _currentTutoStep = 0;


    public void IsTuto()
    {
        _tuto.SetActive(true);
    }



    public void NextTutoStep()
    {
        _currentTutoStep = _currentTutoStep + 1;

        if (_currentTutoStep == 1)
        {
            _tuto.SetActive(true);

        }

    }





}
