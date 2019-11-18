#ifndef STRING_COMPARISON_H_INCLUDED
#define STRING_COMPARISON_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/string-comparison/0
void test(){
    string s1 = "abc"; string s2 = "abcd";
    cout << solve(s1,s2);
}

int solve(string s1, string s2){
    int n = s1.size();
    int m = s2.size();

    int i = 0;
    int j = 0;
    while (i<n && j<m) {
        char c1 = s1 [i];
        char c2 = s2 [j];

        int p1 = (s1 [i] + 0)*10;
        int p2 = (s2 [j] + 0)*10;

        if(i+1 < n && c1 == 'n' && s1[i+1] == 'g'){
            p1 = p1 + 5;
            i++;
        }

        if(j+1 < n && c2 == 'n' && s2[j+1] == 'g'){
            p2 = p2 + 5;
            j++;
        }

        if(p1 < p2)
            return -1;
        else if(p1 > p2)
            return 1;

        i++;j++;
    }

    if(n<m)
        return -1;
    else if(n>m)
        return 1;
    else
        return 0;
}

#endif // STRING_COMPARISON_H_INCLUDED
