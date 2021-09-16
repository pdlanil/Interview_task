//# Task 2
//Given an integer array arr, count how many elements x there are, such that x+1 is also an arr. If there’re  Duplicates in arr, count then separately.  

//Example 1:  
//Input: arr = [1, 2, 3]
//Output: 2


//Example 2:  
//Input: arr = [1, 1, 3, 3, 5, 5, 7, 7]
//Output: 0
//Example 3:  
//Input: arr = [1, 3, 2, 3, 5, 0]
//Output: 3
//Example 4:  
//Input: arr = [1, 1, 2, 2]
//Output: 2
//Example 5:  
//Input: arr =[1, 1, 2]
//Output: 2


using System;

public class ArraySolve
{

    static void LenCount(string[] args)
    {
        int[] intArray = new int[] { 1, 1, 2 };
        //int[] intArray = new int[] { 1, 1, 3, 3, 5, 5, 7, 7 };
        //int[] intArray = new int[] { 1, 3, 2, 3, 5, 0 };
        //int[] intArray = new int[] { 1, 1, 2, 2 };
        //int[] intArray = new int[] { 1, 2, 3 };

        int answer = 0;
        for (int i = 0; i < intArray.Length; i++)
        {
            int current = intArray[i];
            for (int j = 0; j < intArray.Length; j++)
            {
                if (i != j)
                {
                    if (current + 1 == intArray[j])
                    {
                        answer++;
                        break;

                    }

                }

            }

        }
        Console.WriteLine(answer);
    }
}

