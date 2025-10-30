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
	 * Complete the 'timeInWords' function below.
	 *
	 * The function is expected to return a STRING.
	 * The function accepts following parameters:
	 *  1. INTEGER h
	 *  2. INTEGER m
	 */

	// Using simple straight forward solution
	public static string timeInWords(int h, int m)
	{
		// The bags of words option for time words

		string[] numbers = {
			"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
			"eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
			"eighteen", "nineteen", "twenty", "twenty one", "twenty two", "twenty three",
			"twenty four", "twenty five", "twenty six", "twenty seven", "twenty eight", "twenty nine"
		};

		string[] hours = {
			"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
			"eleven", "twelve"
		};

		// Handling familiar\special cases on the clock
		// Special case: on the hour
		if (m == 0)
		{
			return hours[h] + " o' clock";
		}

		// Special case: quarter past
		else if (m == 15)
		{
			return "quarter past " + hours[h];
		}

		// Special case: half past
		else if (m == 30)
		{
			return "half past " + hours[h];
		}

		// Special case: quarter to
		else if (m == 45)
		{
			return "quarter to " + hours[h % 12 + 1];
		}

		// Past cases (1-29 minutes)
		if (m < 30)
		{
			if (m == 1) // special case, because it singular and not plural
			{
				return "one minute past " + hours[h];
			}
			else
			{
				return numbers[m] + " minutes past " + hours[h];
			}
		}

		// For cases of (31-59 minutes)
		int minutesTo = 60 - m;
		if (minutesTo == 1)
		{
			return "one minute to " + hours[h % 12 + 1];
		}
		else
		{
			return numbers[minutesTo] + " minutes to " + hours[h % 12 + 1];
		}

	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int h = Convert.ToInt32(Console.ReadLine().Trim());

		int m = Convert.ToInt32(Console.ReadLine().Trim());

		string result = Result.timeInWords(h, m);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
