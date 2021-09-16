//Task 4 

//You are keeping score for a baseball game with strange rules. The game consists of several rounds, where the scores of past rounds may affect future rounds’ scores.  
//At the beginning of the game, you start with an empty record. You are given a list of string ops, where  ops[i] is the ith operation you must apply to the record and is one of the following:  0.An integer x – Record a new score of x. 0. “+” – Record a new score that is the sum of previous two  scores. It is guaranteed there will be a previous score. 0. “D” – Record a new score that is double the  previous score.It is guaranteed there will always be a previous score. 0. “C” – Invalidate the previous score, removing it from the record.It is guaranteed there will always be a previous score.  Return the sum of all the scores on the record.  


//Example 1:  
//Input: ops = [“5”, “2”, “C”, “D”, “+”]
//Output: 30  
//Example 2:  
//Input: ops = [“5”, “-2”, “4”, “C”, “D”, “9”, “+”, “+”]
//Output: 27  
//Example 3:  
//Input ops = [“1”]
//Output: 1  

using System;
using System.Collections.Generic;

public class BaseBallGame
{
    public int CountPoints(string[] ops)
    {
        Stack<int> stack = new Stack<int>();
        foreach (string item in ops)
        {
            if (item.Equals("+"))
            {
                int top = stack.Pop();
                int newTop = top + stack.Peek();
                stack.Push(top);
                stack.Push(newTop);
            }
            else if (item.Equals("C"))
            {
                stack.Pop();
            }
            else if (item.Equals("D"))
            {
                stack.Push(2 * stack.Peek());
            }
            else
            {
                stack.Push(Convert.ToInt32(item));
            }
        }

        int final = 0;

        foreach (int item in stack)
        {
            final += item;
        }

        return final;

    }



}



