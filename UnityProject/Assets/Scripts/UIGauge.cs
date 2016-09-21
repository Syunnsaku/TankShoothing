using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGauge : MonoBehaviour 
{
	public Image HpSprite;
	public Image MoveSprite;
	public Slider HPSlider;
	public Slider MoveSlider;
	public GameObject actionLabel;

	private void Awake()
	{
	}

	public void SetUp(float iMaxHP)
	{
		mMaxHp  = iMaxHP;
		mNowHp  = mMaxHp;
		mMoveHp = mMaxHp;
		HPSlider.value   = 1.0f;
		MoveSlider.value = 1.0f;
	}

	public void OnDamage(float iDamage)
	{
		mMoveHp -= iDamage;
		if(mMoveHp < 0) 
		{
			mMoveHp = 0;	
		}
	}

	public void OnHeal(int iHeal)
	{
		mMoveHp += iHeal;
		if(mMoveHp > mMaxHp)
		{
			mMoveHp = mMaxHp;
		}
	}

	private void Update ()
	{
		if(mNowHp != mMoveHp)
		{
			if(mNowHp > mMoveHp)
			{
				mNowHp -= Mathf.FloorToInt(mMaxHp * Time.deltaTime * 0.8f);
				if(mNowHp < mMoveHp)
				{
					mNowHp = mMoveHp;	
				}
				HPSlider.value   = mMoveHp / mMaxHp;
				MoveSlider.value = mNowHp / mMaxHp;
			}
			else
			{
				mNowHp += Mathf.FloorToInt(mMaxHp * Time.deltaTime * 0.8f);
				if(mNowHp > mMoveHp) 
				{
					mNowHp = mMoveHp;	
				}

				HPSlider.value   = mMoveHp / mMaxHp;
				MoveSlider.value = mNowHp / mMaxHp;

			}
		}
	}
	private float   mMaxHp;
	private float   mNowHp;
	private float   mMoveHp;
}
