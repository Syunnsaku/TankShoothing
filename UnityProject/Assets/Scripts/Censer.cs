using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Censer : MonoBehaviour 
{
	private void Awake()
	{
		mDetectionAlready = false;
	}

	private void Start()
	{
		mTankController = transform.parent.gameObject.GetComponent<TankController>();
	}

	private void OnTriggerStay(Collider iCollider)
	{
		mIsDetection = true;
		if(iCollider.gameObject.layer == 9)
		{
			mDetectionAlready = true;
		}
	}

	private void FixedUpdate()
	{
		if(mIsDetection == true)
		{
			mIsDetection = false;
			mTankController.BootAlert();
		}
		else
		if(mIsDetection == false)
		{
			mTankController.TerminateAlert();
		}

	}

	private TankController mTankController;
	private bool           mDetectionAlready;
	private bool           mIsDetection;
}
