//*******************************************
// Name Space
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class UIManager : Singleton<UIManager>
{
	//===================================
	// Enum
	//===================================
	public enum Anchor
	{
		TOP          = 1,
		TOP_RIGHT    = 2,
		TOP_LEFT     = 3,
		CENTER       = 4,
		CENTER_RIGHT = 5,
		CENTER_LEFT  = 6,
		BOTTOM       = 7,
		BOTTOM_RIGHT = 8,
		BOTTOM_LEFT  = 9,
	}

	//===================================
	// Initialize
	//===================================
	protected override void Initialize() {} 

	//===================================
	// Get Menu
	//===================================
	public GameObject GetMenu(string iMenuName)
	{
		GameObject aMenuObject;

		aMenuObject  = mBoothingMenu[iMenuName];

		return aMenuObject;
	}

	//===================================
	// Boot Menu
	//===================================
	public void MenuBoot(string iMenuName)
	{
		GameObject aBootMenu;

		aBootMenu                         = Instantiate(Resources.Load(UIsPATH + iMenuName)) as GameObject;
		aBootMenu.transform.parent        = gameObject.transform;
		aBootMenu.transform.localPosition = Vector3.zero;

		mBoothingMenu.Add(iMenuName,aBootMenu);
	}

	public GameObject BootUI(string iUIName,string iMenuName,string iAnchor)
	{
		GameObject aUIObject;
		Transform  aParentMenu;
		Transform  aAnchor;

		aUIObject                  = Instantiate(Resources.Load(UIsPATH + iUIName)) as GameObject;
	    aParentMenu                = mBoothingMenu[iMenuName].gameObject.transform;
		aAnchor                    = aParentMenu.FindChild(iAnchor);
		aUIObject.transform.parent = aAnchor;

		return aUIObject;
	}
		
		
	//===================================
	// Termiante Menu
	//===================================
	public void MenuTerminate(string iMenuName)
	{
		GameObject aMenu;
		
		aMenu = mBoothingMenu[iMenuName];
		mBoothingMenu.Remove(iMenuName);
		Destroy(aMenu);
	}
	//===================================
	// Read Only
	//===================================
	private readonly string UIsPATH = "UIs/";

	//===================================
	// Read Only
	//===================================
	private Dictionary<string,GameObject> mBoothingMenu = new Dictionary<string,GameObject>();
}
