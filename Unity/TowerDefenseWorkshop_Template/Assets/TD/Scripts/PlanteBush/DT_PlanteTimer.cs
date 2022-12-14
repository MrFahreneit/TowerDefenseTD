using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GameSup/DataBasePlantTime", fileName = "DataBasePlantTime")]
public class DT_PlanteTimer : ScriptableObject
{

    [SerializeField]
    private float _timeHatchA = 5f;
    [SerializeField]
    private float _timeHatchB = 5f;
    [SerializeField]
    private float _timeHatchC = 5f;

    public float GetHatchTime(int INDEX)
    {


        float currentHatch = 5f;

        if (INDEX == 1)
        {
            currentHatch = _timeHatchA;
        }
        if (INDEX == 2)
        {
            currentHatch = _timeHatchB;
        }
        if (INDEX == 3)
        {
            currentHatch = _timeHatchC;
        }

        return currentHatch;
    }
}
