using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Survivor
{
	// Generate Id:579f8990-b260-4633-a8f5-47a187084878
	public partial class UIGameStart
	{
		public const string Name = "UIGameStart";
		
		[SerializeField]
		public UnityEngine.UI.Button GoldUp;
		[SerializeField]
		public UnityEngine.UI.Image GoldUpPanel;
		[SerializeField]
		public UnityEngine.UI.Button ExpUp;
		[SerializeField]
		public UnityEngine.UI.Button goldUp;
		[SerializeField]
		public UnityEngine.UI.Text CoinCount;
		[SerializeField]
		public UnityEngine.UI.Button Close;
		
		private UIGameStartData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			GoldUp = null;
			GoldUpPanel = null;
			ExpUp = null;
			goldUp = null;
			CoinCount = null;
			Close = null;
			
			mData = null;
		}
		
		public UIGameStartData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameStartData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameStartData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
