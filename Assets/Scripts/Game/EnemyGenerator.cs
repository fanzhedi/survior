using UnityEngine;
using QFramework;
using System.Collections.Generic;
using System;
using UnityEngine.AI;

namespace Survivor
{
	[Serializable]
	public class EnemyWave
	{
		public float GenerageDuration = 1;
		public GameObject EnemyPerfab;
		public int Seconds = 10;
	}
	public partial class EnemyGenerator : ViewController
	{
		private float mCurrentWaveSeconds = 0f;
		private float mCurrentWaveGenerateSeconds = 0f;

		public List<EnemyWave> EnemyWaves = new List<EnemyWave>();

		private Queue<EnemyWave> mEnemyWaveQueue = new Queue<EnemyWave>();

		public int CurrentWaveCount = 0;

		public bool LastWave => CurrentWaveCount == EnemyWaves.Count;

		public EnemyWave CurrentWave => mCurrentWave;

		//剩余敌人数量
		public static BindableProperty<int> EnemyCount = new(0);

		private EnemyWave mCurrentWave;

		private void Start() {
			foreach (EnemyWave enemyWave in EnemyWaves) {
				mEnemyWaveQueue.Enqueue(enemyWave);
			}
		}

		private void Update() {
			if (mCurrentWave == null && mEnemyWaveQueue.Count > 0) {
				mCurrentWave = mEnemyWaveQueue.Dequeue();
				mCurrentWaveSeconds = 0;
				mCurrentWaveGenerateSeconds = 0;
				CurrentWaveCount++;
			}
			if (mCurrentWave != null)
			{
				mCurrentWaveSeconds += Time.deltaTime;
				mCurrentWaveGenerateSeconds += Time.deltaTime;

				if (Player.Default && mCurrentWaveGenerateSeconds > mCurrentWave.GenerageDuration) {
					mCurrentWaveGenerateSeconds = 0;
					var randomAngle = UnityEngine.Random.Range(0, 360f);
					var randomRadius = randomAngle * Mathf.Deg2Rad;
					var direction = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius), 0);
					var generatePos = Player.Default.transform.position + direction * 10;
					mCurrentWave.EnemyPerfab.Instantiate().Position(generatePos).Show();
				}
				if (mCurrentWaveSeconds > mCurrentWave.Seconds)
				{
					mCurrentWave = null;
				}
			}
		}
	}
}
