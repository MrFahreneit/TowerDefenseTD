using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;


public class scr_CellInt : MonoBehaviour
{
    [SerializeField]
    private GameObject _instance = null;

    public void Interact()
    {
        Instantiate(_instance, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
