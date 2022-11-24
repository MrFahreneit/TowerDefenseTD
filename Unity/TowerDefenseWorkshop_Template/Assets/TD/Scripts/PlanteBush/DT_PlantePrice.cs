
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

[CreateAssetMenu(menuName = "GameSup/DataBasePlantPrice", fileName = "DataBasePlantPrice")]
public class DT_PlantePrice : ScriptableObject
{
	[SerializeField]
	private int _pricePlanteA = 100;
	[SerializeField]
	private int _pricePlanteB = 150;
	[SerializeField]
	private int _pricePlanteC = 200;



	public int GetPricePlanteA()
    {
		return _pricePlanteA;

	}
	public int GetPricePlanteB()
	{
		return _pricePlanteB;

	}
	public int GetPricePlanteC()
	{
		return _pricePlanteC;

	}

}