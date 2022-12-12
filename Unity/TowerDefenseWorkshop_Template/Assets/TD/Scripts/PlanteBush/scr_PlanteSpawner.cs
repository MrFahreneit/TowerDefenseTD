using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;
using TMPro;

[SelectionBase]
public class scr_PlanteSpawner : MonoBehaviour
{
    [SerializeField]
    private scr_SoundsCaller _HarvestSound = null;


    enum PlanteType { PlanteA, PlanteB, PlanteC};
    [SerializeField]
    private PlanteType _planteChoice;

    [SerializeField]
    private Timer _timer = null;

    [SerializeField]
    private DT_PlanteTimer _dtTimer;

    [SerializeField]
    private bool isSpawned = true;

    [SerializeField]
    private GameObject _bushMesh = null;
    [SerializeField]
    private Material _noPlantMat = null;
    [SerializeField]
    private Material _plantMat = null;

    [SerializeField]
    private GameObject _MATERIALTONPERE = null;
    [SerializeField]
    private Material _plantAMat = null;
    [SerializeField]
    private Material _plantBMat = null;
    [SerializeField]
    private Material _plantCMat = null;


    [SerializeField]
    private scr_PlanteVisibility _planteVisibility = null;

    [SerializeField]
    protected scr_SpellForwardReceiver _spellSpeed = null;

    private void OnEnable()
    {
        _spellSpeed.TimerScaleHasChanged.RemoveListener(ChangeTime);
        _spellSpeed.TimerScaleHasChanged.AddListener(ChangeTime);
    }

    private void OnDisable()
    {
        _spellSpeed.TimerScaleHasChanged.RemoveListener(ChangeTime);
    }

    private void ChangeTime(float newTimer)
    {
        _timer.NewTimeScale(newTimer);

    }

    public void Interacte()
    {
        if (isSpawned == true)
        {
            switch (_planteChoice)
            {
                case PlanteType.PlanteA:
                    LevelReferences.Instance.Manager_Economic.AddPlanteA(1);
                    PlanteIsCollected();
                    break;
                case PlanteType.PlanteB:
                    LevelReferences.Instance.Manager_Economic.AddPlanteB(1);
                    PlanteIsCollected();
                    break;
                case PlanteType.PlanteC:
                    LevelReferences.Instance.Manager_Economic.AddPlanteC(1);
                    PlanteIsCollected();
                    break;
            }
        }

    }

    public bool GetPlantSpawned()
    {
        return isSpawned;
    }

    private void PlanteIsCollected()
    {
        //_HarvestSound.SpawnSound();

        isSpawned = false;
        _timer.Start();
    }

    private void Update()
    {
        if(isSpawned == true)
        {
           _bushMesh.GetComponent<MeshRenderer>().material = _plantMat;
        }
        else
        {
            _bushMesh.GetComponent<MeshRenderer>().material = _noPlantMat;
        }
        _timer.Update();

        if (_timer.IsRunning == false && isSpawned == false)
        {
            isSpawned = true;
            _timer.Stop();
        }

    }

    public void SetPlanteType(int newPlant)
    {
        if(newPlant == 0)
        {
            _planteChoice = PlanteType.PlanteA;
        }
        if (newPlant == 1)
        {
            _planteChoice = PlanteType.PlanteB;
        }
        if (newPlant == 2)
        {
            _planteChoice = PlanteType.PlanteC;
        }

        UpdateMaterialAndFriends();

    }

    private void Start()
    {
        UpdateMaterialAndFriends();
    }

    private void UpdateMaterialAndFriends()
    {
        _planteVisibility.ShowVisibility();
        switch (_planteChoice)
        {
            case PlanteType.PlanteA:
                _MATERIALTONPERE.GetComponent<MeshRenderer>().material = _plantAMat;
                break;
            case PlanteType.PlanteB:
                _MATERIALTONPERE.GetComponent<MeshRenderer>().material = _plantBMat;
                break;
            case PlanteType.PlanteC:
                _MATERIALTONPERE.GetComponent<MeshRenderer>().material = _plantCMat;
                break;
        }

        switch (_planteChoice)
        {
            case PlanteType.PlanteA:
                _timer.Set(_dtTimer.GetHatchTime(1),true);
                PlanteIsCollected();
                break;
            case PlanteType.PlanteB:
                _timer.Set(_dtTimer.GetHatchTime(2), true);
                PlanteIsCollected();
                break;
            case PlanteType.PlanteC:
                _timer.Set(_dtTimer.GetHatchTime(3), true);
                PlanteIsCollected();
                break;
        }
    }

    public void SetNewFriend(scr_PlanteVisibility newFriend)
    {
        _planteVisibility = newFriend;
    }




}
