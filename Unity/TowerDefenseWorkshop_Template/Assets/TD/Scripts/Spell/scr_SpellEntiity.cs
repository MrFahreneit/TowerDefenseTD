using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SpellEntiity : MonoBehaviour
{
    [SerializeField]
    private bool isMeshVisible = false;

    [SerializeField]
    private GameObject _meshRenderer;

    [SerializeField]
    private scr_PlacingSpell placingSpellScript;
    void Update()
    {
        if(placingSpellScript.GetIsPlacingSpell() == true)
        {
            _meshRenderer.SetActive(true);
            gameObject.transform.position = placingSpellScript.GetPlacement();
        }
        else
        {

            _meshRenderer.SetActive(false);
        }
    }
}
