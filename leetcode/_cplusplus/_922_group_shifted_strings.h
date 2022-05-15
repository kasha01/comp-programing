#ifndef _922_GROUP_SHIFTED_STRINGS_H_INCLUDED
#define _922_GROUP_SHIFTED_STRINGS_H_INCLUDED

// https://www.lintcode.com/problem/922/description

class Solution {
public:
    /**
     * @param strings: a string array
     * @return: return a list of string array
     */
    string getShift(string s){
        string shift = "";
        for(int i=1;i<s.size();++i){
            int diff = s[i] - s[i-1];

            if(diff < 0)
                diff = diff + 26;

            shift += diff + 'a';  // for some reason shift = shift + diff won't work
        }

        return shift;
    }

    vector<vector<string>> groupStrings(vector<string> &strings) {
        // write your code here
        map<string,vector<string>> mp;
        int n = strings.size();

        for(int i=0;i<n;++i){
            string shift = getShift(strings[i]);
            cout << shift << "\n";
            mp[shift].push_back(strings[i]);
        }

        vector<vector<string>> ans;
        for(map<string,vector<string>>::iterator it=mp.begin(); it!=mp.end();++it){
            ans.push_back(it->second);
        }

        return ans;
    }
};

#endif // _922_GROUP_SHIFTED_STRINGS_H_INCLUDED
