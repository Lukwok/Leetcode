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

public class Largest_Tree_Node {
       public IList<int> LargestValues(TreeNode root) {
        List<int> output = new List<int>();
        if (root == null) return output;

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
        int maximun = input.FirstOrDefault().val;
        foreach(TreeNode tree in input)
        {
            if (tree.val > maximun)
            {
                maximun = tree.val;
            }
        }

        return maximun;
    }

    }