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
	 * Complete the 'gridSearch' function below.
	 *
	 * The function is expected to return a STRING.
	 * The function accepts following parameters:
	 *  1. STRING_ARRAY G
	 *  2. STRING_ARRAY P
	 */

	// Searching in straight forward if the pattern in the grind
	public static string gridSearch(List<string> G, List<string> P)
	{

		// Getting sizes of
		int R = G.Count;      // rows in large grid
		int C = G[0].Length;  // columns in large grid
		int r = P.Count;      // rows in pattern
		int c = P[0].Length;  // columns in pattern


		// Try each possible starting position in the large grid, to find if the pattern can be started
		for (int i = 0; i <= R - r; i++)
		{
			for (int j = 0; j <= C - c; j++) {
				// Check if pattern matches starting at position (i, j)
				bool found = true; // assuming we have the pattern found, if not will move to the next iteraition, meaning the next char to check for the pattern

				for (int pi = 0; pi < r; pi++)
				{
					for (int pj = 0; pj < c; pj++)
					{
						if (G[i + pi][j + pj] != P[pi][pj]) // to match the indexes
						{
							found = false;
							break; // so we'll be able to move to the next iteration
						}
					}
					if (!found) break; // so we'll be able to move to the next iteration
				}

				if (found)
				{
					return "YES";
				}
			}
		}

		return "NO";
	}


}


class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int t = Convert.ToInt32(Console.ReadLine().Trim());

		for (int tItr = 0; tItr < t; tItr++)
		{
			string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

			int R = Convert.ToInt32(firstMultipleInput[0]);

			int C = Convert.ToInt32(firstMultipleInput[1]);

			List<string> G = new List<string>();

			for (int i = 0; i < R; i++)
			{
				string GItem = Console.ReadLine();
				G.Add(GItem);
			}

			string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

			int r = Convert.ToInt32(secondMultipleInput[0]);

			int c = Convert.ToInt32(secondMultipleInput[1]);

			List<string> P = new List<string>();

			for (int i = 0; i < r; i++)
			{
				string PItem = Console.ReadLine();
				P.Add(PItem);
			}

			string result = Result.gridSearch(G, P);

			textWriter.WriteLine(result);
		}

		textWriter.Flush();
		textWriter.Close();
	}
}
