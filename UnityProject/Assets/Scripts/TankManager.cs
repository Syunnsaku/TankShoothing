//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class TankManager : Singleton<TankManager>
{
	public void           AddCrushingCount()  { mCrushingCount++;       }
	public TankController GetTankController() { return mTankController; }


	protected override void Initialize()
	{
		mCrushingCount                 = 0;
		mTankObject                    = Instantiate(Resources.Load("Tanks/DefaultTank") as GameObject);
		mTankObject.transform.parent   = gameObject.transform;
		mTankObject.transform.position = new Vector3(0f,0.5f,5f);
		mTankComponent                 = mTankObject.AddComponent<Tank>();
		mTankController                = mTankObject.AddComponent<TankController>();
		mTankController.SetTank(mTankComponent);
		mTankComponent.SetHelth(100);
		GameObject.Find("CameraController").GetComponent<CameraController>().SetTankController(mTankController);
	}
	//===================================
	// Start
	//===================================


	//===================================
	// private Variable
	//===================================
	private GameObject     mTankObject;
	private TankController mTankController;
	private Tank           mTankComponent;
	private int            mCrushingCount;
}
