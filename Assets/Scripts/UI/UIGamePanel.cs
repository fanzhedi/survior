using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System;

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

			Global.Reset();

			Global.Exp.RegisterWithInitValue(exp =>
			{
				ExpText.text = "经验值：(" + exp + "/"+Global.LevelUpExp()+")";
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			Global.Exp.RegisterWithInitValue(exp => 
			{ 
				if (exp >= Global.LevelUpExp()) {
					Global.Exp.Value -= Global.LevelUpExp();
					Global.Level.Value++;
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
			Global.Level.Register(lv=> 
			{
				Time.timeScale = 0;
				UpgradeDamage.Show();
				UpgradeDuration.Show();

			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			Global.Level.RegisterWithInitValue(lv=> 
			{
				LevelText.text = "等级：" + lv;
		 	}).UnRegisterWhenGameObjectDestroyed(gameObject);

			UpgradeDamage.onClick.AddListener(() =>
			{
				Global.SimpleAbilityDmage.Value *= 1.5f;
				Time.timeScale = 1.0f;
				UpgradeDamage.Hide();
				UpgradeDuration.Hide();
			});
			UpgradeDuration.onClick.AddListener(() =>
			{
				Global.SimpleAbilityDuration.Value *= 0.8f;
				Time.timeScale = 1.0f;
				UpgradeDuration.Hide();
				UpgradeDamage.Hide();
			});

			EnemyGenerator.EnemyCount.RegisterWithInitValue(enmeyCount=>
			{
				EnemyCount.text = "敌人：" + enmeyCount;
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			Global.CurrentSeconds.RegisterWithInitValue(mCurrentSeconds => 
			{
				int msecondInt = Mathf.FloorToInt(mCurrentSeconds);
				int seconds = msecondInt % 60;
				int min = msecondInt / 60;
				TimeText.text = "时间：" + $"{min:00}:{seconds:00}";
		 	}).UnRegisterWhenGameObjectDestroyed(gameObject);

			var enemyGenerator = FindObjectOfType<EnemyGenerator>();
			ActionKit.OnUpdate.Register( () =>
			{ 
				Global.CurrentSeconds.Value += Time.deltaTime;

				if (enemyGenerator.LastWave && enemyGenerator.CurrentWave == null && EnemyGenerator.EnemyCount.Value == 0) {
					UIKit.OpenPanel<UIGameOverPanel>(new UIGameOverPanelData{
						Name = "游戏通关"
					});
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
			UpgradeDamage.Hide();
			UpgradeDuration.Hide();
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
