using UnityEngine;
using QFramework;

namespace Survivor
{
	public partial class Exp : ViewController
	{
		void Start()
		{
			// Code Here
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<CollectableArea>())
			{
				Global.Exp.Value++;
				this.DestroyGameObjGracefully();
			}
		}
	}
}
