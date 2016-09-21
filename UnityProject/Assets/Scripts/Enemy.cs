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
		STRAIGHTA,
	}

	public override bool Damage(float iHelth)
	{
		return base.Damage(iHelth);
	}
}
