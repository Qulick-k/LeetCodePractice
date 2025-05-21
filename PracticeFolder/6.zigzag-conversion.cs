/*
 * @lc app=leetcode id=6 lang=csharp
 *
 * [6] Zigzag Conversion
 */

// @lc code=start
public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1) return s;

       //建立numRows個StringBuilder
        List<StringBuilder> SB_Rows = new List<StringBuilder>();
        for (int i = 0; i < numRows; i++)
        {    
            SB_Rows.Add(new StringBuilder());
        }

        //目前第幾行 & 目前是不是垂直走
        int current_row = 0; 
        bool vertical = true;
        
        //依照Z字圖形分配字元到各個StringBuilder內
        foreach(char c in s)
        {
            SB_Rows[current_row].Append(c);

            if (current_row == (numRows - 1))
            {
                vertical = false;
            }
            else if (current_row == 0)
            {
                vertical = true;
            }
        
            current_row += vertical ? 1 : -1;            
        }

        //合併所有的StringBuilder
        StringBuilder res = new StringBuilder();
        foreach (var row in SB_Rows)
        {
            res.Append(row);
        }
        
        return(res.ToString());
    }
}
// @lc code=end

