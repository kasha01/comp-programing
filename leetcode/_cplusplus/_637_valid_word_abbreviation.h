#ifndef _637_VALID_WORD_ABBREVIATION_H_INCLUDED
#define _637_VALID_WORD_ABBREVIATION_H_INCLUDED

// https://www.lintcode.com/problem/637/

class Solution {
public:
    bool isNum(char c){
        return c >= '0' && c <= '9';
    }

    bool validWordAbbreviation(string &word, string &abbr) {
        long long n = word.size();
        long long m = abbr.size();

        long long i=0; long long j=0;
        while(i<n && j<m){
            if(isNum(abbr[j])){
                if(abbr[j] == '0'){
                    ++j; ++i; continue;  // edge case of 01
                }

                long long num = 0;
                while(j<m && isNum(abbr[j])){
                    num = (num*10) + (abbr[j] - '0');
                    ++j;
                }
                i = i + num;
            }
            else if(word[i] != abbr[j]){
                return false;
            }
            else{
                ++i; ++j;
            }
        }

        return i==n && j==m;
    }
};

#endif // _637_VALID_WORD_ABBREVIATION_H_INCLUDED
