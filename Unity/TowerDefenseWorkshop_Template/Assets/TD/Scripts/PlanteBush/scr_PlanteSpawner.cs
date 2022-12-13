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
    private GameObject _plantAMesh = null;
    [SerializeField]
    private GameObject _plantBMesh = null;
    [SerializeField]
    private GameObject _plantCMesh = null;
    [SerializeField]
    private GameObject _plantANoPlantMesh = null;
    [SerializeField]
    private GameObject _plantBNoPlantMesh = null;
    [SerializeField]
    private GameObject _plantCNoPlantMesh = null;


    [SerializeField]
    private scr_PlanteVisibility _planteVisibility = null;

    [SerializeField]
    protected scr_SpellForwardReceiver _spellSpeed = null;

    [SerializeField]
    private scr_AnimationPlayer animStart;
    [SerializeField]
    private scr_AnimationPlayer animHarvest;
    [SerializeField]
    private scr_AnimationPlayer plantspawned;

    private void OnEnable()
    {
        animStart.PlayAnim();
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

        if(_HarvestSound != null)
        {
            _HarvestSound.SpawnSound(true);
        }

        animHarvest.PlayAnim();
        isSpawned = false;
        _timer.Start();
    }

    private void Update()
    {
        if(isSpawned == true)
        {
            _plantANoPlantMesh.SetActive(false);
            _plantBNoPlantMesh.SetActive(false);
            _plantCNoPlantMesh.SetActive(false);
            _planteVisibility.ShowVisibility();
            switch (_planteChoice)
            {
                case PlanteType.PlanteA:
                    _plantAMesh.SetActive(true);
                    _plantBMesh.SetActive(false);
                    _plantCMesh.SetActive(false);
                    break;
                case PlanteType.PlanteB:
                    _plantAMesh.SetActive(false);
                    _plantBMesh.SetActive(true);
                    _plantCMesh.SetActive(false);
                    break;
                case PlanteType.PlanteC:
                    _plantAMesh.SetActive(false);
                    _plantBMesh.SetActive(false);
                    _plantCMesh.SetActive(true);
                    break;
            }
        }
        else
        {
            _plantAMesh.SetActive(false);
            _plantBMesh.SetActive(false);
            _plantCMesh.SetActive(false);
            _planteVisibility.ShowVisibility();
            switch (_planteChoice)
            {
                case PlanteType.PlanteA:
                    _plantANoPlantMesh.SetActive(true);
                    _plantBNoPlantMesh.SetActive(false);
                    _plantCNoPlantMesh.SetActive(false);
                    break;
                case PlanteType.PlanteB:
                    _plantANoPlantMesh.SetActive(false);
                    _plantBNoPlantMesh.SetActive(true);
                    _plantCNoPlantMesh.SetActive(false);
                    break;
                case PlanteType.PlanteC:
                    _plantANoPlantMesh.SetActive(false);
                    _plantBNoPlantMesh.SetActive(false);
                    _plantCNoPlantMesh.SetActive(true);
                    break;
            }
        }
        _timer.Update();

        if (_timer.IsRunning == false && isSpawned == false)
        {
            isSpawned = true;
            _timer.Stop();
            plantspawned.PlayAnim();
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
                _plantAMesh.SetActive(true);
                break;
            case PlanteType.PlanteB:
                _plantBMesh.SetActive(true);
                break;
            case PlanteType.PlanteC:
                _plantCMesh.SetActive(true);
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
