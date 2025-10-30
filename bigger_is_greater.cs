using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

	/*
	 * Complete the 'biggerIsGreater' function below.
	 *
	 * The function is expected to return a STRING.
	 * The function accepts STRING w as parameter.
	 */

	// The conditions we need to create such like the next word in the dictoianry , form the words characters
	public static string biggerIsGreater(string w)
	{
		// turning the string into char array, so it more convinet for checking and swapping
		char[] chars = w.ToCharArray();
		int n = chars.Length;

		// we'll run backward to try doing the changes as much as can in the end of the word

		// Find the rightmost character which is smaller than its next character
		int pivot = -1;
		for (int i = n - 2; i >= 0; i--) // starting from n - 2, because of the condition
		{
			if (chars[i] < chars[i + 1])
			{
				pivot = i;
				break;
			}
		}
		// handiling if no greater permutation is possible
		if (pivot == -1)
		{
			return "no answer";
		}

		// Find the smallest character on right side of pivot that is greater than pivot
		// because we need to swap only 2 chars to create a bigger minumu string
		int successor = -1;
		for (int i = n - 1; i > pivot; i--)
		{
			if (chars[i] > chars[pivot]) // need to be big than the first pivot to make the string bigger
			{
				successor = i;
				break;
			}
		}
		// Swapping pivot and successor
		char temp = chars[pivot];
		chars[pivot] = chars[successor];
		chars[successor] = temp;

		//Reverse the substring after pivot - reverse everything after the pivot position to get the smallest lexicographic arrangement
		Array.Reverse(chars, pivot + 1, n - pivot - 1);
		return new string(chars);
	}

}


class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int T = Convert.ToInt32(Console.ReadLine().Trim());

		for (int TItr = 0; TItr < T; TItr++)
		{
			string w = Console.ReadLine();

			string result = Result.biggerIsGreater(w);

			textWriter.WriteLine(result);
		}

		textWriter.Flush();
		textWriter.Close();
	}
}
