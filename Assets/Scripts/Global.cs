using QFramework;

namespace Survivor
{ 
	public class Global
	{
		/// <summary>
		/// 经验值
		/// </summary>
		public static BindableProperty<int> Exp = new(0);

		public static BindableProperty<int> Level = new(0);
	}
}

