using System;
using System.Collections.Generic;
using System.Collections;

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

		public static char FindFirstChar(string str)
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
		/* better algorithm
		 * there are three status ; not seen, seen once and seen multiple
		 */
		public static string FindFirstChar2 (String str)
		{
			Dictionary<int, object> table = new Dictionary<int, object> ();
			object SeenOnce = new object ();
			object SeenMulti = new object ();
			object Seen;

			int length = str.Length;
			object value;
			/*
			for (i = 0; i < length;) {
				int cp = (int)str[i];
				i = i+ 
	//			c = str [i];
			}
			*/
			//string input = "가나다라가나다라abcd";
			for(int i = 0 ; i <length ; )
			{
				int cp = Char.ConvertToUtf32(str, i);
				i += Char.IsSurrogatePair (str, i) ? 2 : 1;
				Console.WriteLine("U+{0:X4}", cp);
			    table.TryGetValue(cp, out value);
				Seen = value;
				if (Seen == null) {
					table.Add (cp, SeenOnce);
					Console.WriteLine ("fail");
				} else {
					if (Seen.Equals( SeenOnce)) {
						table.Remove (cp);
						table.Add(cp, SeenMulti);
						Console.WriteLine ("success");
					}
				}
					
//				Console.WriteLine(table[0]);
				//String s =  table[cp].ToString();

				//Console.WriteLine (Seen);
			}
			for (int i=0; i< length;) 
			{
				int cp = Char.ConvertToUtf32(str, i);
				i += Char.IsSurrogatePair (str, i) ? 2 : 1;
				if( SeenOnce.Equals( table[cp]))
					{
						return Char.ConvertFromUtf32(cp);
					}
			}
			return null;
	

		}

		public static void Main (string[] args)
		{
	
			Console.WriteLine (FindFirstChar ("가나다라가나다라abcd"));
			Console.WriteLine (FindFirstChar2 ("가나다라가나다라abcd"));
		}
	}
}
