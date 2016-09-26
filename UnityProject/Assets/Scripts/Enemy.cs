//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class Enemy : Tank 
{
	//===================================
	// Enum
	//===================================
	public enum EnemyType
	{
		NOMAL,
	}

	public enum EnemyMoveType
	{
		NONE      = 0,
		STRAIGHTA = 1,
	}

	//===================================
	// Public Variable
	//===================================
	public bool IsSetUp;

	//===================================
	// Acsessor
	//===================================
	public EnemyMoveType GetEnemyMoveType()                             { return mEnemyMoveType;           }
	public float         GetMovSpeed()                                  { return mMoveSpeed;               }

	private void Awake()
	{
		IsSetUp = false;
	}

	//===================================
	// SetUp
	//===================================
	public void SetUpEnemyData(EnemyMoveType iEnemyMoveType, float iMoveSpeed, float iHelth)
	{
		mEnemyMoveType = iEnemyMoveType;
		mMoveSpeed     = iMoveSpeed;
		Helth          = iHelth;
		IsSetUp        = true;
	}

	public override bool Damage(float iHelth)
	{
		return base.Damage(iHelth);
	}

	private EnemyMoveType mEnemyMoveType;
	private float         mMoveSpeed;
}
