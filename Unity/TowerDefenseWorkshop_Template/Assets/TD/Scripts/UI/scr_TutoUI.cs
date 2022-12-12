using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_TutoUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _tutoStep1;

    [SerializeField]
    private GameObject _tutoStep2;

    [SerializeField]
    private GameObject _tutoStep3;

    [SerializeField]
    private GameObject _tutoStep4;

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
            _tutoStep1.SetActive(false);
            _tutoStep2.SetActive(true);

        }

        if (_currentTutoStep == 2)
        {
            _tutoStep2.SetActive(false);
            _tutoStep3.SetActive(true);

        }

        if (_currentTutoStep == 3)
        {
            _tutoStep3.SetActive(false);
            _tutoStep4.SetActive(true);

        }

        if (_currentTutoStep == 4)
        {
            _tuto.SetActive(false);

        }

    }





}
