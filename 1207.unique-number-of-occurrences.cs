/*
 * @lc app=leetcode id=1207 lang=csharp
 *
 * [1207] Unique Number of Occurrences
 */

// @lc code=start
public class Solution {
    public bool UniqueOccurrences(int[] arr)
    {
        //只要arr陣列內的每一種整數，出現的次數各不相同，就回傳true
        //要是有兩種以上的整數，出現的次數相同，直接回傳false
        //本次解法使用Dictionary紀錄每一種整數出現的次數
        
        Dictionary<int, int> table = new(); //建立一個Dictionary，命名為table
        for (int i = 0; i < arr.Length ; i++) //拜訪arr陣列內的元素
        {
            if(table.ContainsKey(arr[i])) //如果table內的key值，跟arr[i]相同，那個key的value值就+1
            {
                table[arr[i]] = table[arr[i]] + 1;
            }
            else //table內找不到跟arr[i]相同的key值的話，就把arr[i]作為key值新增到table內
            {
                table.Add(arr[i], 1);
            }
        }

        foreach(var v in table) //使用雙迴圈判定table內有沒有重複的value值
        {
            foreach(var k in table)
            {
                if(v.Key == k.Key) //如果v的key名字跟k的key名字相同，代表他們互相是自己﹐所以跳過，進入下一個迴圈
                {
                    continue;
                }
                else //如果v的key名字跟k的key名字不同的話，才可以進行下一階段的判斷
                {
                    if (v.Value == k.Value) //如果v.key的value遇到不同種k.key的value，得到相同的value值，代表有兩種以上的整數，出現的次數相同，回傳false
                    {
                        return false;
                    }
                }
            }
        }
        return true; //全部跑完都沒問題，就回傳true
    }
}
// @lc code=end

