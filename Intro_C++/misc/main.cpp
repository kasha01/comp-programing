/* C++ program to find the smallest positive missing number */

#include <bits/stdc++.h>
using namespace std;

// function to change pointer to pointer value
void changePointerValue(int** ptr_ptr, int v)
{
	v=**ptr_ptr+5;
	*ptr_ptr = &v;
}

void changePointerValue(int* &ptr_ptr)
{
	*ptr_ptr = 77;
}

// Driver code
int main()
{
	int var = 23;
    int* ptr_to_var = &var;

    cout << "Passing Pointer to function:" << endl;

    cout << "Before :" << *ptr_to_var << endl; // display 23

    int v=0;
    changePointerValue(ptr_to_var);

    cout << "After :" << *ptr_to_var << endl; // display 23


	int arr[] = {100,40,30,80,20};
	int arr_size = sizeof(arr)/sizeof(arr[0]);
	//int missing = findMissing(arr, arr_size);
	//cout << "The smallest positive missing number is " << missing;
	return 0;
}

// This is code is contributed by rathbhupendra
