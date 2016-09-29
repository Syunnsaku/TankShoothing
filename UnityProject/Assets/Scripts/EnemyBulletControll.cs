using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControll : MonoBehaviour 
{
	public void SetTankController(TankController iTankController) { mTankController = iTankController; }

	private void Awake()
	{
		mTankController = TankManager.GetInstance().GetTankController();
	}

	private void Update()
	{
		gameObject.transform.Translate(Vector3.forward * (Time.deltaTime * 100));
		
		if(this.gameObject.transform.position.z < -200)
		{
			Destroy(gameObject);
		}

		if(mTankController == null) { return; }

		Vector3 aBulletPosition;
		Vector3 aTankPosition;
		float   aDistanceX;
		float   aDistanceZ;

		aTankPosition   = mTankController.gameObject.transform.position;
		aBulletPosition = gameObject.transform.position;
		aDistanceX      = aBulletPosition.x - aTankPosition.x;
		aDistanceZ      = aBulletPosition.z - aTankPosition.z;

		if(aDistanceX >= -2 && aDistanceX <= 2)
		{
			if(aDistanceZ <= 2 && aDistanceZ >= -2)
			{
				mBullet = gameObject.GetComponent<Bullet>();
				mTankController.Damage(mBullet.AttackPower);

				GameObject aHitEffect         = Instantiate(Resources.Load("Effects/TankHit") as GameObject);
				aHitEffect.AddComponent<EffectOneShot>();
				aHitEffect.transform.position = gameObject.transform.position;
				Destroy(gameObject);
			}

		}
	}

	private TankController mTankController;
	private Bullet         mBullet;
}
