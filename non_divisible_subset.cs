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
	 * Complete the 'nonDivisibleSubset' function below.
	 *
	 * The function is expected to return an INTEGER.
	 * The function accepts following parameters:
	 *  1. INTEGER k
	 *  2. INTEGER_ARRAY s
	 */

	public static int nonDivisibleSubset(int k, List<int> s)
	{
		// Count frequency of each remainder when divided by k
		int[] remainderCount = new int[k]; // biggest reminder can be (k-1)

		foreach (int num in s)
		{
			remainderCount[num % k]++;
		}

		int maxSubsetSize = 0;

		// handling the first cell in reminder's array
		// For remainder 0: can include at most 1 element
		// (because 0 + 0 = 0, which is divisible by k)
		if (remainderCount[0] > 0)
		{
			maxSubsetSize += 1;
		}

		// counting the subarrays that none are divisible with k

		// We can only choose elements from one group
		for (int i = 1; i <= k / 2; i++)
		{
			if (i != k - i)
			{
				// Take the maximum of the two complementary remainders
				maxSubsetSize += Math.Max(remainderCount[i], remainderCount[k - i]);
			}
			else
			{
				// When k is even and i = k/2, we can only take 1 element
				// k/2 + k/2 = k, which is divisible by k
				maxSubsetSize += 1;
			}
		}

		return maxSubsetSize;


	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

		int n = Convert.ToInt32(firstMultipleInput[0]);

		int k = Convert.ToInt32(firstMultipleInput[1]);

		List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

		int result = Result.nonDivisibleSubset(k, s);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
