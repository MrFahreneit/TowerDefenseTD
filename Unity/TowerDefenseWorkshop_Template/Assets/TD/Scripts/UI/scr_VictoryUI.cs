using GSGD1;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class scr_VictoryUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _victoryScreen;

    [SerializeField]
    private scr_baseDamageable _baseManager;

    [SerializeField]
    private TextMeshProUGUI _txtbaseLife;

    private int _currentBaselife = 100;


    [SerializeField]
    private GameObject _star1;

    [SerializeField]
    private GameObject _star2;

    [SerializeField]
    private GameObject _star3;


    public void IsVictory()
    {

        _victoryScreen.SetActive(true);

        //on met a jour les le nombre d'enemy tuer et la vie restante de la base
        _currentBaselife = _baseManager.GetBaseLife();

        //On fait apparaitre la vie de la base 
        _txtbaseLife.text = "Base Life / " + _currentBaselife.ToString();


        // On set l'oppacité des étoile en fonction du nombre d'enemy dans la base
        if ( _currentBaselife <= 45)
        {
            _star1.SetActive(true);
        }

        if (_currentBaselife > 45 && _currentBaselife < 75)
        {
            _star1.SetActive(true);
            _star2.SetActive(true);

        }

        if (_currentBaselife > 75)
        {
            _star1.SetActive(true);
            _star2.SetActive(true);
            _star3.SetActive(true);

        }




    }




}
