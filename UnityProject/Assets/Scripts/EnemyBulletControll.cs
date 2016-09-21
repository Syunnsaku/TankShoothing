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
		TankController aTankController = iCollision.gameObject.GetComponent<TankController>();
		Bullet aBullet = gameObject.GetComponent<Bullet>();

		if(aTankController == null) { return; }
		aTankController.Damage(aBullet.AttackPower);

		GameObject aHitEffect         = Instantiate(Resources.Load("Effects/TankHit") as GameObject);
		aHitEffect.AddComponent<EffectOneShot>();
		aHitEffect.transform.position = gameObject.transform.position;
		Destroy(gameObject);
	}

}
