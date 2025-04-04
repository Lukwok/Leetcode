﻿using System.Text.RegularExpressions;

 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
           this.left = left;
         this.right = right;
     }
  }

public class Solution {
    public IList<int> LargestValues(TreeNode root) {
        List<int> output = new List<int>();

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            //Current Level
            output.Add(FindLargestForeachLevel(queue));

            //Input the Next Level 
            Queue<TreeNode> temp = new Queue<TreeNode>();
            foreach(TreeNode tree in queue)
            {
                if (tree.left != null){temp.Enqueue(tree.left);}
                if (tree.right != null){temp.Enqueue(tree.right);}
            }
            
            queue = temp;
        }
        return output;
    }

    private int FindLargestForeachLevel(Queue<TreeNode> input)
    {
        int maximun = -1;
        foreach(TreeNode tree in input)
        {
            if (tree.val > maximun)
            {
                maximun = tree.val;
            }
        }

        return maximun;
    }

    

    private static int CompareTo(string input, string chars)
    {
        char[] charArr = chars.ToCharArray();
        char[] inputArr = input.ToCharArray();

        //Convert to list
        List<char> charList = charArr.ToList();
        int counter = 0;
        foreach (char inputChar in inputArr){
        int index = charList.FindIndex(i => i == inputChar);
        if (index >= 0)
        {
            charList.RemoveAt(index);
            counter ++;
        }
        else
        {
            return 0;
        }
        }
        return counter;
    }
}

class Program {
    static TreeNode BuildTree(int?[] values) {
        if (values.Length == 0 || values[0] == null) return null;

        TreeNode root = new TreeNode(values[0].Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (i < values.Length) {
            TreeNode current = queue.Dequeue();

            if (values[i] != null) {
                current.left = new TreeNode(values[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            if (i < values.Length && values[i] != null) {
                current.right = new TreeNode(values[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }

    static void Main() {
        int?[] input = {34,-6,null,-21};
        TreeNode root = BuildTree(input);
        Solution solution = new Solution();
        IList<int> result = solution.LargestValues(root);
        
        Console.WriteLine("Largest values in each row: " + string.Join(", ", result));
    }
}