using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_KillerTimer : MonoBehaviour
{
    [SerializeField]
    private float _timeAlive = 5f;

    private void Start()
    {
        Invoke("Kill", _timeAlive);
    }

    private void Kill()
    {
        Destroy(gameObject);
    }


}
