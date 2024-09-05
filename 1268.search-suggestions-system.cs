/*
 * @lc app=leetcode id=1268 lang=csharp
 *
 * [1268] Search Suggestions System
 */

// @lc code=start
public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public IList<string> suggestion = new List<string>();
}
public class Solution {
    //新增加一個TrieNode的root節點
    private TrieNode root;
    public Solution()
    {
        root = new TrieNode();
    }

    public IList<IList<string>> result = new List<IList<string>>();
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        //使用Trie
        //先排序
        Array.Sort(products);

        for (int i = 0; i < products.Length; i++)
        {
            Insert(products[i]);
        }
        Search(searchWord);
        return result;
    }

    public void Insert(string word)
    {
        TrieNode current = root;
        //拜訪字串內的每一個字元
        foreach (char c in word)
        {
            //'a' - 'a' == 0
            //'b' - 'a' == 1
            //.....
            //'z' - 'a' ==25
            //int index = c - 'a';
            if (current.Children.ContainsKey(c) == false)
            {
                current.Children.Add(c, new TrieNode());
            }
            current = current.Children[c];

            //如果當前的推薦字串串列長度小於3的話，就把自繼續加進串列
            if (current.suggestion.Count < 3)
            {
                current.suggestion.Add(word);
            }
        }
    }

    public void Search(string word)
    {
        //
        TrieNode current = root;
        foreach (char c in word)
        {
            if (current.Children.TryGetValue(c, out TrieNode child))
            {
                current = child;
            }
            else
            {
                current = new TrieNode();
            }
            
            if ( current != null )
            {
                result.Add(current.suggestion);
            }
            else
            {
                result.Add(new List<string>());
            }
        }
    }
}
// @lc code=end

