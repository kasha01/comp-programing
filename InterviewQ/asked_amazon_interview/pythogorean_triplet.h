#ifndef PYTHOGOREAN_TRIPLET_H_INCLUDED
#define PYTHOGOREAN_TRIPLET_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/pythagorean-triplet/0
// find if there are 3 elements in array satisfy a^2 + b^2 = c^2

bool isTriplet(int arr[], int n)
{
    // Square array elements
    for (int i=0; i<n; i++)
        arr[i] = arr[i]*arr[i];

    // Sort array elements
    sort(arr, arr + n);

    // Now fix one element one by one and find the other two
    // elements
    for (int i = n-1; i >= 2; i--)
    {
        // To find the other two elements, start two index
        // and move the indexes according to result if larger or smaller than the desired result
        int l = 0; // index of the first element in arr[0..i-1]
        int r = i-1; // index of the last element in arr[0..i-1]
        while (l < r)
        {
            // A triplet found
            if (arr[l] + arr[r] == arr[i])
                return true;

            // Else either move 'l' or 'r'
            (arr[l] + arr[r] < arr[i])?  l++: r--;
        }
    }

    // If we reach here, then no triplet found
    return false;
}

#endif // PYTHOGOREAN_TRIPLET_H_INCLUDED
