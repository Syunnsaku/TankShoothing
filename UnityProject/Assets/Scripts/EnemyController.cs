using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	//===================================
	// Public Variable
	//===================================
	public float CooldownTime        = 1.00f;
	public float CoolDownTimeCount   = 0.00f;

	//===================================
	// Acsessor
	//===================================
	public void SetEnemy       (Enemy        iEnemy       ) { mEnemy        = iEnemy;       }
	public void SetSpawnManager(SpawnManager iSpawnManager) { mSpawnManager = iSpawnManager;}

	//===================================
	// Awake
	//===================================
	private void Awake()
	{
		mInjectionPoint  = gameObject.transform.FindChild(NAME_INJECTIONPOINT).gameObject;
		mInitialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		mIsCoolDown      = false;
	}

	//===================================
	//  Update
	//===================================
	private void Update()
	{
		if(mEnemy == null)          { return; }
		if(mEnemy.IsSetUp == false) { return; }
		mTimeCount += Time.deltaTime;

		EnemyMove();

		if(mIsCoolDown == false)
		{
			CoolDownTimeCount += Time.deltaTime;
		}
		if(CoolDownTimeCount > CooldownTime)
		{
			mIsCoolDown = true;
			Fire();
			CoolDownTimeCount = 0.00f;
		}
		if(this.gameObject.transform.position.z < -200)
		{
			mSpawnManager.SetRemoveSpawnEnemy(gameObject);
			Destroy(gameObject);
		}
	}
	//===================================
	// Enemy Move
	//===================================
	public void EnemyMove()
	{
		Vector3 aMovePosition;
		switch((int)mEnemy.GetEnemyMoveType())
		{
			case 0:
				break;
			case 1:
				transform.Translate(Vector3.forward * (Time.deltaTime * 15));
				break;
			case 2:
				transform.Translate(Vector3.forward * (Time.deltaTime * 15));
				aMovePosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
				transform.position = new Vector3((Mathf.Sin(mTimeCount)*20 ) + mInitialPosition.x,transform.position.y,transform.position.z);
				break;
			case 3:
				transform.Translate(Vector3.forward * (Time.deltaTime * 15));
				aMovePosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
				transform.position = new Vector3((Mathf.Sin(mTimeCount)*20 ) + mInitialPosition.x,transform.position.y,transform.position.z);
				break;
		}

	}

	//===================================
	// Fire
	//===================================
	public void Fire()
	{
		GameObject aBullet = Instantiate(Resources.Load("Bullets/Shell")) as GameObject;
		aBullet.layer = 9;
		aBullet.transform.rotation = new Quaternion(0.0f,180.0f,0.0f,0.0f);
		aBullet.transform.position = mInjectionPoint.transform.position;
		aBullet.AddComponent<EnemyBulletControll>();
		Bullet aBulletComponent = aBullet.AddComponent<Bullet>();
		aBulletComponent.AttackPower = 10;
		mIsCoolDown = false;
	}

	//===================================
	// Deth
	//===================================
	public void Deth()
	{
		GameObject aEffect = Instantiate(Resources.Load("Effects/Exploson1") as GameObject);
		aEffect.AddComponent<EffectOneShot>();
		mSpawnManager.SetRemoveSpawnEnemy(gameObject);
		Destroy(gameObject);
	}

	//===================================
	// Read Only
	//===================================
	private readonly string NAME_INJECTIONPOINT = "InjectionPoint";

	//===================================
	// Private Variable
	//===================================
	private bool         mIsCoolDown;
	private Enemy        mEnemy;
	private float        mTimeCount;
	private Vector3      mInitialPosition;
	private GameObject   mInjectionPoint;
	private SpawnManager mSpawnManager;
}
