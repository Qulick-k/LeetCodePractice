/*
 * @lc app=leetcode id=1372 lang=csharp
 *
 * [1372] Longest ZigZag Path in a Binary Tree
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
    //59% 67%
    /*
    設置一個方法，參數為root、布林值isLeft、當前值current
    如果root是null，回傳current
    
    接著有兩種選擇：
    節點繼續沿著先前的Ｚ字形方向（如果上一層是向右，則向左；否則向右）並增加計數。
    節點繼續沿著相反的方向（也就是無法形成Ｚ字形，如果先前是向右，則向右；否則向左）並將計數重置。
    然後從這兩種選項中選擇最大的數值。
    */
    public int LongestZigZag(TreeNode root)
    {        
        return Math.Max(PathSum(root.left, true, 0), PathSum(root.right, false, 0)); //true是左邊，false是右邊
    }
    
    public int PathSum(TreeNode root, bool isLeft, int current)
    {
        if(root == null)return current;
        
        if(isLeft == true) //當前節點如果是上一層節點的左方
        {   
            //而下一個左邊的節點，就重置current為0。相反，下一個右邊的節點，current繼續+1
            //之後比大小，最大的留下，回傳給上一層的遞迴
            return Math.Max(PathSum(root.left, true, 0), PathSum(root.right, false, current+1));
        }

        //當前節點如果是上一層節點的右方
        //而下一個左邊的節點，就current+1。相反，下一個右邊的節點，重置為0
        //之後比大小，最大的留下，回傳給上一層的遞迴
        return Math.Max(PathSum(root.left, true, current+1), PathSum(root.right, false, 0));  
    }
}
// @lc code=end

