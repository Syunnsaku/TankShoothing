//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class Tank : MonoBehaviour 
{
	//===================================
	// Enum
	//===================================
	public enum AttackType
	{
		NONE       = 0,
		SINGLESHOT = 1,
		DIFFUSION  = 2,
		RATEOFFIRE = 3,
		LASER      = 4,
		BOMB       = 5,
	}

	//===================================
	// Parameter
	//===================================
	public float       Helth;
	public  AttackType TankAttackType;

	//===================================
	// SetParameter
	//===================================
	public void SetHelth(float iHelth) { Helth = iHelth; }

	private void Awake()
	{
		mInjectionPoint = gameObject.transform.FindChild(NAME_INJECTIONPOINT).gameObject;
	}


	//===================================
	// Damage
	//===================================
	public virtual bool Damage(float iDamage) 
	{
		bool iLive = true;
		Helth -= iDamage;
		if (Helth <= 0)
		{
			iLive = false;
		}
		return iLive;
	}


	//===================================
	// Attack patern
	//===================================
	public void SingleShot()
	{
		GameObject       aBullet                    = Instantiate(Resources.Load(PATH_BULLETS)) as GameObject;
		BulletController aBulletControllerComponent = aBullet.AddComponent<BulletController>();
		Bullet           aBulletComponent           = aBullet.AddComponent<Bullet>();

		aBulletComponent.SetUp(100,20,50,Bullet.BulletType.NORMAL);

		aBullet.transform.parent                    = mInjectionPoint.transform;
		aBullet.transform.position                  = mInjectionPoint.transform.position;
		Vector3 aInjectionPointPosition             = new Vector3(mInjectionPoint.transform.position.x,mInjectionPoint.transform.position.y,mInjectionPoint.transform.position.z);
		aBulletControllerComponent.SetMyTransform(aBullet.transform);
		Vector3 aTarget                             = new Vector3(transform.position.x,transform.position.y,transform.position.z + aBulletComponent.Range);
		aBulletControllerComponent.SetTarget(aTarget);
		aBulletControllerComponent.Fire();
	}

	public void Diffusion()
	{
		for(int i = 0; i < 3; i++)
		{
			GameObject       aBullet                      = Instantiate(Resources.Load(PATH_BULLETS)) as GameObject;
			BulletController aBulletController            = aBullet.AddComponent<BulletController>();
			Bullet           aBulletComponent             = aBullet.AddComponent<Bullet>();
			aBulletComponent.SetUp(100,20,50,Bullet.BulletType.NORMAL);
			aBullet.transform.parent                      = mInjectionPoint.transform;
			aBullet.transform.position                    = mInjectionPoint.transform.position;
			Vector3 aTarget;
			switch(i)
			{
				case 0:
					aBullet.name                          = aBullet.name + "_Center";
					aTarget 		                      = new Vector3(transform.position.x,transform.position.y,transform.position.z + aBulletComponent.Range);
					aBulletController.SetTarget(aTarget);
					break;
				case 1:
					aBullet.name                           = aBullet.name + "_Right";
					aTarget 		                       = new Vector3(transform.position.x +5,transform.position.y,transform.position.z + aBulletComponent.Range);
					aBulletController.SetTarget(aTarget);

					break;
				case 2:
					aBullet.name                           = aBullet.name + "_Left";
					aTarget 		                       = new Vector3(transform.position.x -5,transform.position.y,transform.position.z + aBulletComponent.Range);
					aBulletController.SetTarget(aTarget);

					break;
			}

			aBulletController.SetMyTransform(aBullet.transform);
			aBulletController.Fire();
		}
	}


	public void RateOfFire()
	{
		GameObject       aBullet                    = Instantiate(Resources.Load(PATH_BULLETS)) as GameObject;
		BulletController aBulletControllerComponent = aBullet.AddComponent<BulletController>();
		Bullet           aBulletComponent           = aBullet.AddComponent<Bullet>();

		aBulletComponent.SetUp(100,10,50,Bullet.BulletType.NORMAL);

		aBullet.transform.parent                    = mInjectionPoint.transform;
		aBullet.transform.position                  = mInjectionPoint.transform.position;
		Vector3 aInjectionPointPosition             = new Vector3(mInjectionPoint.transform.position.x,mInjectionPoint.transform.position.y,mInjectionPoint.transform.position.z);
		aBulletControllerComponent.SetMyTransform(aBullet.transform);
		Vector3 aTarget                             = new Vector3(transform.position.x,transform.position.y,transform.position.z + aBulletComponent.Range);
		aBulletControllerComponent.SetTarget(aTarget);
		aBulletControllerComponent.Fire();
	}

	public void Laser()
	{
		GameObject       aBullet                    = Instantiate(Resources.Load("Bullets/Laser")) as GameObject;
		aBullet.transform.parent                    = mInjectionPoint.transform;
		aBullet.transform.position                  = mInjectionPoint.transform.position;
	}


	//===================================
	// Read Only
	//===================================
	private readonly string NAME_INJECTIONPOINT = "InjectionPoint";
	private readonly string PATH_BULLETS        = "Bullets/Shell";

	//===================================
	// private Variable
	//===================================
	private GameObject   mInjectionPoint;

}
