using System;
using LindenmayerSystem;
namespace LindenmayerSystemTest
{
	public class SierpinskiTriangleGenerator
	{
		LindenmayerSystem<char> _lsystem;
		
		public SierpinskiTriangleGenerator ()
		{
			InitializeLindenmayerSystem();
		}
		
		private void InitializeLindenmayerSystem()
		{
			char[] initiator = new char[1] { 'A' };
			
			LindenmayerRuleCollection<char> rules = new LindenmayerRuleCollection<char>();
			rules.AddRule('A', "B-A-B".ToCharArray());
			rules.AddRule('B', "A+B+A".ToCharArray());
			
			_lsystem = new LindenmayerSystem<char>(initiator, rules);
		}
		
		public char[] CurrentState()
		{
			return _lsystem.State;
		}
		
		public char[] NextGeneration()
		{
			_lsystem.Next();
			return CurrentState();
		}
		
		public override string ToString()
		{
			return new string(CurrentState());
		}
	}
}

