using System;
using System.Collections.Generic;
using System.Text;

namespace generator {
	public abstract class Generator {
		
		protected readonly Random random;
		protected int sum = 0;
		
		public int size { get; protected set; }
		public Generator() {
			random = new Random();
		}

		public abstract string GetElement();
		public string GetText(int size) {
			string result = "";
			for (int i = 0; i < size; i++) {
				result += $"{GetElement()} ";
			}
			return result;
		}
	}
}
