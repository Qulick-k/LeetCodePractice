/*
 * @lc app=leetcode id=30 lang=csharp
 *
 * [30] Substring with Concatenation of All Words
 */

// @lc code=start
public class Solution {
    public IList<int> FindSubstring(string s, string[] words)
    {
        //使用Slide Window、HashTable  || 90% / 62%
        //設置result串列
        IList<int> result = new List<int>();        
        //words每個索引字串的長度、words的索引數量、存取子集合的字串長度
        int wordLength = words[0].Length;
        int wordsCount = words.Length;
        int SubstringLength = wordsCount*wordLength;
        //設置word_dic，紀錄每一個word出現在words陣列內幾次
        Dictionary<string, int> word_dic = new Dictionary<string, int>();
        //拜訪words陣列，word_dic如果有word的Key，就把該word的出現次數+1，否則新增該word為Key，並記錄次數為1
        foreach (string word in words)
        {
            if (word_dic.ContainsKey(word))
            {
                //word_dic[word] = word_dic[word] + 1;
                word_dic[word] ++;
            }
            else
            {
                word_dic[word] = 1;
            }
        }
        //拜訪長度為words內的字串長度
        for (int i = 0; i < wordLength; i++)
        {
            //初始化，sliding window的"左"和"右"指標，都從i開始
            int left = i;
            int right = i;
            //設置一個Dictionary去追蹤目前迴圈內的word，出現了幾次，並記錄在current_dic內
            Dictionary<string, int> current_dic = new Dictionary<string, int>();
            int count = 0; //計算有幾個符合words陣列內的字串次數

            //sliding window從右邊指標走到s字串最後
            while (right + wordLength <= s.Length)
            {
                //萃取出從right位置+wordLength長度的s子字串
                string word = s.Substring(right, wordLength);
                right = right + wordLength; //移動右邊指標wordLength個長度
                //檢查萃取出來的word如果有存在在word_dic內
                if (word_dic.ContainsKey(word))
                {
                    //那就把該word丟進current_dic來追蹤該字串的出現次數
                    if (current_dic.ContainsKey(word))
                    {
                        current_dic[word] ++;
                    }
                    else
                    {
                        current_dic[word] = 1;
                    }
                    
                    count ++; //符合words陣列內的字串次數+1
                    //如果當前word在current_dic內出現的次數，比word_dic內出現的次數還多，代表word出現次數太多了
                    while (current_dic[word] > word_dic[word])
                    {
                        //萃取出left位置+wordLength長度的s子字串，作為leftWord字串
                        string leftWord = s.Substring(left, wordLength);
                        current_dic[leftWord] --; //把該字串在current_dic多餘的紀錄-1
                        left = left + wordLength; //並且移動左邊指標wordLength個長度
                        count --; //減少符合words陣列內的字串次數
                    }
                    //如果符合words陣列內的字串次數，等同於words的索引長度
                    if (count == wordsCount)
                    {
                        //把更新過的letf指標作為索引放入result串列
                        result.Add(left);
                    }
                }
                else
                {
                    //檢查萃取出來的word如果沒有存在在word_dic內
                    current_dic.Clear();  //清空目前的Dictionary
                    count = 0;            //歸零符合words陣列內的字串次數
                    left = right;         //left指標，移動到right所在的索引處
                }
            }
        }
        //回傳result串列內有符合條件的索引值
        return result;
    }
}
// @lc code=end

/* C#的Substring
https://learn.microsoft.com/zh-tw/dotnet/api/system.string.substring?view=net-8.0
*/

/*第一次嘗試參考教學
https://youtu.be/ddSzsLUSPrQ?si=Q3OqE1GEtDYALR-3
*/

/* TLE了 181/182
        //使用Slide Window、HashTable  
        IList<int> result = new List<int>();
        //如果s長度等於0，或者word[0]的長度等於0，直接回傳null
        //if (s.Length == 0 || words[0].Length == 0)
        //{
        //    return result;
        //}
        
        Dictionary<string, int> check_word = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (check_word.ContainsKey(word))
            {
                check_word[word] = check_word[word] + 1;
            }
            else
            {
                check_word[word] = 1;
            }
        }

        //words的索引數量
        int wordCount = words.Length;
        //words每個索引字串的長度
        int wordLength = words[0].Length;
        //存取子集合的字串長度
        int SubstringLength = wordCount*wordLength;

        for (int i = 0; i <= s.Length - SubstringLength; i++)
        {
            Dictionary<string, int> hash_used = new Dictionary<string, int>();
            //不要用j++，有可能造成Time Limit Exceeded，隔天測試一次
            for (int j = 0; j < wordCount; j++)
            {
                int next_index = i + j * wordLength;
                string cur_word = s.Substring(next_index, wordLength);
                //for (int k = next_index; k < next_index + wordLength; k++)
                //{                   
                //    cur_word = cur_word + s[k];
                //}/
                if(check_word.ContainsKey(cur_word) == false)
                {
                    break;
                }
                //int used_num = 0;
                //hash_used.TryGetValue(cur_word, out used_num);
                //hash_used[cur_word] = used_num + 1;
                if (hash_used.ContainsKey(cur_word))
                {
                    hash_used[cur_word] = hash_used[cur_word] + 1;
                }
                else
                {
                    hash_used[cur_word] = 1;
                }

                //int check_Num = 0;
                //check_word.TryGetValue(cur_word, out int value);
                //if (value == null)
                //{
                //    check_Num = 0;
                //}
                //else
                //{
                //    check_Num = value;
                //}
                
                if (hash_used[cur_word] > check_word[cur_word])
                {
                    break;
                }
                
                if ( j + 1 == wordCount)
                {
                    result.Add(i);
                }
            }
        }
        return result;
*/