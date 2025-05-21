/*
 * @lc app=leetcode id=2416 lang=csharp
 *
 * [2416] Sum of Prefix Scores of Strings
 */

// @lc code=start
//設置Node節點類別，設置Dictionary和int
public class Node
{
    public Dictionary<char, Node> vals = new Dictionary<char, Node>();
    public int count = 0;
}
//設置Trie AKA prefixTree類別
public class Trie 
{
    //初始化節點
    public Node root = new Node();

    //設置Insert方法，把所有組合所產生的數量記錄進各個節點內的vals
    public void Insert(string word)
    {
        Node prefixTreeRoot = root;
        foreach(char c in word)
        {
            if (prefixTreeRoot.vals.ContainsKey(c) == false)
            {
                prefixTreeRoot.vals[c] = new Node();
            }
            prefixTreeRoot = prefixTreeRoot.vals[c];
            prefixTreeRoot.count++;
        }
    }

    //設置SumPrefix方法，在字串中符合各個字元組合的分數，加總起來，回傳到主程式
    public int SumPrefix(string word)
    {
        Node prefixTreeRoot = root;
        int count = 0;
        foreach(char c in word)
        {
            if (prefixTreeRoot.vals.ContainsKey(c) == false)
            {
                return count;
            }
            prefixTreeRoot = prefixTreeRoot.vals[c];
            count += prefixTreeRoot.count;
        }
        return count;
    }
}
public class Solution {
    public int[] SumPrefixScores(string[] words)
    {
        //使用HashMap、prefixTree A.K.A Trie
        
        //設置結果陣列
        int[] res = new int[words.Length];
        //設置prefixTree根節點
        Trie trie = new Trie();
        
        //插入每一個字串，算每一組字元組合的出現次數
        foreach(string w in words)
        {
            trie.Insert(w);
        }
        //插入每一個字串，看看每一個字串有多少Prefix分數
        for(int i = 0; i < words.Length; i++)
        {
            res[i] = trie.SumPrefix(words[i]);
        }
        return res;
    }
}
///參考1 https://youtu.be/OJ0PMH6M2MQ?si=nCZAQo2Y4BWXTjwA
///參考2 https://youtu.be/F-5cmvhLw90?si=JA4MrZu76zbcPH_M
///參考3 https://leetcode.com/problems/sum-of-prefix-scores-of-strings/solutions/5830235/c-trie-solution/?envType=daily-question&envId=2024-09-24
// @lc code=end

/*//純使用HashMap，造成Edge Case產生Out of memory.
        Dictionary<string, int> table = new Dictionary<string, int>();

        int[] res = new int[words.Length];

        foreach (string word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (table.ContainsKey(word.Substring(0, i + 1)) == false)
                {
                    table[word.Substring(0, i + 1)] = 1;
                }
                else
                {
                    table[word.Substring(0, i + 1)] += 1;
                }
            }
        }
        int step = 0;
        foreach (string word in words)
        {
            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                sum += table[word.Substring(0,i + 1)];
            }
            res[step] = sum;
            step++;
        }
        return res;
*/