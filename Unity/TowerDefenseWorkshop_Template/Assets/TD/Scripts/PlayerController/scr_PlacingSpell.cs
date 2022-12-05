using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlacingSpell : MonoBehaviour
{
    private bool isPlacingSpell = false;

    [SerializeField]
    private Camera _playerCamera;

    [SerializeField]
    private LayerMask _layerMask;

    private Vector3 _placement;


    public bool GetIsPlacingSpell()
    {
        return isPlacingSpell;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) == true && isPlacingSpell == true)
        {
            StopPlacingSpell();
        }
        if (isPlacingSpell == true)
        {
            Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo, _layerMask);
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, _layerMask))
            {
                _placement = hitInfo.point;
            }
        }
    }

    private void StopPlacingSpell()
    {
        isPlacingSpell = false;
    }
    
    public Vector3 GetPlacement()
    {
        return _placement;
    }
    public void StartPlacing()
    {
        Debug.Log("oui");
        isPlacingSpell = true;
    }

}
