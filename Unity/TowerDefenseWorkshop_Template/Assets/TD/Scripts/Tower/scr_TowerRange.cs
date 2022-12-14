using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_TowerRange : MonoBehaviour
{
    [SerializeField]
    private Tower towerScript = null;

    [SerializeField]
    private GameObject _rangeObject = null;


    public void ShowRangeAnim(bool show)
    {
        
        if (_rangeObject != null)
        {
            if (show == true)
            {
                _rangeObject.SetActive(true);
            }
            else
            {
                _rangeObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        _rangeObject.transform.localScale = new Vector3(1,1,1) * towerScript.GetDTTurret().GetRadiusDT();
    }


}
