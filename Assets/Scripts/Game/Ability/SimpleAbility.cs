using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class SimpleAbility : ViewController
	{

		private float mCurrentSec = 0f;
		void Start()
		{
			// Code Here
		}

		private void Update() {
			mCurrentSec += Time.deltaTime;
			if (Player.Default && mCurrentSec >= 1.5f)
			{
				mCurrentSec = 0f;
				Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

				foreach (var enemy in enemies) 
				{
					var distance = (Player.Default.transform.position - enemy.transform.position).magnitude;
					if (distance <= 5)
					{
						enemy.Hurt();
					}
				}
			}
		}
	}
}
