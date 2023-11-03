using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Survivor
{
	// Generate Id:021f6ce4-7cf4-4d08-861d-06f706146f50
	public partial class UIGameStart
	{
		public const string Name = "UIGameStart";
		
		
		private UIGameStartData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
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
