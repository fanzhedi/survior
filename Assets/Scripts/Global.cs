using QFramework;

namespace Survivor
{ 
	public class Global
	{
		/// <summary>
		/// 经验值
		/// </summary>
		public static BindableProperty<int> Exp = new(0);

		/// <summary>
		/// 等级
		/// </summary>
		/// <returns></returns>
		public static BindableProperty<int> Level = new(1);

		/// <summary>
		/// 基础能力的攻击力
		/// </summary>
		/// <returns></returns>
		public static BindableProperty<float> SimpleAbilityDmage = new(1.0f);

		/// <summary>
		/// 基础能力的攻击间隔
		/// </summary>
		/// <returns></returns>
		public static BindableProperty<float> SimpleAbilityDuration = new(1.5f);

		/// <summary>
		/// 系统时间
		/// </summary>
		public static BindableProperty<float> CurrentSeconds = new(0f);

		public static void Reset() 
		{
			Exp.Value = 0;
			Level.Value = 1;
			CurrentSeconds.Value = 0;
			SimpleAbilityDmage.Value = 1;
			SimpleAbilityDuration.Value = 1.5f;

			EnemyGenerator.EnemyCount.Value = 0;
		}

		public static int LevelUpExp()
		{
			return Level.Value * 5;
		}

	}
}

