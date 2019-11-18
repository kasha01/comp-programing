#ifndef LONGEST_EVEN_LENGTH_SUBSTRING_H_INCLUDED
#define LONGEST_EVEN_LENGTH_SUBSTRING_H_INCLUDED


// https://practice.geeksforgeeks.org/problems/longest-even-length-substring/0
// find length of the longest substring of ‘str’, such that the length of the
// substring is 2k digits long and sum of left k digits is equal to the sum of right k digits.
// ex: str = 1234123 ==> result = 23 | 41  --> length = 4
void solve(string str){
    int n = str.length();

    int mx = 0;
    for(int i=0;i<n-1;++i){
        int k=i+1;
        int j=i;
        int c=0;
        int sum_r=0;
        int sum_l=0;
        while(k<n && j>=0){
			c++;
			int l= str[j]-48;
			int r = str[k]-48;
			sum_r = sum_r + r;
			sum_l = sum_l + l;

            if(sum_l==sum_r){
                mx=max(mx,c*2);
            }
            j--;k++;
        }
    }

    cout << mx;
}


#endif // LONGEST_EVEN_LENGTH_SUBSTRING_H_INCLUDED
