//*******************************************
// Name Space
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class SceneStart : Scene 
{
	//===================================
	// Initialize
	//===================================
	protected override void Initialize()
	{
		GetUIManager().MenuBoot(MENU_NAME);
	}

	//===================================
	// private Variable
	//===================================
	private readonly string MENU_NAME = "Menu_Start";

}
