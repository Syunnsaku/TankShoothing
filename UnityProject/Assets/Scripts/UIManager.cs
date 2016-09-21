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
	public enum Anchor
	{
		TOP,
		TOP_RIGHT,
		TOP_LEFT,
		CENTER,
		CENTER_RIGHT,
		CENTER_LEFT,
		BOTTOM,
		BOTTOM_RIGHT,
		BOTTOM_LEFT,
	}

	//===================================
	// Initialize
	//===================================
	protected override void Initialize() {} 

	public GameObject GetMenu(string iMenuName)
	{
		GameObject aMenuObject = mBoothingMenu[iMenuName];
		return aMenuObject;
	}

	//===================================
	// Boot Menu
	//===================================
	public void MenuBoot(string iMenuName)
	{
		GameObject aBootMenu              = Instantiate(Resources.Load(UIsPATH + iMenuName)) as GameObject;
		aBootMenu.transform.parent        = gameObject.transform;
		aBootMenu.transform.localPosition = Vector3.zero;
		mBoothingMenu.Add(iMenuName,aBootMenu);
	}

	public GameObject BootUI(string iUIName,string iMenuName,string iAnchor)
	{
		GameObject aUIObject;
		aUIObject                  = Instantiate(Resources.Load(UIsPATH + iUIName)) as GameObject;
		Transform aParentMenu      = mBoothingMenu[iMenuName].gameObject.transform;
		Transform aAnchor          = aParentMenu.FindChild(iAnchor);
		aUIObject.transform.parent = aAnchor;
		return aUIObject;
	}
		
		
	//===================================
	// Termiante Menu
	//===================================
	public void MenuTerminate(string iMenuName)
	{
		GameObject aMenu = mBoothingMenu[iMenuName];
		mBoothingMenu.Remove(iMenuName);
		Destroy(aMenu);
	}

	private const string UIsPATH = "UIs/";
	private Dictionary<string,GameObject> mBoothingMenu = new Dictionary<string,GameObject>();
}
