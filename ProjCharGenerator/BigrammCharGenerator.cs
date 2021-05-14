using System;
using System.Collections.Generic;
using System.Text;

namespace generator {
	public class BigrammCharGenerator : Generator {
		protected readonly string chars = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
		protected readonly char[] charData;
		private int[,] weights;
		public BigrammCharGenerator(int[,] bigrammChars) :base() {
			charData = chars.ToCharArray();
			size = bigrammChars.GetLength(0);
			weights = new int[size, size];
			for(int x = 0; x < size; x++) {
				for(int y = 0; y < size; y++) {
					sum += bigrammChars[x, y];
					weights[x, y] = sum;
				}
			}
		}
		public override string GetElement() {
			int m = random.Next(0, sum);
			for(int x = 0; x < size; x++) {
				for(int y = 0; y < size; y++) {
					if (m < weights[x, y])
						return $"{charData[x]}{charData[y]}";
				}
			}
			return $"{charData[charData.Length-1]}{charData[charData.Length-1]}";
		}
	}
}
