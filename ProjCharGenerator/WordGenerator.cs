using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace generator {
	public class WordGenerator : Generator {

		private readonly Dictionary<string, int> weights;
		public WordGenerator(Dictionary<string, int> wordWeights) : base() {
			size = wordWeights.Count;
			weights = new Dictionary<string, int>();
			foreach(var i in wordWeights) {
				sum += i.Value;
				weights.Add(i.Key, sum);
			}
		}
		public override string GetElement() {
			int m = random.Next(0, sum);
			foreach(var i in weights) {
				if (m < i.Value)
					return i.Key;
			}
			return weights.Last().Key;
		}
	}
}
