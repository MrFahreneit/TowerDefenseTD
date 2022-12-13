using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class scr_BuildIconScript : MonoBehaviour
{
    [SerializeField]
    private GameObject hammerAnimation = null;

    public void ShowHammerAnim(bool show)
    {
        if(hammerAnimation != null)
        {
            if (show == true)
            {
                hammerAnimation.SetActive(true);
            }
            else
            {
                hammerAnimation.SetActive(false);
            }
        }
    }
}
