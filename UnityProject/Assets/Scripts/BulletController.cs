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
	public void SetTarget     (Vector3   iTarget         )  {Target       = iTarget;          }
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
		mSpawnmanager  = SpawnManager.GetInstance();
	}

	//===================================
	// On Collision Entere
	//===================================
	private void OnCollisionEnter(Collision iCollision)
	{
		// Enemy           aEnemy           = iCollision.gameObject.GetComponent<Enemy          >();
		// EnemyController aEnemyController = iCollision.gameObject.GetComponent<EnemyController>();

		// if(aEnemy == null || aEnemyController == null) { return; }

		// GameObject      aHitEffect       = Instantiate(Resources.Load("Effects/TankHit") as GameObject);
		// Bullet          aBullet          = gameObject.GetComponent<Bullet>();
		// bool            aLive            = aEnemy.Damage(aBullet.AttackPower);
	
		// aHitEffect.AddComponent<EffectOneShot>();
		// aHitEffect.transform.position    = gameObject.transform.position;
	
		// if(aLive == false)
		// {
		// 	aEnemyController.Deth();
		// }
		// Destroy(gameObject);
	}
		
	//===================================
	// Start
	//===================================
	public void Fire()
	{
		Bullet aBullet      = gameObject.GetComponent<Bullet>();
		StartCoroutine(SimulateProjectile());
	}

	//===================================
	// Update
	//===================================
	private void Update()
	{
		Vector3 aBulletPosition;
		Vector3 aEnemyPosition;
		float   aDistanceX;
		float   aDistanceZ;

		aBulletPosition       = gameObject.transform.position;
		GameObject[] aEnemys  = mSpawnmanager.GetSpawnEnemys().ToArray(); 
		for(int i = 0; i < aEnemys.Length; i++)
		{
			aEnemyPosition = aEnemys[i].transform.position;
			aDistanceX     = aBulletPosition.x - aEnemyPosition.x;
			aDistanceZ     = aEnemyPosition.z  - aBulletPosition.z;

			if(aDistanceX >= -2 && aDistanceX <= 2)
			{
				if(aDistanceZ <= 2 && aDistanceZ >= -2)
				{
					Enemy           aEnemy           = aEnemys[i].GetComponent<Enemy          >();
					EnemyController aEnemyController = aEnemys[i].GetComponent<EnemyController>();
					Bullet          aBullet          = gameObject.GetComponent<Bullet>();
					bool            aLive            = aEnemy.Damage(aBullet.AttackPower);
					GameObject      aHitEffect       = Instantiate(Resources.Load("Effects/TankHit") as GameObject);
				
					aHitEffect.AddComponent<EffectOneShot>();
					aHitEffect.transform.position    = gameObject.transform.position;

					if(aLive == false)
					{
						aEnemyController.Deth();
					}
					Destroy(gameObject);
				}
			}

		}
		foreach(GameObject aGameObject in mSpawnmanager.GetSpawnEnemys())
		{
		}
	}
		

	private IEnumerator SimulateProjectile()
	{
		Projectile.rotation = Quaternion.LookRotation(Target - Projectile.position);
		yield return null;

		Projectile.position       = mMyTransform.position + new Vector3(0, 0.0f, 0);

		float TargetDistance      = Vector3.Distance(Projectile.position, Target);
		float projectile_Velocity = TargetDistance / (Mathf.Sin(2 * FiringAngle * Mathf.Deg2Rad) / Gravity);

		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(FiringAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(FiringAngle * Mathf.Deg2Rad);

		//float flightDuration = TargetDistance / Vx;


		float elapse_time = 0;

		while (transform.position.y > 0.5f)
		{
			Projectile.Translate(0, (Vy - (Gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

			elapse_time += Time.deltaTime;

			yield return null;
		}

		GameObject aEffect         = Instantiate(Resources.Load(EFFECTS_PATH + "TestExplosion") as GameObject);
		aEffect.transform.position = Vector3.zero;
		aEffect.transform.position = gameObject.transform.position;
		aEffect.AddComponent<EffectOneShot>();

		Destroy(gameObject);
	}

	//===================================
	// private Variable
	//===================================
	private readonly string EFFECTS_PATH = "Effects/";

	//===================================
	// private Variable
	//===================================
	private Transform    mMyTransform;
	private SpawnManager mSpawnmanager;
}
