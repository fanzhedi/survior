using QFramework;
using UnityEngine;

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

		/// <summary>
		/// 金币
		/// </summary>
		/// <returns></returns>
		public static BindableProperty<int> Coin = new(0);

		/// <summary>
		/// 经验掉落概率
		/// </summary>
		public static BindableProperty<float> ExpPerect = new(0.5f);

		/// <summary>
		/// 金币掉落概率
		/// </summary>
		/// <returns></returns>
		public static BindableProperty<float> GoldPerect = new(0.2f);


		[RuntimeInitializeOnLoadMethod]
		public static void AutoInit()
		{
			Coin.Value = PlayerPrefs.GetInt("coin", 0);

			Coin.Register(coin=>{
				PlayerPrefs.SetInt(nameof(coin), coin);
			});

			ExpPerect.Value = PlayerPrefs.GetFloat(nameof(ExpPerect), 0.5f);
			ExpPerect.Register(expPerect=>{
				PlayerPrefs.SetFloat(nameof(ExpPerect), expPerect);
			});

			GoldPerect.Value = PlayerPrefs.GetFloat(nameof(GoldPerect), 0.2f);
			GoldPerect.Register(goldPerect=>{
				PlayerPrefs.SetFloat(nameof(GoldPerect), goldPerect);
			});
		}
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

