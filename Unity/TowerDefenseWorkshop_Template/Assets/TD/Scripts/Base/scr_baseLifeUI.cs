using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_baseLifeUI : MonoBehaviour
{
    private const float max_health = 100f;

    [SerializeField]
    private float health = max_health;




    [SerializeField]
    private scr_baseDamageable _baseHealth;

    [SerializeField]
    private Image _HealthBar;

    [SerializeField]
    private TextMeshProUGUI _lifeTxt;

    private int _currentbaselife = 100;



    private void Start()
    {
        _HealthBar = GetComponent<Image>();
    }

    public void OnBasedDamaged()
    {
        _HealthBar.fillAmount -= 1.0f;

        _currentbaselife = _currentbaselife - 1;

        _lifeTxt.text = _currentbaselife + "/ 100";

    }


}
