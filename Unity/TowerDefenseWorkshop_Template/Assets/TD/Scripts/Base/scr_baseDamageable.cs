using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_baseDamageable : MonoBehaviour
{

    private int _baseLife = 100;

    private int _currentBaseLife = 0;

    private int _damageTaken = 1;

    [SerializeField]
    private PathFollower _pathFollower = null;



    private void Start()
    {
        _currentBaseLife = _baseLife;

    }

    private void Update()
    {

        if (_pathFollower.EnemyInBase() == true)
        {
            Debug.Log("test");

            _currentBaseLife = _currentBaseLife - _damageTaken;
        }
    }





}
