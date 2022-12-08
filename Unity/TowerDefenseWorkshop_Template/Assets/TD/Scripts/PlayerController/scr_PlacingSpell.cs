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

    private DT_SpellInfo _spellInfoDT = null;


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

        if (Input.GetMouseButtonDown(0) == true && isPlacingSpell == true)
        {
           var instance = Instantiate(_spellInfoDT.GetSpellPrefab(),_placement, Quaternion.identity);
           StopPlacingSpell();
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
    public void StartPlacing(DT_SpellInfo spellChoosed)
    {
        _spellInfoDT = spellChoosed;
        isPlacingSpell = true;
    }

}
