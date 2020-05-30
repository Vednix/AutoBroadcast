using Newtonsoft.Json;
using System.IO;

namespace AutoBroadcast
{
	public class ABConfig
	{
		public Broadcast[] Broadcasts = new Broadcast[0];

		public ABConfig Write(string file)
		{
			File.WriteAllText(file, JsonConvert.SerializeObject(this, Formatting.Indented));
			return this;
		}

		public static ABConfig Read(string file)
		{
			if (!File.Exists(file))
			{
				WriteExample(file);
			}
			return JsonConvert.DeserializeObject<ABConfig>(File.ReadAllText(file));
		}

		public static void WriteExample(string file)
		{
			var Ex = new Broadcast()
			{
				Name = "Broadcast de Exemplo",
				Enabled = false,
				Messages = new string[]
				{
					"Essa é uma mensagem Broadcast de exemplo",
					"Será mostrada automaticamente a cada 5 minutos",
					"Também podem ser executados comandos",
					"/time noon"
				},
				ColorRGB = new float[] { 255f, 0f, 0f },
				Interval = 300,
				StartDelay = 60
			};
			var Conf = new ABConfig()
			{
				Broadcasts = new Broadcast[] { Ex }
			};
			Conf.Write(file);
		}
	}

	public class Broadcast
	{
		public string Name = string.Empty;
		public bool Enabled = false;
		public string[] Messages = new string[0];
		public float[] ColorRGB = new float[3];
		public int Interval = 0;
		public int StartDelay = 0;
		public string[] TriggerRegions = new string[0];
		public string RegionTrigger = "none";
		public string[] Groups = new string[0];
		public string[] TriggerWords = new string[0];
		public bool TriggerToWholeGroup = false;
	}
}
