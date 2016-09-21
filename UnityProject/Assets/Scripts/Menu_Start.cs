//*******************************************
// Name Space
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class Menu_Start : Menu_Base 
{
	//===================================
	// Terminate
	//===================================
	public  void StartMain()
	{
		UIManager.GetInstance().MenuTerminate(MENU_START_NAME);
		SceneManager.GetInstance().ScenRequest(SCNE_MAIN_NAME,1.0f);
	}

	public override void OnButtonPressed(string iButtonName)
	{
		switch(iButtonName)
		{
			case "StartButton":
				StartMain();
				break;
		}
	}

	//===================================
	// ReadOnly
	//===================================
	private readonly string SCNE_MAIN_NAME  = "Main";
	private readonly string MENU_START_NAME = "Menu_Start";
	//===================================
	// Private Variable
	//===================================
}
