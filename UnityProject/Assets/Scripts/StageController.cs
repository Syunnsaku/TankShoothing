//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//*******************************************
// Class
//*******************************************
public class StageController : MonoBehaviour 
{
	public void SetStageManager(StageManager iStageManager) { mStageManager = iStageManager; }

	//===================================
	// public Variable
	//===================================

	//===================================
	// Awake
	//===================================
	private void Awake()
	{
		mIsCreatNextGround = true;
	}

	//===================================
	// MoveStage
	//===================================
	public void MoveStage()
	{
		transform.Translate(Vector3.back * (Time.deltaTime * 100));
	}


	//===================================
	// Update
	//===================================
	public void Update()
	{
		MoveStage();
		if(this.gameObject.transform.position.z < 0 && mIsCreatNextGround)
		{
			mIsCreatNextGround = false;
			NextCreatGround();
		}
		else
		if(this.gameObject.transform.position.z < -200)
		{
			mStageManager.RemoveStageController(gameObject);
			Destroy(gameObject);
		}
	}

	//===================================
	// NextCreatGround
	//===================================
	private void NextCreatGround()
	{
		mStageManager.CreatGround();
	}

	//===================================
	// private Variable
	//===================================
	private StageManager  mStageManager;
	private bool          mIsCreatNextGround;
}
