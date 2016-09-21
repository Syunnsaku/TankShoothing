//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//*******************************************
// Class
//*******************************************
public class SpawnPoint : MonoBehaviour 
{
	//================================
	// Acseccor
	//================================
	public int GetID() { return ID; } 

	//================================
	// SetUp
	//================================
	public void SetUp(int iID, string iName, Vector3 iPosition)
	{
		ID              = iID;
		gameObject.name = iName;
		gameObject.transform.position = iPosition;
	}

	//================================
	// Private Variable
	//================================
	private int ID;
}
