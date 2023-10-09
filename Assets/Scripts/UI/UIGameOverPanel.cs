using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace Survivor
{
	public class UIGameOverPanelData : UIPanelData
	{
		public string Name;
	}
	public partial class UIGameOverPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameOverPanelData ?? new UIGameOverPanelData();
			// please add init code here
			Title.text = mData.Name;

			ActionKit.OnUpdate.Register(()=> 
			{
				if (Input.GetKeyDown(KeyCode.Space)) 
				{
					CloseSelf();
					SceneManager.LoadScene("SampleScene");
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
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
