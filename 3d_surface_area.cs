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
	 * Complete the 'surfaceArea' function below.
	 *
	 * The function is expected to return an INTEGER.
	 * The function accepts 2D_INTEGER_ARRAY A as parameter.
	 */

	// The Idea is to go over the 3D shape and calculate the array according to what is on the surface

	public static int surfaceArea(List<List<int>> A)
	{
		int H = A.Count;      // number of rows
		int W = A[0].Count;   // number of columns
		int totalArea = 0;

		for (int i = 0; i < H; i++) // going over the base grid that on the floor
		{
			for (int j = 0; j < W; j++)
			{
				int height = A[i][j];

				if (height > 0)
				{
					// Add top and bottom faces
					totalArea += 2;
				}
				// Add front face exposed area compared to cell in front
				if (i == 0)
				{
					totalArea += height;
				}
				else // if there are blocks that hiding/blocking the surface neer it
				{
					totalArea += Math.Max(0, height - A[i - 1][j]);
				}

				// Add back face exposed area compared to cell behind
				if (i == H - 1)
				{
					totalArea += height;
				}
				else // if there are blocks that hiding/blocking the surface neer it
				{
					totalArea += Math.Max(0, height - A[i + 1][j]);
				}

				// Add left face exposed area compared to cell on left
				if (j == 0)
				{
					totalArea += height;
				}
				else // if there are blocks that hiding/blocking the surface neer it
				{
					totalArea += Math.Max(0, height - A[i][j - 1]);
				}

				// Add right face exposed area compared to cell on right
				if (j == W - 1)
				{
					totalArea += height;
				}
				else // if there are blocks that hiding/blocking the surface neer it
				{
					totalArea += Math.Max(0, height - A[i][j + 1]);
				}

			}
		}

		return totalArea;
	}
}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

		int H = Convert.ToInt32(firstMultipleInput[0]);

		int W = Convert.ToInt32(firstMultipleInput[1]);

		List<List<int>> A = new List<List<int>>();

		for (int i = 0; i < H; i++)
		{
			A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
		}

		int result = Result.surfaceArea(A);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
