//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class Bullet : MonoBehaviour 
{
	//===================================
	// Enum
	//===================================
	public enum BulletType
	{
		NORMAL,
	}

	//===================================
	// Public Variable
	//===================================
	public int        Range;
	public int        AttackPower;
	public int        BulletSpeed;
	public BulletType Variation;

	//===================================
	// SetUp
	//===================================
	public void SetUp(int iRange,int iAttackPower,int iBulletSpeed, BulletType iVariation)
	{
		Range       = iRange;
		AttackPower = iAttackPower;
		BulletSpeed = iBulletSpeed;
		Variation   = iVariation;
	}



}
