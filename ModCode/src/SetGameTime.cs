using System.Reflection;
using UnityEngine;
using Game;
using Missions;
using Missions.Nodes.Sequenced;
using Networking;

namespace KribensisIncursion
{
    [NodeWidth(200)]
	public class SetGameTime : SequencedNode
	{
		public override bool Execute(IMissionGame gameControl)
		{
			Debug.Log("Executing SetGameTime");

			//SkirmishGameManager.HandleTimeHackMessage({GameTime});

			TimeHackMessage timeHack = new TimeHackMessage();
			timeHack.TimeLimit = GameTime * 60;

			MethodInfo method = SkirmishGameManager.Instance.GetType().GetMethod("HandleTimeHackMessage", BindingFlags.NonPublic | BindingFlags.Instance);
			method.Invoke(SkirmishGameManager.Instance, new object[] { timeHack });

			return true;
		}

		[SerializeField]
		public int GameTime;
	}
}
