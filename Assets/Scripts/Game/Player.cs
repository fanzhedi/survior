using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class Player : ViewController
	{
		public static Player Default;

		private void Awake() {
			ResKit.Init();
			Default = this;
		}

		private void OnDestroy() {
			Default = null;
		}

		private float MoveSpeed = 5f;
		void Start()
		{
			// Code Here
			"hello survior".LogInfo();

			HurtBox.OnTriggerEnter2DEvent(Collider2D=> {
				this.DestroyGameObjGracefully();
				UIKit.OpenPanel<UIGameOverPanel>(new UIGameOverPanelData(){
					Name = "游戏结束"
				});
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

		private void Update() {
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");

			var dir = new Vector2(horizontal, vertical).normalized;
			SelfRigiBody2D.velocity = dir * MoveSpeed;
		}
	}
}
