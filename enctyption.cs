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
	 * Complete the 'encryption' function below.
	 *
	 * The function is expected to return a STRING.
	 * The function accepts STRING s as parameter.
	 */

	public static string encryption(string s)
	{
// Remove spaces
		string text = s.Replace(" ", "");
		int L = text.Length; // calculating length


		if (L == 0) {
			return "";   // handling edge case
		}

		// Calculate floor and ceiling of sqrt(L). for rows and columns
		int f = (int)Math.Floor(Math.Sqrt(L));
		int c = (int)Math.Ceiling(Math.Sqrt(L));

		int rows, cols;

		// Find minimum area grid that satisfies constraints, so the string will be suit for encryption
		if (f * f >= L)
		{
			rows = f;
			cols = f;
		}
		else if (f * c >= L)
		{
			rows = f;
			cols = c;
		}
		else
		{
			rows = c;
			cols = c;
		}

		// Build the encrypted string by reading columns
		List<string> columns = new List<string>();

		// The idea is building only the columns list, and not the whole matrix, so we can save memory,
		// and by the loop go over the string (beacuse this is a line\row)
		for (int col = 0; col < cols; col++)
		{
			string column = "";
			for (int row = 0; row < rows; row++)
			{
				int index = row * cols + col;
				if (index < L)
				{
					column += text[index];
				}
			}
			columns.Add(column);
		}

		return string.Join(" ", columns); // turning the column list into string
	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string s = Console.ReadLine();

		string result = Result.encryption(s);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
