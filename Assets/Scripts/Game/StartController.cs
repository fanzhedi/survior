using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class StartController : ViewController
	{
		void Awake()
		{
			ResKit.Init();
		}
		void Start()
		{
			// Code Here
			UIKit.OpenPanel<UIGameStart>();
		}

		void OnDestroy()
		{
			UIKit.ClosePanel<UIGameStart>();
		}
	}
}
