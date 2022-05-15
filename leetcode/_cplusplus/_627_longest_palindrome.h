#ifndef _627_LONGEST_PALINDROME_H_INCLUDED
#define _627_LONGEST_PALINDROME_H_INCLUDED

// https://www.lintcode.com/problem/627

class Solution {
public:
    /**
     * @param s: a string which consists of lowercase or uppercase letters
     * @return: the length of the longest palindromes that can be built
     */
    int longestPalindrome(string &s) {
        // write your code here
        map<char,int> freq;

        for(int i=0;i<s.size();++i){
            freq[s[i]]++;
        }

        int sum = 0;
        bool iHaveOddCharCount = false;
        for(map<char,int>::iterator it=freq.begin();it!=freq.end();++it){
            if(it->second % 2 == 0){
                // even
                sum = sum + it->second;
            }
            else{
                iHaveOddCharCount = true;
                sum = sum + it->second - 1;
            }
        }

        return sum + (iHaveOddCharCount ? 1 : 0);
    }
};
#endif // _627_LONGEST_PALINDROME_H_INCLUDED
