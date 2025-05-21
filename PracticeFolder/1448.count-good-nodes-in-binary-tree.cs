/*
 * @lc app=leetcode id=1448 lang=csharp
 *
 * [1448] Count Good Nodes in Binary Tree
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
    /*
    68% 67%
    把root分成三個部分，root節點本身、root左方節點、root右方節點
    利用DFS拜訪二元樹的左方節點和右方節點
    root本身大於等於最大值，就更新Good次數
    接著把root左方節點、當前最大值作為參數，Good次數作為引數，放進自身Method進行遞迴，繼續更新Good次數
    最後把root右方節點、當前最大值作為參數，Good次數作為引數，放進自身Method進行遞迴，繼續更新Good次數
    最後回傳Good次數
    */
    int result = 0;
    public int GoodNodes(TreeNode root)
    {
       Traverse(root, root.val, ref result);
       return result;
    }

    public void Traverse(TreeNode root, int tempMax, ref int Count)
    {
        if (root == null)
        {
            return;
        }
        if (root.val >= tempMax)
        {
            tempMax = root.val;
            Count++;
        }
        Traverse(root.left, tempMax, ref Count);
        Traverse(root.right, tempMax, ref Count);
    }
}
// @lc code=end

/*
ref
https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/ref
*/