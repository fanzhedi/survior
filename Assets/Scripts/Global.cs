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
		public static BindableProperty<float> ExpPercent = new(0.2f);

		/// <summary>
		/// 金币掉落概率
		/// </summary>
		/// <returns></returns>
		public static BindableProperty<float> GoldPercent = new(0.2f);


		[RuntimeInitializeOnLoadMethod]
		public static void AutoInit()
		{
			Coin.Value = PlayerPrefs.GetInt("coin", 0);
			Coin.Register(coin=>{
				PlayerPrefs.SetInt(nameof(coin), coin);
			});

			// ExpPercent.Value = PlayerPrefs.GetFloat(nameof(ExpPercent), 0.5f);
			ExpPercent.Value = 0.5f;
			ExpPercent.Register(expPercent=>{
				PlayerPrefs.SetFloat(nameof(ExpPercent), expPercent);
			});

			// GoldPercent.Value = PlayerPrefs.GetFloat(nameof(GoldPercent), 0.5f);
			GoldPercent.Value = 0.5f;
			GoldPercent.Register(goldPercent=>{
				PlayerPrefs.SetFloat(nameof(GoldPercent), goldPercent);
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

		public static void GeneratePowerUp(GameObject gameobject)
		{
			//掉落经验
			var percent = Random.Range(0, 1f);

			if (percent < ExpPercent.Value) 
			{
				Debug.Log("经验概率"+ExpPercent.Value+"     随机数" + percent + "   生成经验球");
				PowerUpManager.Default.Exp.Instantiate().Position(gameobject.Position()).Show();
			} 
			else 
			{
				percent = Random.Range(0, 1f);
				if (percent < GoldPercent.Value) 
				{
					Debug.Log("随机数" + percent + "   生成金币球");
					PowerUpManager.Default.Coin.Instantiate().Position(gameobject.Position()).Show();
				}
			}
		}

	}
}

