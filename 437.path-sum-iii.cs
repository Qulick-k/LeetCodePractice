/*
 * @lc app=leetcode id=437 lang=csharp
 *
 * [437] Path Sum III
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
     Brute Force: O(nlogn) ~ O(n^2) 暴力DFS破解法 17% 83%
    分成兩種遞迴，第一種是PathSum自身，第二種當前root階層的下一個階層Traverse自身
    第一層深度優先搜尋 (DFS): 使用遞迴遍歷來走訪每個節點（可以是任何順序：前序、中序、後序皆可）。
    第二層深度優先搜尋: 對於每個節點，走訪所有路徑。如果路徑總和等於目標值，則Current++。
    回傳結果: 返回數量。
    */
    public int PathSum(TreeNode root, int targetSum)
    {
        if (root == null)
        {
            return 0;
        }
        
        return Traverse(root, targetSum) + PathSum(root.left, targetSum) + PathSum(root.right, targetSum);
    }

    public int Traverse(TreeNode root,long target)
    {
        if (root == null)
        {
            return 0;
        }
        else
        {
            int current = 0;
            if (root.val == target)
            {
                current++;
            }
            return current + Traverse(root.left, target - root.val) + Traverse(root.right, target - root.val);
        }
        
    }
}
// @lc code=end

/*
long	-9,223,372,036,854,775,808 至 9,223,372,036,854,775,807	帶正負號的 64 位元整數
https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
^ 異或
https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/boolean-logical-operators
*/
/*
Memorization of path sum: O(n)版本
https://youtu.be/3UaqfofZGVM?si=_YZZGgKs3lqaJQLG
這個方法使用了字典 prefixSumCount 來記錄在二元樹中不同節點到根節點的前綴和，以及它們出現的次數。接著遞迴遍歷二元樹，計算在每個節點處的前綴和，檢查是否存在一個前綴和，使得 currentSum - targetSum 等於該前綴和，如果存在，則表示存在一條路徑滿足目標。最後將這些路徑的數量相加即為最終結果。

public class Solution {
    public int PathSum(TreeNode root, int targetSum)
    {
        Dictionary<int, int> prefixSumCount = new Dictionary<int, int>();
        prefixSumCount[0] = 1;

        return CountPaths(root, 0, targetSum, prefixSumCount);
    }

    private int CountPaths(TreeNode node, int lastSum, int targetSum, Dictionary<int, int> prefixSumCount)
    {
        if (node == null)
        {
            return 0;
        }

        var currentSum = lastSum + node.val;

        if((lastSum ^ currentSum) < 0 && (node.val ^ currentSum) < 0)
        {
            return 0;
        }
        
        int pathCount = prefixSumCount.GetValueOrDefault(currentSum - targetSum, 0);

        prefixSumCount[currentSum] = prefixSumCount.GetValueOrDefault(currentSum, 0) + 1;

        int leftPaths = CountPaths(node.left, , targetSum, prefixSumCount);
        int rightPaths = CountPaths(node.right, currentSum, targetSum, prefixSumCount);

        prefixSumCount[currentSum] -= 1;

        return pathCount + leftPaths + rightPaths;
    }
}
*/