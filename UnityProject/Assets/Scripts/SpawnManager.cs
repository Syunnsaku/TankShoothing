//*******************************************
// Name Space
//*******************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//*******************************************
// Class
//*******************************************
public class SpawnManager : Singleton<SpawnManager> 
{
	//===================================
	// Acsessor
	//===================================
	//public Dictionary<int, GameObject> void GetSpawnPoint() {return mSpawnPoint;}
	//===================================
	// Awake
	//===================================
	public int   OneSideLength     = 6;
	public float SpawnPointBreadth = 5;
	public float TimeCount         = 0f;
	public int   CreatCount        = 0;
	public int   NextSpawnTime     = 0;
	public int   CreatWaveID       = 1;
	//===================================
	// Initialize
	//===================================
	protected override void Initialize()
	{
		mIsGoWave = false;
		CreatSpawnPoint();
		SetWaveData();
	}

	private void SetWaveData()
	{
		mWaveData = Instantiate(Resources.Load("GameData/WaveData")) as WaveData;
		//CreatCount = mWaveData.sheets[0].list.Count;
	}

	//===================================
	// SpawnEnemy
	//===================================
	private void SpawnEnemy()
	{
		GameObject aEnemyObject              = Instantiate(Resources.Load(ENEMY_PATH + "Enemy_" + mWaveData.sheets[0].list[CreatCount].EnemyID)) as GameObject;
		Transform SetSpawnPoint              = mSpawnPoints[mWaveData.sheets[0].list[CreatCount].SpawnID].transform;
		aEnemyObject.transform.parent        = SetSpawnPoint;
		aEnemyObject.transform.localPosition = Vector3.zero;
		EnemyController aEnemyController     = aEnemyObject.AddComponent<EnemyController>();
		Enemy aEnemy                         = aEnemyObject.AddComponent<Enemy>();
		aEnemy.SetHelth(40);
		CreatCount++;
	}

	public void Update()
	{
		if(CreatCount >= mWaveData.sheets[0].list.Count) { return; }
		TimeCount += Time.deltaTime;
		if(TimeCount > mWaveData.sheets[0].list[CreatCount].SpawnTime)
		{
			SpawnEnemy();
		}

	}

	//===================================
	// CreatSpawnPoint
	//===================================
	private void CreatSpawnPoint()
	{
		int aID                             = 1;
		GameObject aSpawnPoint              = new GameObject();
		SpawnPoint aSpawnComponent          = aSpawnPoint.AddComponent<SpawnPoint>();
		aSpawnPoint.transform.parent        = gameObject.transform;
		Vector3 aSpawnCenterPosition        = new Vector3(0.0f,1.0f,100.0f);
		aSpawnComponent.SetUp(aID,"0",aSpawnCenterPosition);
		mSpawnPoints.Add(aID,aSpawnPoint);

		for(int i = 0; i < OneSideLength; i++)
		{
			aID++;
			GameObject aSpawnRight              = new GameObject();
			SpawnPoint aSpawnRightComponent     = aSpawnRight.AddComponent<SpawnPoint>();
			aSpawnRight.transform.parent        = gameObject.transform;
			Vector3 aSpawnRightPosition;
			aSpawnRightPosition = new Vector3((SpawnPointBreadth*(i+1)),1.0f,100.0f);

			string aNumber  = string.Format("{0}",i+1);
			aSpawnRightComponent.SetUp(aID,aNumber,aSpawnRightPosition);
			mSpawnPoints.Add(aID,aSpawnRight);
		}

		for(int i = 0; i < OneSideLength; i++)
		{
			aID++;
			GameObject aSpawnLeft               = new GameObject();
			SpawnPoint aSpawnLeftComponent      = aSpawnLeft.AddComponent<SpawnPoint>();
			aSpawnLeft.transform.parent         = gameObject.transform;
			Vector3 aSpawnLeftPosition          = new Vector3((SpawnPointBreadth*-(i+1)),1.0f,100.0f);
			string aNumber  = string.Format("{0}",-(i+1));
			aSpawnLeftComponent.SetUp(aID,aNumber,aSpawnLeftPosition);
			mSpawnPoints.Add(aID,aSpawnLeft);
		}
	}

	//===================================
	// private ReadOnly
	//===================================
	private readonly string ENEMY_PATH = "Tanks/Enemys/";
	//===================================
	// Private Variable
	//===================================
	private Dictionary<int,GameObject> mSpawnPoints = new Dictionary<int,GameObject>();
	private bool mIsGoWave;
	private WaveData mWaveData;
}




