using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public void SetTankController(TankController iTankController) { mTankController = iTankController; }
	private void Update()
	{
		if(mTankController == null) { return; }

		if(mIsMoveCamera == false)
		{
			TankTorres();
		}
		else
		{
			if(mIsWait == true) { return; }
			Vector3 aTankPosition    = mTankController.gameObject.transform.position;
			float   aTankControllerX = aTankPosition.x;
			float   aDistance        = aTankControllerX - gameObject.transform.position.x;

			if(mIsBoostRight == true)
			{
				if(aDistance > 0)
				{
					gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.05f, gameObject.transform.position.y,gameObject.transform.position.z);
					Debug.Log(aDistance);
				}
				else
				if(aDistance < 0)
				{
						gameObject.transform.position = new Vector3(aTankPosition.x,gameObject.transform.position.y,gameObject.transform.position.z);
						mIsMoveCamera = false;
				}
			}
			else
			{
				if(aDistance < 0)
				{
					gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y,gameObject.transform.position.z);
					Debug.Log(aDistance);
				}
				else
				if(aDistance > 0)
				{
						gameObject.transform.position = new Vector3(aTankPosition.x,gameObject.transform.position.y,gameObject.transform.position.z);
						mIsMoveCamera = false;
				}

			}


		}
	}

	private void TankTorres()
	{
		Vector3 aTorresTransform;
		aTorresTransform   = new Vector3(mTankController.transform.position.x,transform.position.y,transform.position.z);
		transform.position = aTorresTransform;
	}

	public void TankBoostTorres(bool iIsRight)
	{
		 mIsBoostRight = iIsRight;
		 mIsMoveCamera = true;
		 mIsWait = true;
		 StartCoroutine("MoveWait");
	}

	private IEnumerator MoveWait()
	{
		 yield return new WaitForSeconds(1f);
		 mIsWait = false;
		 yield return null;
	} 

	private bool           mIsBoostRight;
	private bool           mIsMoveCamera;
	private bool           mIsWait;
	private TankController mTankController;
}
