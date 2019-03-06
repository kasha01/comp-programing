#ifndef FIND_2_REPEATING_ELEMENTS_IN_RANGE_H_INCLUDED
#define FIND_2_REPEATING_ELEMENTS_IN_RANGE_H_INCLUDED


// http://www.geeksforgeeks.org/?p=7953
// there are n elements in the array + 2 repeating. i.e. elements are 1,2,3,4,5 + 2,4 (repeating)
// the elements in the array are all in the range of 1-n (1-5). here sz=7; n=5;
void printRepeating()
{
  int arr[] = {1,2,3,2,4,5,4};
  int sz = sizeof(arr)/sizeof(arr[0]);

  int xx = arr[0]; /* Will hold xor of all elements */
  int set_bit_no;  /* Will have only single set bit of xx */
  int i;
  int n = sz - 2;
  int x = 0, y = 0;

  /* Get the xor of all elements in arr[] and {1, 2 .. n} */
  for(i = 1; i < sz; i++)
    xx ^= arr[i];

// xx now = all elements - repeated elements (since xoring similar elements cancel each other)
// so xx here will have the same value of 1^3^5
// Now xor xx with the range of elements (n), this will leave me with the two repeating elements
// because original xx was the non-repeating elements (1,3,5). now when i xor it with the range of elements
// 1,2,3,4,5...this will cancel the non-repeating elements and leave me with the repeated elements mashed
// together in one value i.e 2^4.
  for(i = 1; i <= n; i++)
    xx ^= i;

// now xx = 2^4;

  /* Get the rightmost set bit in set_bit_no */
  set_bit_no = xx & ~(xx-1);  // or I can do xx & (-xx)

  /* Now divide elements of the array in two sets by comparing rightmost set
   bit of xx with bit at same position in each element. */
  for(i = 0; i < sz; i++)
  {
    if(arr[i] & set_bit_no)
      x = x ^ arr[i]; /*x = elements in arr[] where the set_bit is set [2,2,3]*/
    else
      y = y ^ arr[i]; /*y = elements in arr[] where the set_bit is not set [1,4,4,5] */
  }

// now here is the trick, I go through the range of elements and I xor them with my X,Y sets
// so I will have [2,2,3] xored with [2,3] this will leave me 2 which is one of the dups
// and for Y set (set_bit is not set) [1,4,4,5] will be xored with [1,4,5] leaving me 4. the other dup
  for(i = 1; i <= n; i++)
  {
    if(i & set_bit_no)
      x = x ^ i; /*XOR of first set in arr[] and {1, 2, ...n }*/
    else
      y = y ^ i; /*XOR of second set in arr[] and {1, 2, ...n } */
  }

  printf("n The two repeating elements are %d & %d ", x, y);
}


// this method works if I have more than 2 repeating elements. does NOT work if element = 0
// O(N) O(1) space
void printRepeating_el(int arr[], int size)
{
  int i;
  printf("The repeating elements are: \n");
  for (i = 0; i < size; i++)
  {
    if (arr[abs(arr[i])] >= 0)
      arr[abs(arr[i])] = -arr[abs(arr[i])];
    else
      printf(" %d ", abs(arr[i]));
  }
}

#endif // FIND_2_REPEATING_ELEMENTS_IN_RANGE_H_INCLUDED
