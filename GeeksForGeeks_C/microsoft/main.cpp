#include <bits/stdc++.h>

using namespace std;

vector<int> arr;

int bsearch(int i, int j, int x){
	int m = ((j - i) / 2) + i;

	while (i<=j) {
		if (arr [m] == x)
			return m;
		else if (arr [m] < x)
			return bsearch (m + 1, j, x);
		else if (arr [m] > x)
			return bsearch (i, m - 1, x);
	}
	return -1;
}

int bsearchDesc(int i, int j, int x){
	int m = ((j - i) / 2) + i;

	while (i<=j) {
		if (arr [m] == x)
			return m;
		else if (arr [m] > x)
			return bsearchDesc (m + 1, j, x);
		else if (arr [m] < x)
			return bsearchDesc (i, m - 1, x);
	}
	return -1;
}

int findPeakPoint(int i, int j){
	int m = ((j - i) / 2) + i;

	if (i == j)
		return m;

	while (i < j) {
		int* a;
		int* b;
		a = nullptr; b = nullptr;

		if(m-1>=i)
			a = new int(arr [m - 1]);

		if(m+1<=j)
			b = new int(arr [m + 1]);

		if (a && b && *a < arr [m] && *b < arr [m]) {
			delete a; delete b;
			return m;
		}
		else if ((a && *a < arr [m]) || (b && arr [m] < *b)) {
			// ascending
			delete a; delete b;
			return findPeakPoint (m + 1, j);
		} else if ((a && *a > arr [m]) || (b && arr [m] > *b)) {
			// desc
			delete a; delete b;
			return findPeakPoint (i, m - 1);
		} else {
			delete a; delete b;
			return -1;
		}
	}
	return -1;
}

int solve(int n, int x){
	int p = findPeakPoint(0,n-1);
	if (x > arr [p])
		return -1;
	else if (x == arr [p])
		return p;
	else {
		int result = -1;
		result = bsearch (0, p - 1, x);
		if (result == -1) {
			result = bsearchDesc (p + 1, n - 1, x);
		}
		return result;
	}
}

int main()
{
	arr.clear();
	int n = 5;
	arr = { 1, 2, 7, 4, 3 };
	int r = solve (n, 2);

	cout << r;

    return 0;
}
