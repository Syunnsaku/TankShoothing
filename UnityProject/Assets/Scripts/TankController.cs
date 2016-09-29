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
	//=================================
	// Public Variable
	//=================================
	public float CoolDownTimeCount   = 0.00f;
	public float CooldownTime        = 0.8f;

	//===================================
	// Acseccer
	//===================================
	public bool GetIsUseBoost()                              { return mIsUseBoost;            }
	public bool GetIsPermission()                            { return mIsPermission;          }
	public void SetIsPermission(bool iIsPermission)          { mIsPermission = iIsPermission; }
	public void SetTank        (Tank iTank)                  { mTank         = iTank;         }
	public void SetAlert       (bool iIsAlert)               { mIsAlert      = iIsAlert;      }
	public void SetAttackType  (Tank.AttackType iAttackType) 
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

	//===================================
	// Damage
	//===================================
	public void Damage(float iDamage)
	{
		bool aLive;

		mUIGauge.OnDamage(iDamage);
		aLive = mTank.Damage(iDamage);

		if(aLive == false) { Death(); }

	}

	public CameraController GetCameraController()
	{
		if(mCameraController == null)
		{
			mCameraController = Camera.main.gameObject.transform.parent.GetComponent<CameraController>();
		}
		return mCameraController;
	}


	//===================================
	// Update
	//===================================
	private void Awake()
	{
		mIsPermission   = false;
		mIsCoolDown     = false;
		mIsUseBoost     = false;
		mBoostRightFlag = false;
		mBoostLeftFlag  = false;
		mTankAnimator   = gameObject.GetComponent<Animator>();
	}

	private void SetHpBar()
	{
		GameObject aMenuBar;

		aMenuBar                         = UIManager.GetInstance().BootUI("HPGauge","Menu_Main",UIManager.Anchor.BOTTOM.ToString());
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
		Menu_Main aMenuMain;

		aMenuMain = UIManager.GetInstance().GetMenu("Menu_Main").GetComponent<Menu_Main>();

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
		if(mBoostRightFlag == true || mBoostLeftFlag == true)
		{
			mBoostCounter += Time.deltaTime;

			if(mIsUseBoost == false)
			{
				if(Input.GetKeyUp(KeyCode.RightArrow))
				{
					Debug.Log(transform.position + "_____________________Use Boost ____________________");
					// transform.position = new Vector3(transform.position.x + 10 , transform.position.y,transform.position.z);
					transform.Translate(Vector3.right * (Time.deltaTime * 100));
					transform.position = new Vector3(Mathf.Clamp(transform.position.x,-45.0f,45.0f),transform.position.y,transform.position.z);
					GetCameraController().TankBoostTorres(true);
					mBoostRightFlag    = false;
					mIsUseBoost        = true; 
				}
				else
				if(Input.GetKeyUp(KeyCode.LeftArrow))
				{
					Debug.Log(transform.position + "_____________________Use Boost ____________________");
					//transform.position = new Vector3(transform.position.x - 10 , transform.position.y,transform.position.z);
					transform.Translate(Vector3.left * (Time.deltaTime * 100));
					transform.position = new Vector3(Mathf.Clamp(transform.position.x,-45.0f,45.0f),transform.position.y,transform.position.z);
					GetCameraController().TankBoostTorres(false);

					mBoostLeftFlag     = false;
					mIsUseBoost        = true; 
				}
				else
				if(mBoostCounter > 0.5)
				{				
					mBoostRightFlag    = false;
					mBoostLeftFlag     = false;
					mBoostCounter      = 0;
				}
			}	
		}
		else
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			mBoostLeftFlag  = false;
			mBoostRightFlag = true;
		}
		else
		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			mBoostRightFlag = false;
			mBoostLeftFlag  = true;
		}

		if (Input.anyKey && mIsUseBoost == false)
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
		mIsUseBoost = false;

	}

	public void Death()
	{
		GameObject aEffect;
		Vector3    aEffectTransform;

		aEffect                      = Instantiate(Resources.Load("Effects/Exploson1")) as GameObject;
		aEffect.transform.localScale = new Vector3(10,10,10);
		aEffectTransform             = gameObject.transform.position;
		aEffect.transform.position   = new Vector3(aEffectTransform.x,5.0f,aEffectTransform.z);

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
	private bool             mIsPermission;
	private bool             mIsCoolDown;
	private bool             mIsAlert;
	private bool             mBoostRightFlag;
	private bool             mBoostLeftFlag;
	private bool             mIsUseBoost;
	private float            mBoostCounter;
	private Tank             mTank;
	private UIGauge          mUIGauge;
	private Animator         mTankAnimator;
	private Tank.AttackType  mAttackType;
	private CameraController mCameraController;
}
