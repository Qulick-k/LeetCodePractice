/*
 * @lc app=leetcode id=2491 lang=csharp
 *
 * [2491] Divide Players Into Teams of Equal Skill
 */

// @lc code=start
public class Solution {
    public long DividePlayers(int[] skill)
    {
        //使用哈希表，須注意long、算共通skill時乘2的先後順序

        //算總和
        //如果2*總和%元素數量有餘數的話，回傳-1
        //設置哈希表紀錄元素出現的次數
        //算兩個一組的共通skill為多少 公式為 總和 / 元素數量 * 2
        //設置結果

        //訪問陣列
        //    找當前元素相對應skill的元素，哈希表當前元素數量為0的話，跳過當前迴圈
        //    哈希表沒有當前元素相對應skill的元素，或是數量為0的話，也回傳-1
        //    結果 加上 當前元素 * 當前元素相對應skill的元素
        //    哈希表[當前元素]的數量-1
        //    哈希表[當前元素的相對應元素]的數量-1

        int sum = 0;
        foreach (int skillItem in skill)
        {
            sum += skillItem;
        }

        if ((2 * sum) % skill.Length != 0) return -1;

        Dictionary<int, int> table = new Dictionary<int, int>();
        foreach (int skillItem in skill)
        {
            if (table.ContainsKey(skillItem))
            {
                table[skillItem] += 1;
            }
            else
            {
                table[skillItem] = 1;
            }
        }

        long target = 2 * sum / skill.Length;
        
        long res = 0;

        foreach(int skillItem in skill)
        {
            
            if ( table[skillItem] == 0) continue;
            
            int diffrence = (int)(target - skillItem);
            if (!table.ContainsKey(diffrence) || table[diffrence] == 0) return -1;

            res += (long)(skillItem * diffrence);
            table[skillItem] -= 1;
            table[diffrence] -= 1;
        }
        return res;
    }
}
// @lc code=end

