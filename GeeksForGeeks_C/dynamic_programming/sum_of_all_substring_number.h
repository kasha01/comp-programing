#ifndef SUM_OF_ALL_SUBSTRING_NUMBER_H_INCLUDED
#define SUM_OF_ALL_SUBSTRING_NUMBER_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/sum-of-all-substrings-of-a-number/0
void mt()
{
    string s = "1";
    int n = s.length();

    int sum = 0;
    for(int i=1;i<=n;i++){
        for(int j=0;j+i<=n;j++){
            sum = sum + stoi(s.substr(j,i));
        }
    }
    cout << sum;
}

#endif // SUM_OF_ALL_SUBSTRING_NUMBER_H_INCLUDED
