using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMain : Scene
{
	protected override void Initialize()
	{
		GameObject aTankManager          = new GameObject();
		aTankManager.name                = "TankManager";
		aTankManager.AddComponent<TankManager>();
		aTankManager.transform.position  = Vector3.zero;

		GameObject aStageManager         = new GameObject();
		aStageManager.name               = "StageManager";
		aStageManager.AddComponent<StageManager>();
		aStageManager.transform.position = Vector3.zero;

		GameObject aGameManager          = new GameObject();
		aGameManager.name                = "GameManager";
		aGameManager.AddComponent<GameManager>();
		aGameManager.transform.position  = Vector3.zero;

		GameObject aSpawnManager         = new GameObject();
		aSpawnManager.name               = "SpawnManager";
		aSpawnManager.AddComponent<SpawnManager>();
		aSpawnManager.transform.position = Vector3.zero;

		GetUIManager().MenuBoot(MENU_MAIN_NAME);

	}

	private readonly string MENU_MAIN_NAME = "Menu_Main";
}
