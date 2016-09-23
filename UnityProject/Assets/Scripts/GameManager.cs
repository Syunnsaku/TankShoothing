using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> 
{
	public void SetIsGaemInProgress(bool iIsGameInProgress) { mIsGameInProgress = iIsGameInProgress; }

	protected override void Initialize()
	{
		mIsGameInProgress = true;
	}
		
	public void GameOver()
	{
		if(mIsGameInProgress == false) { return; }
		Menu_Main aMenuMain = UIManager.GetInstance().GetMenu("Menu_Main").GetComponent<Menu_Main>();
		aMenuMain.GameOver();
	}

	private Animator mMainMenuAnimator;
	private bool     mIsGameInProgress;
}
