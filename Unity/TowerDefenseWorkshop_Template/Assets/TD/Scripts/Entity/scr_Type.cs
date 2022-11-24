using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Type : MonoBehaviour
{
	private enum TypeEntity { Ground, Air, GroundAir };
	[SerializeField]
	private TypeEntity _entityType;

	public int GetEntityType()
    {
        int _EntityIndex = 0;

        switch (_entityType)
        {
            case TypeEntity.Ground:
                _EntityIndex = 0;
                break;
            case TypeEntity.Air:
                _EntityIndex = 1;
                break;
            case TypeEntity.GroundAir:
                _EntityIndex = 2;
                break;
        }

        return _EntityIndex;


    }
}
