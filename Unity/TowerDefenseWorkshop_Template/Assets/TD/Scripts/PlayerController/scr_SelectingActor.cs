using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;


//Magno Dorian
//Aled

public class scr_SelectingActor : MonoBehaviour
{
    private scr_PlanteSpawner _hitPlante = null;
    private scr_CellInt _hitCell = null;
    private scr_DebrisPlante _hitDebris = null;
    private Tower _hitTower = null;

    [SerializeField]
    private Camera _playerCamera = null;
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private GameObject _witchActor = null;

    [SerializeField]
    private bool _AMenuIsOpen = false;

    [SerializeField]
    private GameObject turret1 = null;
    [SerializeField]
    private GameObject turret2 = null;
    [SerializeField]
    private GameObject turret3 = null;



    public void CreateTurret(int _TurretINDEX)
    {
        if(_TurretINDEX == 0)
        {
            Instantiate(turret1, _hitCell.transform.position, Quaternion.identity);
        }
        if (_TurretINDEX == 1)
        {
            Instantiate(turret2, _hitCell.transform.position, Quaternion.identity);
        }
        if (_TurretINDEX == 2)
        {
            Instantiate(turret3, _hitCell.transform.position, Quaternion.identity);
        }
        Destroy(_hitCell);
        _hitCell = null;

    }


    void Update()
    {


        if (Input.GetMouseButtonDown(0) && _AMenuIsOpen == false)
        {
            {
                Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                Physics.Raycast(ray, out hitInfo, _layerMask);
                if (Physics.Raycast(ray, out hitInfo, float.MaxValue, _layerMask))
                {


                    //Hit une plante pour la récolter
                    if (hitInfo.collider.GetComponentInParent<scr_PlanteSpawner>() == true)
                    {
                        _hitPlante = hitInfo.collider.GetComponentInParent<scr_PlanteSpawner>();

                        if(_hitPlante.GetPlantSpawned() == true)
                        {

                            _witchActor.GetComponentInParent<scr_WitchMovement>().SetNewTarget(_hitPlante.gameObject);
                            _hitPlante.Interacte();
                        }

                    }


                    //Upgrade HIT
                    if (hitInfo.collider.GetComponentInParent<Tower>() == true)
                    {
                        UIManager.Instance.GetUITowerUpgrade().OpenTurretUpgradeMenu(hitInfo.transform.gameObject);

                        _hitTower = hitInfo.collider.GetComponentInParent<Tower>();
                        _witchActor.GetComponentInParent<scr_WitchMovement>().SetNewTarget(_hitTower.gameObject);
                    }


                    //HIT Cell pour poser une tourelle
                    if (hitInfo.collider.GetComponentInParent<scr_CellInt>() == true)
                    {
                        UIManager.Instance.GetUITurretMenu().OpenTurretMenu(gameObject);

                        _hitCell = hitInfo.collider.GetComponentInParent<scr_CellInt>();
                        _witchActor.GetComponentInParent<scr_WitchMovement>().SetNewTarget(_hitCell.gameObject);
                    }



                    //HIT DEBRIS PLANT POUR LES ACHETER
                    if (hitInfo.collider.GetComponentInParent<scr_DebrisPlante>() == true &&
                        hitInfo.collider.GetComponentInParent<scr_DebrisPlante>().GetPrice() <= LevelReferences.Instance.Manager_Economic.GetGold() &&
                        hitInfo.collider.GetComponentInParent<scr_DebrisPlante>().GetFriend() == true)
                    {
                        _hitDebris = hitInfo.collider.GetComponentInParent<scr_DebrisPlante>();
                        _hitDebris.Interact();
                        _witchActor.GetComponentInParent<scr_WitchMovement>().SetNewTarget(_hitDebris.gameObject);
                        _hitDebris = null;
                    }
                }
            }

        }
        if (UIManager.Instance.GetMenuOpen() == true)
        {
            _AMenuIsOpen = true;
        }
        else
        {
            _AMenuIsOpen = false;
        }
    }
}
