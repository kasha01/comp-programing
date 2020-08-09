#ifndef LONGEST_PALINDROME_SUBSTRING_H_INCLUDED
#define LONGEST_PALINDROME_SUBSTRING_H_INCLUDED

// substring => contiguous. Print the first longest palindrome substring
// https://practice.geeksforgeeks.org/problems/longest-palindrome-in-a-string/0
void mt(){
    string s = "ayaxzfbjbkrxiri";
    int n = s.length();
    bool** memo = new bool*[n];

    for(int i=0;i<n;i++){
        memo[i] = new bool[n];
        for(int j=0;j<n;j++){
            memo[i][j] = true;
        }
    }

    int mx=1; int si=0; int sj=0;   //maximum length of palindrome so far, start index, end index
    for(int i=0;i<n-1;i++){
        if(s[i]==s[i+1]){
            memo[i][i+1] = true;
            mx=2;
            if(si==0 && sj==0){
                si=i; sj=i+1;
            }
        }
        else{
            memo[i][i+1] = false;
        }
    }

    for(int g=3;g<=n;g++){
        for(int i=0;i<n-g+1;i++){
            int j = i+g-1;

            if(s[i] == s[j]){
                memo[i][j] = memo[i+1][j-1];
                if(mx<(j-i+1) && memo[i+1][j-1]){
                    mx=j-i+1;
                    si=i; sj=j;
                }
            }
            else{
                memo[i][j] = false;
            }
        }
    }

    //cout << memo[0][n-1] << endl;
    cout << si << " " << sj << endl;
    cout << s.substr(si,sj-si+1);
}

#endif // LONGEST_PALINDROME_SUBSTRING_H_INCLUDED
