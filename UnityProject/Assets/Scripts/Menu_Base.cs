//*******************************************
// Name Space
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//*******************************************
// Class
//*******************************************
public class Menu_Base : MonoBehaviour 
{
	//===================================
	// Start
	//===================================
	protected virtual void Awake()
	{
		Button[] aButtons;
		//mCanvas = gameObject.GetComponent<Canvas>();

		aButtons = gameObject.GetComponentsInChildren<Button>();
		foreach(Button aButton in aButtons)
		{
			string aButtonName = aButton.name;

			if (aButton.name.EndsWith("(Clone)"))
			{
				aButtonName.Replace("(Clone)","");
				aButton.onClick.AddListener(() => OnButtonPressed(aButtonName));
			}
			aButton.onClick.AddListener(() => OnButtonPressed(aButtonName));
		}
	}
	//===================================
	// Start
	//===================================
	private void Start()
	{

	}
	public void SetUp(GameObject iButtonObject)
	{
	}
		

	//===================================
	// OnButtonPressed
	//===================================
	public virtual void OnButtonPressed(string iButtonName)
	{
	}
	//===================================
	// Pirvate Variable
	//===================================
	//private Dictionary<GameObject,Button> mButtons = new Dictionary<GameObject,Button>();
	//private Canvas mCanvas;
}
