using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_renduTower : MonoBehaviour
{
    //rendu tower 1
    [SerializeField]
    private GameObject _tower11;

    [SerializeField]
    private GameObject _tower12;

    [SerializeField]
    private GameObject _tower13;

    [SerializeField]
    private GameObject _tower101;

    [SerializeField]
    private GameObject _tower102;

    [SerializeField]
    private GameObject _tower103;

    //rendu tower 2
    [SerializeField]
    private GameObject _tower21;

    [SerializeField]
    private GameObject _tower22;

    [SerializeField]
    private GameObject _tower23;

    [SerializeField]
    private GameObject _tower201;

    [SerializeField]
    private GameObject _tower202;

    [SerializeField]
    private GameObject _tower203;

    //rendu tower 3
    [SerializeField]
    private GameObject _tower31;

    [SerializeField]
    private GameObject _tower32;

    [SerializeField]
    private GameObject _tower33;

    [SerializeField]
    private GameObject _tower301;

    [SerializeField]
    private GameObject _tower302;

    [SerializeField]
    private GameObject _tower303;



    public void RenduTower11()
    {
        _tower11.SetActive(true);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower12()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(true);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower13()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(true);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower101()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(true);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower102()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(true);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower103()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(true);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower21()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(true);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower22()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(true);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower23()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(true);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower201()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(true);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower202()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(true);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower203()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(true);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower31()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(true);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower32()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(true);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower33()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(true);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower301()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(true);
        _tower302.SetActive(false);
        _tower303.SetActive(false);
    }

    public void RenduTower302()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(true);
        _tower303.SetActive(false);
    }

    public void RenduTower303()
    {
        _tower11.SetActive(false);
        _tower12.SetActive(false);
        _tower13.SetActive(false);
        _tower101.SetActive(false);
        _tower102.SetActive(false);
        _tower103.SetActive(false);
        _tower21.SetActive(false);
        _tower22.SetActive(false);
        _tower23.SetActive(false);
        _tower201.SetActive(false);
        _tower202.SetActive(false);
        _tower203.SetActive(false);
        _tower31.SetActive(false);
        _tower32.SetActive(false);
        _tower33.SetActive(false);
        _tower301.SetActive(false);
        _tower302.SetActive(false);
        _tower303.SetActive(true);
    }
}
