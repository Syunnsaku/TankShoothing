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
	public void             SetRemoveSpawnEnemy(GameObject iEnemy) {mSpownEnemy.Remove(iEnemy);}
	public List<GameObject> GetSpawnEnemys     ()                  { return mSpownEnemy;       }

	//===================================
	// Awake
	//===================================
	public int   OneSideLength     = 6;
	public int   CreatCount        = 0;
	public int   NextSpawnTime     = 0;
	public int   CreatWaveID       = 1;
	public float SpawnPointBreadth = 5;
	public float TimeCount         = 0f;
	
	//===================================
	// Initialize
	//===================================
	protected override void Initialize()
	{
		mIsGoWave = false;		
		CreatSpawnPoint();
		SetWaveData();
	}

	//===================================
	// Set Wave Data
	//===================================
	private void SetWaveData()
	{
		mWaveData  = Instantiate(Resources.Load("GameData/WaveData"))  as WaveData;
		mEnemyData = Instantiate(Resources.Load("GameData/EnemyData")) as EnemyData;
	}

	//===================================
	// CreatSpawnPoint
	//===================================
	private void Update()
	{
		if(CreatCount >= mWaveData.sheets[0].list.Count) { return; }
		TimeCount += Time.deltaTime;
		if(TimeCount > mWaveData.sheets[0].list[CreatCount].SpawnTime)
		{
			SpawnEnemy();
			CreatCount++;
		}		
	}

	//===================================
	// SpawnEnemy
	//===================================
	private void SpawnEnemy()
	{
		int        aCreatEnemyID             = mWaveData.sheets[0].list[CreatCount].EnemyID -1;
		string     aResourceName             = mEnemyData.sheets[0].list[aCreatEnemyID].Name;
		Transform  SetSpawnPoint             = mSpawnPoints[mWaveData.sheets[0].list[CreatCount].SpawnID].transform;
		GameObject aEnemyObject              = Instantiate(Resources.Load(ENEMY_PATH + aResourceName)) as GameObject;


		aEnemyObject.transform.parent        = SetSpawnPoint;
		aEnemyObject.transform.localPosition = Vector3.zero;

		EnemyController aEnemyController     = aEnemyObject.AddComponent<EnemyController>();
		Enemy           aEnemy               = aEnemyObject.AddComponent<Enemy          >();

		aEnemyController.SetEnemy(aEnemy);
		Enemy.EnemyMoveType aEnemyMoveType   = (Enemy.EnemyMoveType)mWaveData.sheets[0].list[CreatCount].EnemyMoveType;
		float               aEnemyMoveSpeed  = mEnemyData.sheets[0].list[aCreatEnemyID].Speed;
		float               aEnemyHelth      = mEnemyData.sheets[0].list[aCreatEnemyID].Heleth;

		aEnemyController.SetSpawnManager(this);
		mSpownEnemy.Add(aEnemyObject);
		aEnemy.SetUpEnemyData(aEnemyMoveType,aEnemyMoveSpeed,aEnemyHelth);
	}


	//===================================
	// CreatSpawnPoint
	//===================================
	private void CreatSpawnPoint()
	{
		int        aID;
		GameObject aSpawnPoint;
		SpawnPoint aSpawnComponent;
		Vector3    aSpawnPosition;
		string     aNumber;

		aID                          = 1;
		aSpawnPoint                  = new GameObject();
		aSpawnComponent              = aSpawnPoint.AddComponent<SpawnPoint>();
		aSpawnPoint.transform.parent = gameObject.transform;
 		aSpawnPosition               = new Vector3(0.0f,1.0f,100.0f);
		aSpawnComponent.SetUp(aID,"0",aSpawnPosition);
		mSpawnPoints.Add(aID,aSpawnPoint);


		for(int i = 0; i < OneSideLength; i++)
		{
			aID++;

			aSpawnPoint                    = new GameObject();
			aSpawnComponent                = aSpawnPoint.AddComponent<SpawnPoint>();
			aNumber                        = string.Format("{0}",i+1);
			
			aSpawnPoint.transform.parent   = gameObject.transform;
			aSpawnPosition                 = new Vector3((SpawnPointBreadth*(i+1)),1.0f,100.0f);

			aSpawnComponent.SetUp(aID,aNumber,aSpawnPosition);
			mSpawnPoints.Add(aID,aSpawnPoint);
		}

		for(int i = 0; i < OneSideLength; i++)
		{
			aID++;

			aSpawnPoint                    = new GameObject();
			aSpawnComponent                = aSpawnPoint.AddComponent<SpawnPoint>();
			aNumber                        = string.Format("{0}",-(i+1));

			aSpawnPoint.transform.parent   = gameObject.transform;
			aSpawnPosition                 = new Vector3((SpawnPointBreadth* (-(i+1))),1.0f,100.0f);

			aSpawnComponent.SetUp(aID,aNumber,aSpawnPosition);
			mSpawnPoints.Add(aID,aSpawnPoint);
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
	private List<GameObject>           mSpownEnemy  = new List<GameObject>();
	private bool                       mIsGoWave;
	private WaveData                   mWaveData;
	private EnemyData                  mEnemyData;
}




