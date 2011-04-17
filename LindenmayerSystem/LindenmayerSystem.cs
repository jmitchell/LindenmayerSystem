using System;
namespace LindenmayerSystem
{
	public class LindenmayerSystem<T> where T : IEquatable<T>
	{
		protected T[] _initiator;
		protected T[] _state;
		protected int _generation;
		protected LindenmayerRuleCollection<T> _rules;
		
		public LindenmayerSystem(T[] initiator, LindenmayerRuleCollection<T> rules)
		{
			_initiator = initiator;
			_rules = rules;
			
			InitializeState();
		}
		
		private void InitializeState()
		{
			_state = (T[])_initiator.Clone();
			_generation = 0;
		}
		
		public T[] Initiator
		{
			get { return _initiator; }	
		}
		
		public LindenmayerRuleCollection<T> Rules
		{
			get { return _rules; }	
		}
		
		public T[] State
		{
			get { return _state; }	
		}
		
		public int Generation
		{
			get { return _generation; }	
		}
		
		public void Next()
		{
			_state = _rules.ApplyRules(_state);
			_generation++;
		}
		
		public void Reset()
		{
			InitializeState();	
		}
	}
}

