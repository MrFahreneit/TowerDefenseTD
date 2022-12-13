using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PurifiedScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0,Random.Range(0,360),0);

        Invoke("DiseapearPurified", 1.63f);
    }


    private void DiseapearPurified()
    {
        Destroy(gameObject);
    }
    
}
