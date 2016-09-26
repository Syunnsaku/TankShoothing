using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	private const string NAME_INJECTIONPOINT = "InjectionPoint";

	public void SetEnemy(Enemy iEnemy) { mEnemy = iEnemy; }

	public float CooldownTime        = 1.00f;
	public float CoolDownTimeCount   = 0.00f;

	private void Awake()
	{
		mInjectionPoint  = gameObject.transform.FindChild(NAME_INJECTIONPOINT).gameObject;
		mInitialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		mIsCoolDown      = false;
	}

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
			Destroy(gameObject);
		}
	}

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

	public void Deth()
	{
		GameObject aEffect = Instantiate(Resources.Load("Effects/Exploson1") as GameObject);
		aEffect.AddComponent<EffectOneShot>();
		Destroy(gameObject);
	}

	private GameObject mInjectionPoint;
	private bool       mIsCoolDown;
	private Enemy      mEnemy;
	private Vector3    mInitialPosition;
	private float      mTimeCount;
}
