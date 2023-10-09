using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class Enemy : ViewController
	{
		public int HP = 3;
		public float MoveSpeed = 2.0f;
		void Start()
		{
			// Code Here
		}

		private void Update() {
			if (Player.Default) {
				var dir = (Player.Default.transform.position - transform.position).normalized;
				transform.Translate(MoveSpeed * Time.deltaTime * dir);
			}

			if (HP <= 0) {
				// UIKit.OpenPanel<UIGameOverPanel>(new UIGameOverPanelData(){
				// 	Name = "游戏通关"
				// });
				this.DestroyGameObjGracefully();
				Global.Exp.Value++;
			}
		}
	}
}
