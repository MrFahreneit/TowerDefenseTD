using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyBestiaireManager : MonoBehaviour
{



    [SerializeField]
    private GameObject _enemy1;

    [SerializeField]
    private GameObject _enemy2;

    [SerializeField]
    private GameObject _enemy3;

    [SerializeField]
    private GameObject _enemy4;

    [SerializeField]
    private GameObject _enemy5;

    [SerializeField]
    private GameObject _enemy6;

    [SerializeField]
    private GameObject _enemy7;

    [SerializeField]
    private GameObject _enemy8;

    [SerializeField]
    private GameObject _enemy9;

    [SerializeField]
    private GameObject _enemy10;




    public void Enemy1()
    {
        _enemy1.SetActive(true);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy2()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(true);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy3()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(true);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy4()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(true);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy5()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(true);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy6()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(true);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy7()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(true);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy8()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(true);
        _enemy9.SetActive(false);
        _enemy10.SetActive(false);
    }

    public void Enemy9()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(true);
        _enemy10.SetActive(false);
    }

    public void Enemy10()
    {
        _enemy1.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        _enemy4.SetActive(false);
        _enemy5.SetActive(false);
        _enemy6.SetActive(false);
        _enemy7.SetActive(false);
        _enemy8.SetActive(false);
        _enemy9.SetActive(false);
        _enemy10.SetActive(true);
    }


}
