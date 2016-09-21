using UnityEngine;
using System.Collections;

public class Menu_Main : Menu_Base 
{
	public GameObject UI_GameOver;

	protected override void Awake()
	{
		base.Awake();
		mMainMenuAnimator = gameObject.GetComponent<Animator>();
		mMainMenuAnimator.SetBool("GameInProgress",false);

	}

	public void GameOver()
	{
		UI_GameOver.SetActive(true);
		mMainMenuAnimator.SetBool("GameOver",true);
	}

	private void Update()
	{
	}
	private Animator   mMainMenuAnimator;      
}
