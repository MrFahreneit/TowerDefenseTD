using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MoveThing : MonoBehaviour
{
    [SerializeField]
    private GameObject _button;

    public void ActiveMoveButton()
    {
        _button.transform.localScale = new Vector3(0, 0, 0);
        _button.transform.position = new Vector3(1000,1000,1000);
    }
}
