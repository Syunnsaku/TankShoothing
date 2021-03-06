﻿//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************

public class GameInitializer : MonoBehaviour 
{
	//===================================
	// Public Variable
	//===================================
	public SceneName FirstScene;

	//===================================
	// Awake
	//===================================
	private void Awake()
	{
		Debug.Log(Application.targetFrameRate + "___________");
		Initialize();
	}

	//===================================
	// Start
	//===================================
	private void Start()
	{
		Destroy(gameObject);
	}

	//===================================
	// BootFirstScene
	//===================================
	private void BootFirstScene()
	{
		SceneManager.GetInstance().ScenRequest(FirstScene.ToString(),1.0f);
	}

	//===================================
	// Initialize
	//===================================
	private void Initialize()
	{
		GameObject aUIManager;
		GameObject aSceneManager;

		aUIManager                    = Instantiate(Resources.Load("Objects/UIManager")) as GameObject;
		aUIManager.transform.position = Vector3.zero;

		aSceneManager                 = new GameObject();
		aSceneManager.name            = "SceneManager";
		aSceneManager.AddComponent<SceneManager>();

		BootFirstScene();
	}
}
