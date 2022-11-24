using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;
using UnityEngine.UI;
using TMPro;

//Dorian magno
//Modifie les texte de l'UI pour afficher les stats

public class scr_StatGetter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _goldText = null;
    [SerializeField]
    private TextMeshProUGUI _planteAText = null;
    [SerializeField]
    private TextMeshProUGUI _planteBText = null;
    [SerializeField]
    private TextMeshProUGUI _planteCText = null;

    public void UpdateStats(int gold, int planteA, int planteB, int planteC)
    {
        _goldText.text = "Gold :" + gold;
        _planteAText.text = "Plante A :" + planteA;
        _planteBText.text = "Plante B :" + planteB;
        _planteCText.text = "Plante C :" + planteC;
    }
}
