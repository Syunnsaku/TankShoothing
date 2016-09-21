//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//*******************************************
// Class
//*******************************************
public class StageManager : MonoBehaviour 
{
	//===================================
	// public Variable
	//===================================
	public bool IsStageStop;

	//===================================
	// Acseccer
	//===================================
	public bool GetStageStop()                                   {return IsStageStop;                         }
	public void SetStageStop(bool iIsStageStop)                  {IsStageStop = iIsStageStop;                 }
	public void RemoveStageController(GameObject iGroundObuject) {mGrounds.Remove(iGroundObuject);            }


	//===================================
	// Start
	//===================================
	public void Start()
	{
		for(int i = 0; i <3; i++)
		{
			GameObject aStage = Instantiate(Resources.Load(PATH_STAGE)) as GameObject;
			aStage.AddComponent<StageController>();
			mGrounds.Add(aStage);
			StageController aStageController = aStage.GetComponent<StageController>();
			aStageController.SetStageManager(gameObject.GetComponent<StageManager>());

			switch(i)
			{
				case 0:
					aStage.transform.position = new Vector3(0f,0f,150f);
					aStage.transform.parent   = gameObject.transform;
					break;
				case 1:
					aStage.transform.position = new Vector3(0f,0f,450f);
					aStage.transform.parent   = gameObject.transform;
					break;
				case 2:
					aStage.transform.position = new Vector3(0f,0f,750f);
					aStage.transform.parent   = gameObject.transform;
					break;
			}
		
		}
	}

	//===================================
	// CreatGround
	//===================================
	public void CreatGround()
	{
		GameObject aStage = Instantiate(Resources.Load(PATH_STAGE)) as GameObject;
		aStage.AddComponent<StageController>();

		mGrounds.Add(aStage);
		StageController aStageController = aStage.GetComponent<StageController>();
		aStageController.SetStageManager(gameObject.GetComponent<StageManager>());
		Vector3 LastGround = Vector3.zero;
		foreach(GameObject aGround in mGrounds)
		{
			if(LastGround.z < aGround.transform.position.z)
			{
				LastGround = aGround.transform.position;
			}
		}
		aStage.transform.position = new Vector3(LastGround.x, LastGround.y,(LastGround.z + 150)) ;
		aStage.transform.parent   = gameObject.transform;
	}
	//===================================
	// Update
	//===================================
	public void Update()
	{
	}


	//===================================
	// private Variable
	//===================================
	private List<GameObject> mGrounds   = new List<GameObject>();
	private const string     PATH_STAGE = "Stages/Ground";
}
