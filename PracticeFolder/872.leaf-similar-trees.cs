/*
 * @lc app=leetcode id=872 lang=csharp
 *
 * [872] Leaf-Similar Trees
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
    //判斷兩顆二元樹的葉子節點從左到右的排列是否相同
    /*
    6% 77%
    設置兩個int串列，分別放置兩棵樹的末端葉子
    設置一個方法Traveral，DFS拜訪一棵樹內的所有葉子，
    如果root的左方和右方都是空值，則root的value放進串列內
    如果root的左方或是右方不是空值，則將root的左方或是右方作為參數，呼叫Traversal()去拜訪相對應的葉子
    */        
    List<int> treeList_num1 = new List<int>();
    List<int> treeList_num2 = new List<int>();
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        Traversal(root1, 1);
        Traversal(root2, 2);

        if (treeList_num1.Count() != treeList_num2.Count()) //兩個串列長度不同，回傳false
        {
            return false;
        }
        for (int i = 0; i < treeList_num1.Count(); i++)     //迴圈檢查兩個串列每一個相同索引下的數值，不相同，馬上回傳false
        {
            if (treeList_num1[i] != treeList_num2[i])
            {
                return false;
            }
        }
        return true;    //檢查完，都OK，回傳true
    }
    public void Traversal(TreeNode root, int treeList)
    {
        if (root.left == null && root.right == null)
        {
            if(treeList == 1)
            {
                treeList_num1.Add(root.val);
            }
            else
            {
                treeList_num2.Add(root.val);
            }
        }
        else
        {
            if(root.left != null)
            {
                Traversal(root.left, treeList);
            }
            if(root.right != null)
            {
                Traversal(root.right, treeList);
            }
        }
    }
}
// @lc code=end

