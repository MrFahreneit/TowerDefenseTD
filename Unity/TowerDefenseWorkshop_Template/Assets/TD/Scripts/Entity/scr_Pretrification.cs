using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_Pretrification : MonoBehaviour
{
    [SerializeField]
    private PathFollower _pathFollower = null;

    [SerializeField]
    private Timer _timerStun = null;

    [SerializeField]
    private MeshRenderer _stunBlock = null;

    private bool isStun = false;


    public bool GetStunStatus()
    {
        return isStun;
    }



    public void SetStun()
    {
        isStun = true;
        _stunBlock.enabled = true;
        _pathFollower.SetCanMove(false);
        _timerStun.Start();
    }

    private void Update()
    {
        if(isStun == true)
        {
            _timerStun.Update();

            if(_timerStun.IsRunning == false)
            {
                _timerStun.Stop();
                isStun = false;
                _stunBlock.enabled = false;
                _pathFollower.SetCanMove(true);
            }
        }

    }

}
