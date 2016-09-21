//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class EffectOneShot : MonoBehaviour 
{
	//===================================
	// Awake
	//===================================
	private void Awake()
	{
		mParticle       = gameObject.GetComponent<ParticleSystem>();
	}

	//===================================
	// Update
	//===================================
	private void Update()
	{
		if(mParticle != null)
		{
			if(mParticle.IsAlive() == false)
			{
				Destroy(gameObject);
			}
		}
	}

	//===================================
	// Private Variable
	//===================================
	private ParticleSystem mParticle;
}
