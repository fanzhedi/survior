using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class Enemy : ViewController
	{
		public float HP = 3.0f;
		public float MoveSpeed = 2.0f;
		void Start()
		{
			// Code Here
			EnemyGenerator.EnemyCount.Value++;
		}

		private void OnDestroy() {
			EnemyGenerator.EnemyCount.Value--;
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
				mIgnoreHurt = true;

				// TODO: 经验值掉落
			}
		}


		private bool mIgnoreHurt = false;
		public void Hurt()
		{
			if (mIgnoreHurt) { return; }
			Sprite.color = Color.red;
			// if
			ActionKit.Delay(0.2f, () =>
			{
				HP -= Global.SimpleAbilityDmage.Value;
				Sprite.color = Color.white;
			}).Start(this);
		}
	}
}
