using System;
using System.Collections.Generic;

namespace ArrayChar
{
	public class MainClass
	{
		/* Find first character which is not repetitve in string
		 * if string has length n, it may need n*n time O(n).
		 * Let's find a better algorithm
		 * First, make Hash table that saves the number of character appears in string
		 * 	for each char
		 * 		if, not saved value for the char, save 1
		 * 		else, value++;
		 * Second, lookup character
		 *  for each char
		 *  	if, the number of appears = 1, return char
		 *      else, 1 not exists, return null
		 */

		public static char FindFirstChar(String str)
		{
			Dictionary<char,int> table = new Dictionary<char, int>();
			int length = str.Length;
			char c;
			int i;
			for (i = 0; i< length; i++)
			{
				c = str[i];
				if (table.ContainsKey (c)) {
					int temp = table [c];
					table.Remove (c);
					table.Add (c, temp+1);
				} else {
					table.Add (c, 1);
				}
			}
			for ( i = 0; i<length; i++)
			{
				c = str[i];
				if (table [c] == 1) {
					return c;
				}
			}
			char Null = '\0';
			return Null;
		}
		public static void Main (string[] args)
		{
	
			Console.WriteLine (FindFirstChar ("FindFirstCharand"));

		}
	}
}
