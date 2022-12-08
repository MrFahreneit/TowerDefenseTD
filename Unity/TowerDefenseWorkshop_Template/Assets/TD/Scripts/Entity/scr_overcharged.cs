using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_overcharged : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionOvercharged = null;

    [SerializeField]
    private GameObject _overchargedBlock = null;

    private bool _isOvercharged = false;

    private void OnDestroy()
    {
        if (LevelReferences.HasInstance == true)
        {

            if (_isOvercharged == true)
            {
                var instance = Instantiate(_explosionOvercharged, gameObject.transform.position, Quaternion.identity);
            }
        }


    }

    public void SetOvercharged()
    {
        _overchargedBlock.SetActive(true);
        _isOvercharged = true;
    }
}
