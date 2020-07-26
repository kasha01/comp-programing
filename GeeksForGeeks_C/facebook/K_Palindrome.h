#ifndef K_PALINDROME_H_INCLUDED
#define K_PALINDROME_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/k-palindrome/1

string s;
// recurssive solution O(2^n)
bool isPalindrome_rec(int i, int j, int k){
	if(k<0 || i < 0 || j>= s.size()){
		return false;
	}

	while(i<j){
		if (s[i] == s[j]){
			i++;j--;
		}
		else{
			--k;
			return isPalindrome_rec(i+1,j,k) || isPalindrome_rec(i,j-1,k);
		}
	}
	return true;
}

// dp O(n^2)
bool isPalindrome(string s,int k)
{
	int n = s.size();
	int** memory = new int*[n];

	for(int i=0;i<n;++i){
		memory[i] = new int[n];
		memset(memory[i],0,n);
	}

	for(int l=1;l<=n;++l){
		for(int i=0;i+l-1<n;++i){
			int j = i+l-1;

			if(j==i){
				memory[i][j]=0;
			}
			else if(j==i+1){
				// length 2
				bool res = s[i] == s[j];
				int a = res ? 0 : 1;
				memory[i][j] = a;
			}
			else{
				if (s[i] == s[j]){
					memory[i][j] = memory[i+1][j-1];
				}
				else{
					int a = min(memory[i+1][j], memory[i][j-1]) + 1;
					memory[i][j] = a;
				}
			}
		}
	}

	bool res = memory[0][n-1] <= k;

	for(int i=0;i<n;++i){
		delete[] memory[i];
	}
	delete[] memory;

	return res;
}

void driver(){
	int k = 1;
	s = "abcdecba";
	cout << isPalindrome_rec(0,s.size()-1,k);

	cout << isPalindrome(s,k);
}


#endif // K_PALINDROME_H_INCLUDED
