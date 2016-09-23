using UnityEngine;
using System.Collections;

public class Menu_Main : Menu_Base 
{
	public GameObject UI_GameOver;
	public GameObject UI_Alert;
	protected override void Awake()
	{
		base.Awake();
		mMainMenuAnimator = gameObject.GetComponent<Animator>();
		mMainMenuAnimator.SetBool("GameInProgress",false);
	}

	private void Start()
	{
	}

	public void GameOver()
	{
		UI_GameOver.SetActive(true);
		mMainMenuAnimator.SetBool("GameOver",true);
	}

	private void Update()
	{
		UI_Alert.transform.SetAsLastSibling();
	}
	private Animator   mMainMenuAnimator;      
}
