using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControll : MonoBehaviour 
{
	private void Update()
	{
		gameObject.transform.Translate(Vector3.forward * (Time.deltaTime * 100));
		if(this.gameObject.transform.position.z < -200)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision iCollision)
	{
		Tank aTank = iCollision.gameObject.GetComponent<Tank>();
		TankController aTankController = iCollision.gameObject.GetComponent<TankController>();
		if(aTank == null || aTankController == null) { return; }
		GameObject aHitEffect = Instantiate(Resources.Load("Effects/TankHit") as GameObject);
		aHitEffect.AddComponent<EffectOneShot>();
		aHitEffect.transform.position = gameObject.transform.position;
		Bullet aBullet = gameObject.GetComponent<Bullet>();
		bool aLive = aTank.Damage(aBullet.AttackPower);
		if(aLive == false)
		{
			aTankController.Death();
		}
		Destroy(gameObject);
	}

}
