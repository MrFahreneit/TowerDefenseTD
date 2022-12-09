using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_NewEnemyUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _UiNewEnemies = null;




    private void IsNewEnemy()
    {
        _UiNewEnemies.SetActive(true);
    }





}
