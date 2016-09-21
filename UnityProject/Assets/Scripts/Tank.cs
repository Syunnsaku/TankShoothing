//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class Tank : MonoBehaviour 
{
	//===================================
	// Enum
	//===================================
	public enum AttackType
	{
		SINGLESHOT,
		RATEOFFIRE,
		DIFFUSION,
		LASER,
		BOMB,
	}
	//===================================
	// SetParameter
	//===================================
	public void SetHelth(float iHelth) { Helth = iHelth; }

	public virtual bool Damage(float iDamage) 
	{
		bool iLive = true;
		Helth -= iDamage;
		if (Helth <= 0)
		{
			iLive = false;
		}
		return iLive;
	}

	//===================================
	// Parameter
	//===================================
	public float Helth;
	public AttackType TankAttackType;
}
