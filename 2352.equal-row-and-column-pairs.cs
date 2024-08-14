/*
 * @lc app=leetcode id=2352 lang=csharp
 *
 * [2352] Equal Row and Column Pairs
 */

// @lc code=start
public class Solution {
    public int EqualPairs(int[][] grid)
    {
        Dictionary<string, int> row_map = new Dictionary<string, int>(); //設置Dictionary，row和column
        Dictionary<string, int> col_map = new Dictionary<string, int>();
        int count = 0;

        for (int i = 0; i < grid.Length; i++) //把row的數字轉成string
        {
            string temp = ""; //每一次i迴圈，重置temp
            for (int j = 0; j < grid.Length; j++) //訪問grid內數值
            {
                if(j < grid.Length-1) //超過的話，就不用加空白鍵了
                {
                    temp = temp + grid[i][j] + ",";
                }
                else
                {
                    temp = temp + grid[i][j];
                }
            }
            if(row_map.ContainsKey(temp)) //如果row_map有temp這個key，就把該key的value加1
            {
                row_map[temp]++;
            }
            else
            {
                row_map[temp] = 1; //沒有的話，就把這個temp值新增為key值，並設定value為1
            }
        }

       for (int inverse_i = 0; inverse_i < grid.Length; inverse_i++) //把col的數字轉成string  
        {
            string temp = "";
            for (int inverse_j = 0; inverse_j < grid.Length; inverse_j++)   
            {
                if(inverse_j < grid.Length-1) //超過的話，就不用加空白鍵了
                {                                                   //雙迴圈的索引值i值放二維、j值放1維，以取得column(柱子)
                    temp = temp + grid[inverse_j][inverse_i] + ","; //grid[0,0]
                }                                                   //grid[1,0] = temp == "3,1,2"
                else                                                //grid[2,0] 
                {
                    temp = temp + grid[inverse_j][inverse_i];
                }
            }
            if(col_map.ContainsKey(temp))
            {
                col_map[temp]++;
            }
            else
            {
                col_map[temp] = 1;
            }
        }

        foreach(string same in row_map.Keys) //設string值same，訪問row_map
        {
            if(col_map.ContainsKey(same))   //如果col_map有跟same同名的key值
            {
                count = count + col_map[same] * row_map[same];  //就把row_map跟col_map內key值得value值，互乘，然後加在count身上
            }
        }
        return count;
    }
}
// @lc code=end

/*
        //網友寫得比較好懂得寫法，但是也只有60% 53%
        int n = grid.Length;
        int equalPairs = 0;
        Dictionary<string, int> rowCounts = new Dictionary<string, int>();

        // 計算相同行的數量
        foreach (var row in grid)
        {
            string rowString = string.Join(",", row);
            if (!rowCounts.ContainsKey(rowString))
                rowCounts[rowString] = 0;
            rowCounts[rowString]++;
        }

        // 檢查列並與計數的行進行比較
        for (int col = 0; col < n; col++)
        {
            var column = new int[n];
            for (int row = 0; row < n; row++)
            {
                column[row] = grid[row][col];
            }

            string columnString = string.Join(",", column);
            if (rowCounts.ContainsKey(columnString))
                equalPairs += rowCounts[columnString];
        }
        return equalPairs;
    }
*/