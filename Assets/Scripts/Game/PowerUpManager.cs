using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class PowerUpManager : ViewController
	{
		public static PowerUpManager Default;

		void Awake()
		{

		}
		void Start()
		{
			Default = this;
			// Code Here
		}

		void OnDestroy()
		{
			Default = null;
		}
	}
}
