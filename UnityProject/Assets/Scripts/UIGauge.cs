using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGauge : MonoBehaviour 
{
	public Image HpSprite;
	public Image MoveSprite;
	public GameObject actionLabel;

	private void Awake()
	{
		mDamageColor = new Vector4(0.5f, 0, 0, 1);
		mHealColor = new Vector4(0.3f, 1, 0.5f, 1);
	}

	public void SetUp(float iMaxHP)
	{
		mMaxHp = iMaxHP;
		mNowHp = mMaxHp;
		HpSprite.fillAmount   = mNowHp  / mMaxHp;
		MoveSprite.fillAmount = mMoveHp / mMaxHp;
	}

	public void OnDamage(int iDamage)
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
				mNowHp -= Mathf.FloorToInt(mMaxHp * Time.deltaTime * 0.3f);
				if(mNowHp < mMoveHp)
				{
					mNowHp = mMoveHp;	
				}
				MoveSprite.color      = mDamageColor;
				HpSprite.fillAmount   = mMoveHp / mMaxHp;
				MoveSprite.fillAmount = mNowHp / mMaxHp;
			}
			else
			{
				mNowHp += Mathf.FloorToInt(mMaxHp * Time.deltaTime * 0.3f);
				if(mNowHp > mMoveHp) 
				{
					mNowHp = mMoveHp;	
				}

				MoveSprite.color      = mHealColor;
				HpSprite.fillAmount   = mNowHp  / mMaxHp;
				MoveSprite.fillAmount = mMoveHp / mMaxHp;

			}
		}
	}
	private float   mMaxHp;
	private float   mNowHp;
	private float   mMoveHp;
	private Vector4 mDamageColor;
	private Vector4 mHealColor;
}
