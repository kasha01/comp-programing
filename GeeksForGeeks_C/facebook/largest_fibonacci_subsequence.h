#ifndef LARGEST_FIBONACCI_SUBSEQUENCE_H_INCLUDED
#define LARGEST_FIBONACCI_SUBSEQUENCE_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/largest-fibonacci-subsequence/0
void solve(int* arr, int n){
	unordered_set<int> myset;
	myset.insert(0); myset.insert(1);
	int a = 1; int b = 1; int c = 0;

	while (c <= 1000) {
		c = a + b;
		myset.insert(c);
		a = b; b = c;
	}

	for (int i = 0; i < n; i++) {
		int x = arr[i];
		if (myset.find(x) != myset.end()) {
			cout <<  x << " ";
		}
	}
}

int driver()
{
	int arr[] = { 0, 2, 8, 5, 2, 1, 4, 13, 23 };
	int n = sizeof(arr)/sizeof(int);
	solve(arr, n);
    return 0;
}


#endif // LARGEST_FIBONACCI_SUBSEQUENCE_H_INCLUDED
