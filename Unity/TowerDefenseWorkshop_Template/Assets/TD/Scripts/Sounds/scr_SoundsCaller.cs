using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SoundsCaller : MonoBehaviour
{
    [SerializeField]
    private AudioSource _Sound = null;
   
    public void SpawnSound(bool randomPitch)
    {
        if (_Sound != null)
        {
            if (randomPitch)
            {
                _Sound.pitch = Random.Range(0.75f, 1.2f);
            }

            _Sound.Play();

        }

    }
}
