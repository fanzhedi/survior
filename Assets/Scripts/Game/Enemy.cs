using UnityEngine;
using QFramework;

namespace Survior
{
	public partial class Enemy : ViewController
	{
		private float MoveSpeed = 2.0f;
		void Start()
		{
			// Code Here
		}

		private void Update() {
			if (Player.Default) {
				var dir = (Player.Default.transform.position - transform.position).normalized;
				transform.Translate(MoveSpeed * Time.deltaTime * dir);
			}
		}
	}
}
