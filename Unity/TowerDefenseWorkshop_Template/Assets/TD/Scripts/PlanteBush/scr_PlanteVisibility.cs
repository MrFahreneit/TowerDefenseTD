using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlanteVisibility : MonoBehaviour
{
    [SerializeField]
    private GameObject _planteUp = null;
    [SerializeField]
    private GameObject _planteDown = null;
    [SerializeField]
    private GameObject _planteRight = null;
    [SerializeField]
    private GameObject _planteLeft = null;

    public void SetFriend(GameObject _upFriend, GameObject _downFriend, GameObject _rightFriend, GameObject _leftFriend)
    {
        _planteUp = _upFriend;
        _planteDown = _downFriend;
        _planteRight = _rightFriend;
        _planteLeft = _leftFriend;
    }

    public void ShowVisibility()
    {
        if(_planteUp != null && _planteUp.GetComponent<scr_DebrisPlante>() == true)
        {
            _planteUp.GetComponent<scr_DebrisPlante>().ShowFriend();
        }

        if (_planteDown != null && _planteDown.GetComponent<scr_DebrisPlante>() == true)
        {
            _planteDown.GetComponent<scr_DebrisPlante>().ShowFriend();
        }

        if (_planteRight != null && _planteRight.GetComponent<scr_DebrisPlante>() == true)
        {
            _planteRight.GetComponent<scr_DebrisPlante>().ShowFriend();
        }

        if (_planteLeft != null && _planteLeft.GetComponent<scr_DebrisPlante>() == true)
        {
            _planteLeft.GetComponent<scr_DebrisPlante>().ShowFriend();
        }
    }
}
