//*******************************************
// Name Space
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class Name
//*******************************************
public class SceneMain : Scene
{
	protected override void Initialize()
	{
		GameObject aTankManager;
		GameObject aStageManager;
		GameObject aGameManager;
		GameObject aSpawnManager;

		aTankManager                     = new GameObject();
		aTankManager.name                = "TankManager";
		aTankManager.transform.position  = Vector3.zero;
		aTankManager.AddComponent<TankManager>();


		aStageManager                    = new GameObject();
		aStageManager.name               = "StageManager";
		aStageManager.transform.position = Vector3.zero;
		aStageManager.AddComponent<StageManager>();		

		aGameManager                     = new GameObject();
		aGameManager.name                = "GameManager";
		aGameManager.transform.position  = Vector3.zero;
		aGameManager.AddComponent<GameManager>();


		aSpawnManager                    = new GameObject();
		aSpawnManager.name               = "SpawnManager";
		aSpawnManager.transform.position = Vector3.zero;
		aSpawnManager.AddComponent<SpawnManager>();

		GetUIManager().MenuBoot(MENU_MAIN_NAME);

	}

	//===================================
	// Read Only
	//===================================
	private readonly string MENU_MAIN_NAME = "Menu_Main";
}
