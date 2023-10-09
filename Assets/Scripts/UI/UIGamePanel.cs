using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Survivor
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
			// please add init code here

			Global.Exp.RegisterWithInitValue(exp =>
			{
				ExpText.text = "经验值：" + exp;
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			Global.Exp.RegisterWithInitValue(exp => 
			{ 
				if (exp >= 5) {
					Global.Exp.Value = 0;
					Global.Level.Value++;
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
			Global.Level.Register(lv=> 
			{
				Time.timeScale = 0;
				Upgrade.Show();

			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			Global.Level.RegisterWithInitValue(lv=> 
			{
				LevelText.text = "等级：" + lv;
		 	}).UnRegisterWhenGameObjectDestroyed(gameObject);

			Upgrade.onClick.AddListener(() =>
			{
				Time.timeScale = 1.0f;
			});

			Upgrade.Hide();
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
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
