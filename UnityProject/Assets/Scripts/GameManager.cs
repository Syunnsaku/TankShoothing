using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> 
{
	public void SetIsGaemInProgress(bool iIsGameInProgress) { mIsGameInProgress = iIsGameInProgress; }
	protected override void Initialize()
	{
	}
		
	public void GameOver()
	{
		Menu_Main aMenuMain = UIManager.GetInstance().GetMenu("Menu_Main").GetComponent<Menu_Main>();
		aMenuMain.GameOver();
	}

	private Animator mMainMenuAnimator;
	private bool     mIsGameInProgress;
}
