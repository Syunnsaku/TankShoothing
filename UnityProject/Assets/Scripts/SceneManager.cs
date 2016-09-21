//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;

//*******************************************
// Class
//*******************************************
public class SceneManager : Singleton<SceneManager> 
{
	private enum StateSceneFade
	{
		BEFORBLACKOUT,
		INBLACKOUT,
		AFTERBLACKOUT,
	}
	//===================================
	// Awake
	//===================================
	protected override void Initialize()
	{
		if (this != SceneManager.GetInstance())
		{
			Destroy (this);
			return;
		}

		mFadeAlpha = 0;
		mIsFading  = false;

		this.mBlackTexture = new Texture2D(32, 32, TextureFormat.RGB24, false);
		this.mBlackTexture.ReadPixels (new Rect (0, 0, 32, 32), 0, 0, false);
		this.mBlackTexture.SetPixel (0, 0, Color.white);
		this.mBlackTexture.Apply ();
	}

	//===================================
	// OnGUI
	//===================================
	public void OnGUI ()
	{
		if (!this.mIsFading) { return; }

		GUI.color = new Color (0, 0, 0, this.mFadeAlpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), this.mBlackTexture);
	}

	//===================================
	// LoadLevel
	//===================================
	public void ScenRequest(string iScene, float iInterval)
	{
		mCurrentScene = iScene;
		StartCoroutine (TransScene (iScene, iInterval));
	}
	  
	  
	private IEnumerator TransScene (string iScene, float iInterval)
	{
		this.mIsFading = true;
		float aTime     = 0;
		while(aTime <= iInterval)
		{
			this.mFadeAlpha = Mathf.Lerp (0f, 1f, aTime / iInterval);      
			aTime += Time.deltaTime;
			yield return 0;
		}

		Destroy(mCurrentSceneObject);

		Application.LoadLevel (iScene);
		yield return null;
		mCurrentSceneObject                         = new GameObject();
		mCurrentSceneObject.transform.parent        = gameObject.transform;
		mCurrentSceneObject.transform.localPosition = Vector3.zero;
		mCurrentSceneObject.name                    = iScene;
		System.Type aClassName = System.Type.GetType(SceneClassName + iScene);
		mCurrentSceneObject.AddComponent(aClassName);

		aTime = 0;
		while (aTime <= iInterval)
		{
			this.mFadeAlpha = Mathf.Lerp (1f, 0f, aTime / iInterval);
			aTime += Time.deltaTime;
			yield return 0;
		}

		this.mIsFading = false;
	}

	//===================================
	// Private Variable
	//===================================
	private float          mFadeAlpha;
	private bool           mIsFading;
	private string         mCurrentScene;
	private Texture2D      mBlackTexture;
	private StateSceneFade mStateScene;
	private GameObject     mCurrentSceneObject;
	private const string   SceneClassName = "Scene";
}
