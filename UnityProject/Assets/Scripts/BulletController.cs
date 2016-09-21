//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class BulletController : MonoBehaviour 
{
	//===================================
	// Acseccer
	//===================================
	public void SetTarget(Vector3 iTarget)                  { Target = iTarget;            }
	public void SetMyTransform(Transform iBulletTransform)  {mMyTransform = iBulletTransform; }
	//===================================
	// PUblic Variable
	//===================================
	public float      FiringAngle = 1.0f;
	public float      Gravity     = 9.8f;
	public Vector3    Target;
	public Transform  Projectile;      

	//===================================
	// Awake
	//===================================
	private void Awake()
	{
		Projectile     = transform;
	}

	private void OnCollisionEnter(Collision iCollision)
	{
		Enemy aEnemy = iCollision.gameObject.GetComponent<Enemy>();
		EnemyController aEnemyController = iCollision.gameObject.GetComponent<EnemyController>();
		if(aEnemy == null || aEnemyController == null) { return; }
		GameObject aHitEffect = Instantiate(Resources.Load("Effects/TankHit") as GameObject);
		aHitEffect.AddComponent<EffectOneShot>();
		aHitEffect.transform.position = gameObject.transform.position;
		Bullet aBullet = gameObject.GetComponent<Bullet>();
		bool aLive = aEnemy.Damage(aBullet.AttackPower);
		if(aLive == false)
		{
			aEnemyController.Deth();
		}
		Destroy(gameObject);
	}
		
	//===================================
	// Start
	//===================================

	public void Fire()
	{
		StartCoroutine(SimulateProjectile());
	}
		

	private IEnumerator SimulateProjectile()
	{
		yield return null;

		Projectile.position = mMyTransform.position + new Vector3(0, 0.0f, 0);

		float TargetDistance = Vector3.Distance(Projectile.position, Target);

		float projectile_Velocity = TargetDistance / (Mathf.Sin(2 * FiringAngle * Mathf.Deg2Rad) / Gravity);

		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(FiringAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(FiringAngle * Mathf.Deg2Rad);

		//float flightDuration = TargetDistance / Vx;

		Projectile.rotation = Quaternion.LookRotation(Target - Projectile.position);

		float elapse_time = 0;

		while (transform.position.y > 0.5f)
		{
			Projectile.Translate(0, (Vy - (Gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

			elapse_time += Time.deltaTime;

			yield return null;
		}

		GameObject aEffect = Instantiate(Resources.Load("Effects/TestExplosion") as GameObject);
		aEffect.transform.position = Vector3.zero;
		aEffect.transform.position = gameObject.transform.position;
		aEffect.AddComponent<EffectOneShot>();

		Destroy(gameObject);
	}

	//===================================
	// private Variable
	//===================================
	private Transform   mMyTransform;
}
