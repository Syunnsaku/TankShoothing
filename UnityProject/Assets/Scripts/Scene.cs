//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Enum
//*******************************************
public enum SceneName
{
	Start,
	Main,
}
	
//*******************************************
// Class
//*******************************************
public abstract class Scene : MonoBehaviour
{
	//===================================
	// Acseccor
	//===================================
	public UIManager GetUIManager() { return mUIManager; }

	//===================================
	// Initialize
	//===================================
	private void Awake()
	{
		mUIManager = UIManager.GetInstance();
		Initialize();
	}

	//===================================
	// TerminateScene
	//===================================
	public virtual void TerminateScene()
	{
		
	}
	//===================================
	// Initialize
	//===================================
	protected abstract void Initialize();

	//===================================
	// Private Variable
	//===================================
	private UIManager mUIManager;
}
