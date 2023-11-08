using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace Survivor
{
	public class UIGameStartData : UIPanelData
	{
	}
	public partial class UIGameStart : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameStartData ?? new UIGameStartData();
			// please add init code here
			
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			GoldUp.onClick.AddListener(() => 
			{
				GoldUpPanel.Show();
			});
			Close.onClick.AddListener(()=>
			{
				GoldUpPanel.Hide();
			});
			Global.Coin.RegisterWithInitValue(coin =>
			{
				CoinCount.text = "金币：" + coin;
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			ExpUp.onClick.AddListener(()=> 
			{
				if (Global.ExpPercent.Value < 1) {
					Global.ExpPercent.Value *= 1.5f;
				}
				
			});
			GoldUp.onClick.AddListener(()=> 
			{
				if (Global.GoldPercent.Value < 1) {
					Global.GoldPercent.Value *= 1.5f;
				}
			});

			ActionKit.OnUpdate.Register(()=> 
			{
				if (Input.GetKeyDown(KeyCode.Space)) 
				{
					CloseSelf();
					Global.Reset();
					SceneManager.LoadScene("Game");
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
