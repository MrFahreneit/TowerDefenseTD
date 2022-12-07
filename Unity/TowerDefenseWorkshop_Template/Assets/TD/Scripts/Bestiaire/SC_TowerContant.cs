using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GSGD1;

public class SC_TowerContant : MonoBehaviour
{

    [SerializeField]
    private Mesh _towerMesh;

    [SerializeField]
    private DT_TowerStats _towerDescription;

    [SerializeField]
    private TextMeshProUGUI _prixText;

    [SerializeField]
    private TextMeshProUGUI _damageText;

    [SerializeField]
    private TextMeshProUGUI _rangeText;

    [SerializeField]
    private TextMeshProUGUI _towerNameText;

    [SerializeField]
    private TextMeshProUGUI _towerDescriptionText;


    public void UpdateInfo()
    {
        _damageText.text = _towerDescription.GetDamageDT().ToString();

        //_prixText.text = _towerDescription.GetDamageDT().ToString();

        _rangeText.text = _towerDescription.GetrangeDT().ToString();

        _towerNameText.text = _towerDescription.GetName().ToString();

        //_towerDescriptionText.text = _towerDescription.GetName().ToString();
    }

}
