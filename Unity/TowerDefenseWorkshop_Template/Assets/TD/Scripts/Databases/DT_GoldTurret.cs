
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

[CreateAssetMenu(menuName = "GameSup/DataBaseTurretPrice", fileName = "DataBaseTurretPrice")]
public class DT_GoldTurret : ScriptableObject
{
	[SerializeField]
	private int _priceTurret1 = 100;
	[SerializeField]
	private int _priceTurret2 = 150;
	[SerializeField]
	private int _priceTurret3 = 200;



	public int GetPriceTurret1()
	{
		return _priceTurret1;

	}
	public int GetPriceTurret2()
	{
		return _priceTurret2;

	}
	public int GetPriceTurret3()
	{
		return _priceTurret3;

	}

}
