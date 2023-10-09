using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class EnemyGenerator : ViewController
	{
		private float mCurrentSeconds = 0f;

		private void Update() {
			mCurrentSeconds += Time.deltaTime;
			if (Player.Default && mCurrentSeconds > 1.5f) {
				mCurrentSeconds = 0;
				var randomAngle = Random.Range(0, 360f);
				var randomRadius = randomAngle * Mathf.Deg2Rad;
				var direction = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius), 0);
				var generatePos = Player.Default.transform.position + direction * 10;
				Enemy.Instantiate().Position(generatePos).Show();
			}
		}
	}
}
