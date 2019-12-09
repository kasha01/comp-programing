#ifndef NEXT_LARGEST_ELEMENT_H_INCLUDED
#define NEXT_LARGEST_ELEMENT_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/next-larger-element/0

/***
This is a very pick problem, using string conactination in the result versus using a vector will slow down the
program and causes a TLE. so you cannot do something like result = result + to_string(_stack.top()) + " " + result
that will cause a TLE
*/
void solve(long long int arr[],int n){
	stack<long long int> _stack;
	_stack.push(arr [n - 1]);
	vector<long long int> result(n);
	result[n-1] = -1;

	for (int i = n-2; i >= 0; --i) {
		// look in _stack until i find an element greater than arr[i]
		while (!_stack.empty() && arr[i] > _stack.top()) {
		    _stack.pop();	// pop smaller element in _stack so i can peek to next one.
		}
		result[i] = _stack.empty() ? -1 : _stack.top();
		_stack.push(arr [i]);
	}

    for (int i = 0; i < n; ++i) {
    	cout << result[i] << " ";
    }
    cout << "\n";
}


void test() {
    // speed up the input out put of cin/cout.
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

	long long int arr[] = {3,4,2,1};
	int n = 4;
	solve(arr,n);
	}
}

#endif // NEXT_LARGEST_ELEMENT_H_INCLUDED
