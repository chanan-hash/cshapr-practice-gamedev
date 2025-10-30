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
	 * Complete the 'organizingContainers' function below.
	 *
	 * The function is expected to return a STRING.
	 * The function accepts 2D_INTEGER_ARRAY container as parameter.
	 */

	// simple counting of the values of rows and columns solution
	public static string organizingContainers(List<List<int>> container)
	{
		int n = container.Count; //size of the big container

		// Calculate total capacity of each container (row sums)
		List<long> containerCapacity = new List<long>();
		for (int i = 0; i < n; i++)
		{
			long sum = 0;
			for (int j = 0; j < n; j++)
			{
				sum += container[i][j];
			}
			containerCapacity.Add(sum);
		}

		// Calculate total count of each ball type (column sums)
		List<long> ballTypeCount = new List<long>();
		for (int j = 0; j < n; j++)
		{
			long sum = 0;
			for (int i = 0; i < n; i++)
			{
				sum += container[i][j];
			}
			ballTypeCount.Add(sum);
		}

		// Sort both lists
		containerCapacity.Sort();
		ballTypeCount.Sort();

		// Check if they match
		for (int i = 0; i < n; i++)
		{
			if (containerCapacity[i] != ballTypeCount[i])
			{
				return "Impossible";
			}
		}

		return "Possible";

	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int q = Convert.ToInt32(Console.ReadLine().Trim());

		for (int qItr = 0; qItr < q; qItr++)
		{
			int n = Convert.ToInt32(Console.ReadLine().Trim());

			List<List<int>> container = new List<List<int>>();

			for (int i = 0; i < n; i++)
			{
				container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
			}

			string result = Result.organizingContainers(container);

			textWriter.WriteLine(result);
		}

		textWriter.Flush();
		textWriter.Close();
	}
}
