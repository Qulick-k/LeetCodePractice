/*
 * @lc app=leetcode id=104 lang=csharp
 *
 * [104] Maximum Depth of Binary Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int MaxDepth(TreeNode root)
    {
        //DFS版本，深度優先版本
        //root本身的深度在DFS上是不算的，所以在比較左右兩端的深度大小後，需要加上root本身的深度，Math.Max(左邊,右邊) + 1。
        if (root == null) //root為空值，直接回傳深度為0
        {
            return 0;
        }
        int left = MaxDepth(root.left);     //先拜訪左邊的深度，呼叫自己的方法進行遞迴
        int right = MaxDepth(root.right);   //左邊沒得拜訪後，換拜訪右邊的深度，呼叫自己的方法進行遞迴

        return Math.Max(left, right) + 1;   //比較大小完再+1，接著回傳
    }
}
// @lc code=end

/*
BFS版本，廣度優先版本
        //BFS推薦使用佇列queue
        Queue<TreeNode> queue = new Queue<TreeNode>(); //設置一個空queue
        if(root == null) //如果input的root是空值，回傳深度為0
            return 0;
        queue.Enqueue(root); //把input的root加進queue
        int count = 0; //設置深度為0
        while(queue.Count() > 0){ //當queue還沒全部掃描完時
            int size = queue.Count(); //每一輪更新queue的長度給size
            count ++;                 //深度+1
            for(int i = 0; i < size; i++){       //訪問queue內的數值
                TreeNode temp = queue.Dequeue();    //彈出queue內的第一個數值給temp
                if(temp.left != null)   {           //如果temp的左邊不等於空值
                    queue.Enqueue(temp.left);       //左邊的值，排進queue內
                if(temp.right != null)              //如果temp的右邊不等於空值
                    queue.Enqueue(temp.right);      //右邊的值，排進queue內
            }
        }
        return count; //回傳深度

參考
https://www.youtube.com/watch?v=9P01tBgsipw
*/