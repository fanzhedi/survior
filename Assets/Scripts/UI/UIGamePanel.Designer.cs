using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Survivor
{
	// Generate Id:00c0ace7-d17d-4590-a29a-16b579a3fc8d
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public UnityEngine.UI.Text ExpText;
		[SerializeField]
		public UnityEngine.UI.Text LevelText;
		[SerializeField]
		public UnityEngine.UI.Button UpgradeDamage;
		[SerializeField]
		public UnityEngine.UI.Button UpgradeDuration;
		[SerializeField]
		public UnityEngine.UI.Text TimeText;
		[SerializeField]
		public UnityEngine.UI.Text EnemyCount;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			ExpText = null;
			LevelText = null;
			UpgradeDamage = null;
			UpgradeDuration = null;
			TimeText = null;
			EnemyCount = null;
			
			mData = null;
		}
		
		public UIGamePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
