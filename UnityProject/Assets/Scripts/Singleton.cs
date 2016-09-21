//*******************************************
// Name Space
//*******************************************
using UnityEngine;

//*******************************************
// Class
//*******************************************
public abstract class Singleton<T_Type> : MonoBehaviour where T_Type : Singleton<T_Type> 
{
	private static T_Type sInstance = null;

	private  void  Awake()
	{
		T_Type aInstance = GetInstance();
		if (aInstance == null) { aInstance = this as T_Type; }
		if (aInstance != (this as T_Type))
		{
			Destroy(gameObject);
			return;
		}

		sInstance = aInstance;
		Initialize();
		GameObject.DontDestroyOnLoad(gameObject);
	}

	//===================================
	// Singleton
	//===================================
	protected abstract void Initialize();

	public static T_Type GetInstance()
	{
		if (sInstance == null) 
		{
			sInstance = (T_Type)FindObjectOfType(typeof(T_Type));

			if (sInstance == null) 
			{
				Debug.LogError (typeof(T_Type) + "is nothing");
			}
		}
		return sInstance;
	}
}