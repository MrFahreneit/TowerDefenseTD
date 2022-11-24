using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

[SelectionBase]
public class scr_DebrisPlante : MonoBehaviour
{
    enum PlanteDebrisType { PlanteA, PlanteB, PlanteC };
    [SerializeField]
    private PlanteDebrisType _planteDebrisChoice;

    [SerializeField]
    private DT_PlantePrice dt_PlantePrice;

    private int _plantePrice = 0;

    private bool nextIsBought = false;

    [SerializeField]
    private Material _nextVisibleMat = null;
    [SerializeField]
    private GameObject _mesh = null;
    [SerializeField]
    private GameObject _planteBuy = null;

    [SerializeField]
    private scr_PlanteVisibility _planteVisibility = null;

    [SerializeField]
    private GameObject _MATERIALTONPERE = null;
    [SerializeField]
    private Material _plantAMat = null;
    [SerializeField]
    private Material _plantBMat = null;
    [SerializeField]
    private Material _plantCMat = null;


    // Start is called before the first frame update
    void Start()
    {

        if (dt_PlantePrice != null)
        {
            switch (_planteDebrisChoice)
            {
                case PlanteDebrisType.PlanteA:
                    _plantePrice = dt_PlantePrice.GetPricePlanteA();
                    break;
                case PlanteDebrisType.PlanteB:
                    _plantePrice = dt_PlantePrice.GetPricePlanteB();
                    break;
                case PlanteDebrisType.PlanteC:
                    _plantePrice = dt_PlantePrice.GetPricePlanteC();
                    break;
            }



        }

    }

    private void Update()
    {
        if(nextIsBought == true)
        {
            _nextVisibleMat = _mesh.GetComponent<MeshRenderer>().material;
        }
    }
    public int GetPrice()
    {
        return _plantePrice;
    }

    public bool GetFriend()
    {
        return nextIsBought;
    }

    public void Interact()
    {
        BuyPlante();
    }


    private void BuyPlante()
    {
        LevelReferences.Instance.Manager_Economic.AddGold(-1 * _plantePrice);
        _planteVisibility.ShowVisibility();
        var _instance = Instantiate(_planteBuy, gameObject.transform.position, Quaternion.identity);

        int plantType = 0;
        switch (_planteDebrisChoice)
        {
            case PlanteDebrisType.PlanteA:
                plantType = 0;
                break;
            case PlanteDebrisType.PlanteB:
                plantType = 1;
                break;
            case PlanteDebrisType.PlanteC:
                plantType = 2;
                break;
        }
        _instance.GetComponentInParent<scr_PlanteSpawner>().SetPlanteType(plantType);
        _instance.GetComponentInParent<scr_PlanteSpawner>().SetNewFriend(_planteVisibility);
        Destroy(gameObject);
    }

    public void ShowFriend()
    {
        nextIsBought = true;
        _mesh.GetComponent<MeshRenderer>().material = _nextVisibleMat;

        switch (_planteDebrisChoice)
        {

            case PlanteDebrisType.PlanteA:
                _MATERIALTONPERE.GetComponent<MeshRenderer>().material = _plantAMat;
                break;
            case PlanteDebrisType.PlanteB:
                _MATERIALTONPERE.GetComponent<MeshRenderer>().material = _plantBMat;
                break;
            case PlanteDebrisType.PlanteC:
                _MATERIALTONPERE.GetComponent<MeshRenderer>().material = _plantCMat;
                break;
        }
    }

}
