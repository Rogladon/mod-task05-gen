using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace generator.utilits {
	public static class Utilits {
		public static void SetStandartFileWordsWeights(string path) {
			StreamReader streamReader = new StreamReader(path);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			string[] textsArray = text.Split('\n');
			for(int i = 0; i< textsArray.Length; i++) {
				string word = GetWords(textsArray[i]);
				string digit = GetInt(textsArray[i]);
				textsArray[i] = word + " " + digit;
			}
			StreamWriter streamWriter = new StreamWriter(path);
			foreach(var i in textsArray) {
				streamWriter.WriteLine(i);
			}
			streamWriter.Close();
		}
		public static Dictionary<string, int> GetDictionaryStringInt(string path) {
			StreamReader stream = new StreamReader(path);
			string text = stream.ReadToEnd();
			string[] strArray = text.Split('\n');
			Dictionary<string, int> dict = new Dictionary<string, int>();
			foreach(var i in strArray) {
				string words = GetWords(i);
				string digit = GetInt(i);
				if(words != "" && digit != "")
					dict.Add(words, int.Parse(digit));
			}
			return dict;
		}
		public static int[,] GetWeights(string path) {
			
			StreamReader stream = new StreamReader(path);
			string text = stream.ReadToEnd();
			string[] strArray = text.Split('\n');
			int[,] weight = new int[strArray.Length, strArray.Length];
			
			for(int i = 0; i < strArray.Length; i++) {
				string d = "";
				int x = i;
				int y = 0;
				bool write = false;
				foreach (var c in strArray[i]) {
					if (IsDigit(c) && !write)
						write = true;
					if (!IsDigit(c) && write)
						write = false;
					if (write)
						d += c;
					else {
						weight[x, y] = int.Parse(d);
						y++;
						d = "";
					}
				}
			}
			return weight;
		} 
		private static string DeleteSpace(string str) {
			str = str.Replace("\t", "");
			Regex regex = new Regex(@"\w");
			for(int i = 0; i< str.Length; i++) {
				if (regex.IsMatch(str[i].ToString()))
					break;
				str = str.Remove(i, 1);
			}
			for (int i = str.Length-1; i >=0; i--) {
				if (regex.IsMatch(str[i].ToString()))
					break;
				str = str.Remove(i, 1);
			}
			return str;
		}
		private static string Invert(string str) {
			string result = "";
			for(int i = str.Length-1; i >= 0; i--) {
				result += str[i];
			}
			return result;
		}
		private static string GetInt(string str) {
			bool write = false;
			string result = "";
			for (int c = str.Length - 1; c >= 0; c--) {
				if (IsDigit(str[c]) && !write)
					write = true;
				if (!IsDigit(str[c]) && write)
					break;
				if (write)
					result += str[c];
			}
			return Invert(DeleteSpace(result));
		}
		private static string GetWords(string str) {
			string result = "";
			bool write = false;
			foreach (var c in str) {
				if (IsAlpha(c) && !write)
					write = true;
				if (IsDigit(c) && write)
					break;
				if (write)
					result += c;
			}
			return DeleteSpace(result);
		}
		private static bool IsAlpha(char ch) {
			Regex isAlpha = new Regex(@"\w");
			Regex isDigit = new Regex(@"\d");
			if (isAlpha.IsMatch(ch.ToString()) && !isDigit.IsMatch(ch.ToString()))
				return true;
			return false;
		}
		private static bool IsDigit(char ch) {
			Regex isDigit = new Regex(@"\d");
			if (isDigit.IsMatch(ch.ToString()))
				return true;
			return false;
		}
	}
}
