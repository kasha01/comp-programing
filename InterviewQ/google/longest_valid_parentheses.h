#ifndef LONGEST_VALID_PARENTHESES_H_INCLUDED
#define LONGEST_VALID_PARENTHESES_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/longest-valid-parentheses/0
void mt()
{
    string s = "((()";
    int n = s.length();
    int memo[n];
    memset(memo,0,n*sizeof(int));

    stack<int> st;

    int result=0;
    int sum=0;
    for(int i=0;i<n;++i){
        sum=0;
        if(s[i] == '('){
            st.push(i);
        }
        else{
            if(!st.empty()){
                int iopen = st.top();
                int iclose = i;
                st.pop();

                if(iclose-1>=0 && iclose-1!=iopen && iclose-1-memo[iclose-1] > iopen){
                    sum = sum + memo[iclose-1];
                }
                if(iopen-1 >=0){
                    sum = sum + memo[iopen-1];
                }
                sum = sum + 1;
            }
        }
        memo[i] = sum;
        result = max(result,sum);
    }
    cout << result*2 << endl;
}


#endif // LONGEST_VALID_PARENTHESES_H_INCLUDED
