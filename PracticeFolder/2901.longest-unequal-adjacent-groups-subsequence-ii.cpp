/*
 * @lc app=leetcode id=2901 lang=cpp
 *
 * [2901] Longest Unequal Adjacent Groups Subsequence II
 */

// @lc code=start
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>

using namespace std;
class Solution {
public:
    bool differByOneChar(string word1, string word2) {
        if (word1.length() != word2.length()) return false;
        int diffCount = 0;
        for (int i = 0; i < word1.length(); i++) 
            diffCount += word1[i] != word2[i];
        return diffCount == 1;
    }
    
    vector<string> getWordsInLongestSubsequence(vector<string>& words, vector<int>& groups) {
        int n = groups.size();
        vector<int> dp(n, 1), parent(n, -1);
        int maxi = 0;
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (groups[i] != groups[j] && 
                        differByOneChar(words[i], words[j]) && 
                            dp[i] < dp[j] + 1) {
                    dp[i] = dp[j] + 1;
                    parent[i] = j;
                }
            }
            maxi = max(maxi, dp[i]);
        }
        
        vector<string> result;
        for (int i = 0; i < n; i++) {
            if (maxi == dp[i]) {
                while (i != -1) {
                    result.push_back(words[i]);
                    i = parent[i];
                }
                break;
            }
        }
        reverse(result.begin(), result.end());
        return result;
    }
};

// @lc code=end

/*class Solution {
public:
    vector<string> getWordsInLongestSubsequence(vector<string>& words, vector<int>& groups) 
    {
        /*
        for (i = 0; i++; i < words.length;)
        {
            for
            vector<string> temp = words[i], words[j];

            if (groups[i] != groups[j]) //符合group值不同
            {
                if (words[i].length == words[j].length) //符合字串長度相同
                {
                    if (checkHammingDistance(words[i], words[j])) //符合漢明距離為1
                    {
                        return vector
                    }
                    
                }
            } 
        }
        
          
    }
};*/