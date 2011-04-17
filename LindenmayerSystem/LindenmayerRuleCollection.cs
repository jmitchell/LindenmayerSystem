using System;
using System.Collections.Generic;
namespace LindenmayerSystem
{
	public class LindenmayerRuleCollection<T> where T : IEquatable<T>
	{
		protected Dictionary<T, T[]> _rules;
		
		public LindenmayerRuleCollection()
		{
			_rules = new Dictionary<T, T[]>();
		}
		
		public LindenmayerRuleCollection(Dictionary<T, T[]> rules)
		{
			_rules = rules;	
		}
		
		public bool HasRuleFor(T predecessor)
		{
			return _rules.ContainsKey(predecessor);	
		}
		
		public void AddRule(T predecessor, T[] successors)
		{
			if (HasRuleFor(predecessor))
				throw new ArgumentException("Rule already exists for that domain!", "predecessor");
			_rules.Add(predecessor, successors);
		}
		
		public void RemoveRule(T predecessor)
		{
			if (!HasRuleFor(predecessor))
				throw new ArgumentException("Cannot delete non-existent rule!", "predecessor");
			_rules.Remove(predecessor);
		}
		
		public T[] RuleFor(T predecessor)
		{
			if (HasRuleFor(predecessor))
				return _rules[predecessor];
			return new T[] { predecessor };
		}
		
		public T[] ApplyRules(T[] state)
		{
			List<T> result = new List<T>();
			foreach (T atom in state)
				result.AddRange(RuleFor(atom));
			return AsArray(result);
		}
		
		private T[] AsArray(List<T> list)
		{
			T[] array = new T[list.Count];
			for (int i = 0; i < list.Count; i++)
				array[i] = list[i];
			return array;
		}
	}
}

