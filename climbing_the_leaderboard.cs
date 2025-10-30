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
	 * Complete the 'climbingLeaderboard' function below.
	 *
	 * The function is expected to return an INTEGER_ARRAY.
	 * The function accepts following parameters:
	 *  1. INTEGER_ARRAY ranked
	 *  2. INTEGER_ARRAY player
	 */

	public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
	{
		// Get distinct scores (dense ranking - ties have same rank) -- removing duplicates
		List<int> distinctRanks = ranked.Distinct().ToList();
		List<int> result = new List<int>();
		int index = distinctRanks.Count - 1; // Start from the lowest rank, Count gives the size

		// Process each player score that are in ascending order
		foreach (int score in player)
		{
			// Move up the leaderboard while player's score is higher or equal -- finding the right pace for him
			while (index >= 0 && score >= distinctRanks[index])
			{
				index--; // using index for the result
			}

			// Player's rank is index + 2
			// handling index + 1 for 0-based indexing, +1 more because we're below the indexed score
			result.Add(index + 2);
		}

		return result;


	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

		List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

		int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

		List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

		List<int> result = Result.climbingLeaderboard(ranked, player);

		textWriter.WriteLine(String.Join("\n", result));

		textWriter.Flush();
		textWriter.Close();
	}
}
