//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class Name
//*******************************************
public class GameManager : Singleton<GameManager> 
{
	//===================================
	// Public Variable
	//===================================
	public void SetIsGaemInProgress(bool iIsGameInProgress) { mIsGameInProgress = iIsGameInProgress; }

	//===================================
	// Initialize
	//===================================
	protected override void Initialize()
	{
		mIsGameInProgress = true;
	}
		
	//===================================
	// Gameover
	//===================================
	public void GameOver()
	{
		Menu_Main aMenuMain;
		if(mIsGameInProgress == false) { return; }

		aMenuMain = UIManager.GetInstance().GetMenu("Menu_Main").GetComponent<Menu_Main>();
		aMenuMain.GameOver();
	}

	//===================================
	// private Variable
	//===================================
	private Animator mMainMenuAnimator;
	private bool     mIsGameInProgress;
}
