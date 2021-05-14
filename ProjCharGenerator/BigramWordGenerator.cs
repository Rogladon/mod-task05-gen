using System;
using System.Collections.Generic;
using System.Text;

namespace generator {
	public class BigramWordGenerator : WordGenerator {
		
		public BigramWordGenerator(Dictionary<string, int> wordWeights) : base(wordWeights) {

		}
	}
}
