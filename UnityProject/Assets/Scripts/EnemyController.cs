using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	private const string NAME_INJECTIONPOINT = "InjectionPoint";

	public float CooldownTime        = 1.00f;
	public float CoolDownTimeCount   = 0.00f;

	private void Awake()
	{
		mInjectionPoint = gameObject.transform.FindChild(NAME_INJECTIONPOINT).gameObject;
	}

	private void Update()
	{
		transform.Translate(Vector3.forward * (Time.deltaTime * 15));

		CoolDownTimeCount += Time.deltaTime;
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

	public void Fire()
	{
		GameObject aBullet = Instantiate(Resources.Load("Bullets/Shell")) as GameObject;
		aBullet.layer = 9;
		aBullet.transform.rotation = new Quaternion(0.0f,180.0f,0.0f,0.0f);
		aBullet.transform.position = mInjectionPoint.transform.position;
		aBullet.AddComponent<EnemyBulletControll>();
		Bullet aBulletComponent = aBullet.AddComponent<Bullet>();
		aBulletComponent.AttackPower = 10;
	}

	public void Deth()
	{
		GameObject aEffect = Instantiate(Resources.Load("Effects/Exploson1") as GameObject);
		aEffect.AddComponent<EffectOneShot>();
		Destroy(gameObject);
	}

	private GameObject mInjectionPoint;
	private bool       mIsCoolDown;
}
