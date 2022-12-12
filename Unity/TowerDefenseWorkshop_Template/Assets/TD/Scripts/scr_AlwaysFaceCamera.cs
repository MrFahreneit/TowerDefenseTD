using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AlwaysFaceCamera : MonoBehaviour
{
    Transform cam;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Update() // update works better than LateUpdate, but It should be done in LateUpdate...
    {
        transform.forward = cam.forward;
        //transform.rotation = Quaternion.LookRotation( transform.position - cam.position );
    }
}
