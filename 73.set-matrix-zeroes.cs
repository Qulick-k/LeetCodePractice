/*
 * @lc app=leetcode id=73 lang=csharp
 *
 * [73] Set Matrix Zeroes
 */

// @lc code=start
public class Solution {
    public void SetZeroes(int[][] matrix)
    {
        HashSet<int> rows = new HashSet<int>();
        HashSet<int> columns = new HashSet<int>();

        //先搜索matrix的row行跟column列上有沒有0的元素
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    rows.Add(i);
                    columns.Add(j);
                }
            }
        }

        //如果有matrix[i][j]的row行或column列，剛好有包含在任一個hashset上的話，就設定為0
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (rows.Contains(i) || columns.Contains(j))
                {
                    matrix[i][j] = 0;
                }
            }
        }
        //時間複雜度O(N^2)
        //空間複雜度O(m+n)
    }
}
// @lc code=end

