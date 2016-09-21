//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class TankManager : MonoBehaviour
{
	public void AddCrushingCount() { mCrushingCount++; }
	//===================================
	// Start
	//===================================
	private void Start ()
	{
		mCrushingCount                 = 0;
		mTankObject                    = Instantiate(Resources.Load("Tanks/DefaultTank") as GameObject);
		mTankObject.transform.parent   = gameObject.transform;
		mTankObject.transform.position = new Vector3(0f,0.5f,5f);
		mTankController                = mTankObject.AddComponent<TankController>();
		mTankComponent                 = mTankObject.AddComponent<Tank>();
		mTankComponent.SetHelth(10);
	}

	//===================================
	// private Variable
	//===================================
	private GameObject     mTankObject;
	private TankController mTankController;
	private Tank           mTankComponent;
	private int            mCrushingCount;
}
