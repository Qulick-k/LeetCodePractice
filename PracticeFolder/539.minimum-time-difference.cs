/*
 * @lc app=leetcode id=539 lang=csharp
 *
 * [539] Minimum Time Difference
 */

// @lc code=start
public class Solution {
    public int FindMinDifference(IList<string> timePoints)
    {
        //Sort、timePoints長度一定大於等於2、timePoints的string一定符合HH:MM、注意換區的時間也算最小的分鐘差。EX 00:01 > 23:59
        //00:01 == 1；23:59==1439
        //兩者最小分鐘差 == 1 + (1440 - 1439) == 1 + 1 == 2


        //設置一個串列res放每一個時間的時長
        //把串列內的所有字串從":"切出HH和MM，丟給字串區域陣列
            //字串區域陣列[0]轉換成整數丟給hour
            //字串區域陣列[1]轉換成整數丟給minute
            //hour乘上60，再和minute相加Add進res串列
        
        //設置一個最小值min = int.MaxValue
        //把res串列內的數值做比較，全部升冪排序
        //比較完後，以i=1為迴圈，取第i個字串和第i-1個字串的數字差異
            //比較min和上面兩個差異量，把更小的重新更新到min內
        //注意換區的時間也算最小的分鐘差。EX 00:01 > 23:59
            //00:01 == 1；23:59==1439
            //兩者最小分鐘差 == 1 + (1440 - 1439) == 1 + 1 == 2
        
        //回傳最小值

        List<int> res = new List<int>();
        for (int i = 0; i < timePoints.Count; i++)
        {
            string[] temp = timePoints[i].Split(":");
            int hour = int.Parse(temp[0]);
            int minute = int.Parse(temp[1]);
            res.Add((60*hour + minute));
        }

        int min = int.MaxValue;
        res.Sort();
        for (int i = 1; i < res.Count; i++)
        {
            min = Math.Min(min, (res[i]-res[i-1]));
        }
        min = Math.Min( min, (res[0] + (1440 - res[res.Count-1])) );
        return min;
    }
}
// @lc code=end

