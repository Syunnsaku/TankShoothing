//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class TankController : MonoBehaviour 
{
	//===================================
	// Acseccer
	//===================================
	public bool GetIsPermission()                          { return mIsPermission;          }
	public void SetIsPermission(bool iIsPermission)        { mIsPermission = iIsPermission; }
	public void SetTank(Tank iTank)                        { mTank         = iTank;         }
	public void SetAlert(bool iIsAlert)                    { mIsAlert      = iIsAlert;      }
	public void SetAttackType(Tank.AttackType iAttackType) 
	{
		mAttackType   = iAttackType;
		switch((int)mAttackType)
		{
			case 1:
				CooldownTime = 0.8f;
				break;
			case 2:
				CooldownTime = 0.5f;
				break;
			case 3:
				CooldownTime = 0.1f;
				break;
		}
	}

	//=================================
	// Public Variable
	//=================================
	public float CoolDownTimeCount   = 0.00f;
	public float CooldownTime        = 0.8f;

	public void Damage(float iDamage)
	{
		mUIGauge.OnDamage(iDamage);

		bool aLive = mTank.Damage(iDamage);
		if(aLive == false) { Death(); }

	}

	//===================================
	// Update
	//===================================
	private void Awake()
	{
		mIsPermission   = false;
		mIsCoolDown     = false;
		mTankAnimator   = gameObject.GetComponent<Animator>();
	}

	private void SetHpBar()
	{
		GameObject aMenuBar = UIManager.GetInstance().BootUI("HPGauge","Menu_Main",UIManager.Anchor.BOTTOM.ToString());
		aMenuBar.transform.localPosition = new Vector3(0.0f,50.0f,0.0f);
		mUIGauge                         = aMenuBar.GetComponent<UIGauge>();
		mUIGauge.SetUp(mTank.Helth);
	}

	//===================================
	// Start
	//===================================
	private void Start()
	{
		mIsPermission = true;
		mTankAnimator.SetBool("Idle",true);
		SetHpBar();
	}

	//===================================
	// Update
	//===================================
	private void Update ()
	{
		CoolDownTimeCount += Time.deltaTime;
		if(CoolDownTimeCount > CooldownTime)
		{
			mIsCoolDown = true;
			CoolDownTimeCount = 0.00f;
		}
		TankControlle();
	}

	public void BootAlert()
	{
		Menu_Main aMenuMain = UIManager.GetInstance().GetMenu("Menu_Main").GetComponent<Menu_Main>();
		aMenuMain.UI_Alert.SetActive(true);
		aMenuMain.UI_Alert.transform.SetAsLastSibling();

	}

	public void TerminateAlert()
	{
		Menu_Main aMenuMain = UIManager.GetInstance().GetMenu("Menu_Main").GetComponent<Menu_Main>();
		aMenuMain.UI_Alert.SetActive(false);
	}

	//===================================
	// Start
	//===================================
	private void TankControlle()
	{
		if (Input.anyKey)
		{
			if(Input.GetKey(KeyCode.RightArrow))
			{
				mTankAnimator.SetBool("Idle",false);
				mTankAnimator.SetBool("TurnRight",true);
				mTankAnimator.SetBool("TurnLeft",false);
				transform.Translate(Vector3.right * (Time.deltaTime * 5));
				transform.position = new Vector3(Mathf.Clamp(transform.position.x,-45.0f,45.0f),transform.position.y,transform.position.z);
			}
			else
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				mTankAnimator.SetBool("Idle",false);
				mTankAnimator.SetBool("TurnRight",false);
				mTankAnimator.SetBool("TurnLeft",true);
				transform.Translate(Vector3.left * (Time.deltaTime * 5));
				transform.position = new Vector3(Mathf.Clamp(transform.position.x,-45.0f,45.0f),transform.position.y,transform.position.z);
			}
		}
		else
		{
			mTankAnimator.SetBool("Idle",true);
			mTankAnimator.SetBool("TurnRight",false);
			mTankAnimator.SetBool("TurnLeft",false);
		}

		if(Input.GetKey(KeyCode.Space))
		{
			if(mIsPermission && mIsCoolDown)
			{
				//mIsPermission = false;
				mIsCoolDown = false;
				LaunchFire();
			}
		}

	}

	public void Death()
	{
		GameObject aEffect = Instantiate(Resources.Load("Effects/Exploson1")) as GameObject;
		aEffect.transform.localScale = new Vector3(10,10,10);

		//aEffect.transform.position = gameObject.transform.position;
		Vector3 aEffectTransform   = gameObject.transform.position;
		aEffect.transform.position = new Vector3(aEffectTransform.x,5.0f,aEffectTransform.z);
		GameManager.GetInstance().GameOver();
		Destroy(gameObject);
	}

	//===================================
	// LaunchFire
	//===================================
	private void LaunchFire()
	{
		switch((int)mAttackType)
		{
			case 0:
				break;
			case 1:
				mTank.SingleShot();
				break;
			case 2:
				mTank.Diffusion();
				break;
			case 3:
				mTank.RateOfFire();
				break;
			case 4:
				mTank.Laser();
				break;
		}
	}

	//===================================
	// Private Variable
	//===================================
	private bool            mIsPermission;
	private bool            mIsCoolDown;
	private bool            mIsAlert;
	private Tank            mTank;
	private UIGauge         mUIGauge;
	private Animator        mTankAnimator;
	private Tank.AttackType mAttackType;
}
