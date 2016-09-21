using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public void SetTankController(TankController iTankController) { mTankController = iTankController; }
	private void Update()
	{
		if(mTankController == null) { return; }
		TankTorres();
	}

	private void TankTorres()
	{
		Vector3 aTorresTransform;
		aTorresTransform   = new Vector3(mTankController.transform.position.x,transform.position.y,transform.position.z);
		transform.position = aTorresTransform;
	}

	private TankController mTankController;
}
