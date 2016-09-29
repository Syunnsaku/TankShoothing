//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//*******************************************
// Class
//*******************************************
public class TankManager : Singleton<TankManager>
{
	public void           AddCrushingCount () { mCrushingCount++;       }
	public TankController GetTankController() { return mTankController; }

	protected override void Initialize()
	{
		mCrushingCount                 = 0;
		mTankObject                    = Instantiate(Resources.Load(TANK_PATH+"DefaultTank") as GameObject);
		mTankObject.transform.parent   = gameObject.transform;
		mTankObject.transform.position = new Vector3(0f,0.5f,5f);
		mTankComponent                 = mTankObject.AddComponent<Tank>();
		mTankController                = mTankObject.AddComponent<TankController>();

		mTankController.SetTank(mTankComponent);
		mTankController.SetAttackType(Tank.AttackType.DIFFUSION);

		mTankComponent.SetHelth(100);
		GameObject.Find("CameraController").GetComponent<CameraController>().SetTankController(mTankController);
	}

	//===================================
	// Start
	//===================================

	//===================================
	// Read Only
	//===================================
	private readonly string TANK_PATH = "Tanks/";

	//===================================
	// private Variable
	//===================================
	private int            mCrushingCount;
	private Tank           mTankComponent;
	private GameObject     mTankObject;
	private TankController mTankController;
}
