/*
 * @lc app=leetcode id=884 lang=csharp
 *
 * [884] Uncommon Words from Two Sentences
 */

// @lc code=start
public class Solution {
    public string[] UncommonFromSentences(string s1, string s2)
    {
        //自己寫、無參考，60% / 100% ，5分鐘內解決
        //使用HashTable、string.Split()、Counting    

        //設置兩個陣列，放置兩個被" "空格分開來的字串s1、s2們
        //設置一個Dictionary紀錄字串出現了幾次
        //設置res串列
        //跑s1陣列內的所有字串，紀錄進Dictionary
            //第一次出現就給1，重複出現就+1
        //跑s2陣列內的所有字串，紀錄進Dictionary
            //第一次出現就給1，重複出現就+1
        //跑Dictionary內的所有Key字串
            //如果Key字串帶的Value，等於1
                //那就把目前的Key字串加進res串列內
        //回傳，被轉成陣列的串列
        string[] s1_array = s1.Split(" ");
        string[] s2_array = s2.Split(" ");
        Dictionary<string, int> set = new Dictionary<string, int>();
        List<string> res =  new List<string>();
        foreach(string s in s1_array)
        {
            if(set.ContainsKey(s) == false)
            {
                set[s] = 1;
            }
            else
            {
                set[s] += 1;
            }
        }
        foreach(string s in s2_array)
        {
            if(set.ContainsKey(s) == false)
            {
                set[s] = 1;
            }
            else
            {
                set[s] += 1;
            }
        }
        foreach(var index in set)
        {
            if(index.Value == 1)
            {
                res.Add(index.Key);
            }
        }
        return res.ToArray();
    }
}
// @lc code=end

