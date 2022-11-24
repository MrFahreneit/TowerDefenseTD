using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_Manager_Economic : MonoBehaviour
{

    //Dorian Magno
    //Script pour gerer l'économie
    //Permet de set et get les différentes money
    //Update le statGetter pour lui transmettre les infos visuels

    [SerializeField]
    private scr_StatGetter _statGetter = null;

    [SerializeField]
    private int _gold = 0;

    [SerializeField]
    private int _planteA = 0;
    [SerializeField]
    private int _planteB = 0;
    [SerializeField]
    private int _planteC = 0;

    public int GetGold()
    {
        return _gold;
    }
    public int GetPlanteA()
    {
        return _planteA;
    }
    public int GetPlanteB()
    {
        return _planteB;
    }
    public int GetPlanteC()
    {
        return _planteC;
    }

    public void AddGold(int _addGold)
    {
        _gold += _addGold;
        StatsUpdated();
    }
    public void AddPlanteA(int _addPlanteA)
    {
        _planteA += _addPlanteA;
        StatsUpdated();
    }
    public void AddPlanteB(int _addPlanteB)
    {
        _planteB += _addPlanteB;
        StatsUpdated();
    }
    public void AddPlanteC(int _addPlanteC)
    {
        _planteC += _addPlanteC;
        StatsUpdated();
    }

    private void StatsUpdated()
    {
        _statGetter.UpdateStats(_gold, _planteA, _planteB, _planteC);
    }

    private void Start()
    {
        StatsUpdated();
    }
}
