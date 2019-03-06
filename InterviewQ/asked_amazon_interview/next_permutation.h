#ifndef NEXT_PERMUTATION_H_INCLUDED
#define NEXT_PERMUTATION_H_INCLUDED

// The whole idea is the permutation is considered as the numerical value of the vector.
// The first permutation is being the smallest value i.e. 123
// NOTE. VECTOR MUST BE SORTED ASCENDINGLY FOR THIS TO WORK
// then we try to find the next_permutation that is the permutation numercial value that is just greater than
// the one I have. (i.e. 132)
// To do that, we need to find (starting from right to left), the digit with the value that is in a large multiple
// but with a small value, to be replaced with the digit that is in the smallest multiple and with a value greater than
//mine, this increments the numerical value of the permutation by the slightest possible. 123 -> 132.
// notice, keeping the hundreds constant, replacing the tens with the single multiple.
// then we reverse the numbers from the replaced digit to the end (if possible), to ensure the smallest numerical value
// and so on, till we can't increment the numerical value anymore (all digits) are in descending order i.e. 321.
// this is our last permutation

//Notice the incremental
// 123 . initial
// 132
// 231 -> reverse from 3 onward = 213
// 231
// 321 -> reverse from 2 onward = 312
// 321
// END. no a[k] is larger than a[k+1]

template<typename It>
bool next_permutation(It begin, It end)
{
    // to detect empty vector (begin == end)
    if (begin == end)
            return false;

    It k = begin;
    ++k;
    // detect a vector of 1 item. just return false so we don't loop in the driver do-while
    if (k == end)
            return false;

    k = end;
    --k;    // k is the last item (for now)

    while (true)
    {
        It j = k;   // j is k+1
        --k;        // decrement k, till we get a k where a[k]<a[k+1]...notice ...0 3 2 1

        // find a[k] < a[k+1]...as long as j > k, that means my number is not in full desc. order.
        if (*k < *j)
        {
            It i = end;

            // find i>k and a[i] > a[k]..if not keep looping and decrement i
            // notice 2654, k<j will meet when k=2;j=6 (since j&k are j=k+1), however there are other numbers
            // that are larger than k besides j, that is why i need the i loop k=2; i=4..bam.
            while (!(*k < *--i))
                    /* pass */;

            iter_swap(k, i);
            reverse(j, end);    // reverse from k+1 to the end (all elements after k). we do a reverse b/c we know for
            // sure that all elements from k+1 onward are in descending order as *j>*k -> a[k+1]>a[k]
            // or like d > c > b > a ==> a[n-5] > a[n-4] > a[n-2] ...so on like 1974 since 7 > 4 and 9>7 then
            // 9 > 7 > 4..notice how we always compare for j>k, if not we shift j and k back to the right
            // also notice here, i cannot cross j, as j>k and i loops till i>k. so the most i can reach is j
            // and if that happens and j is not the first element, then reversing the number will restore me
            // to the next permutation as in 1974 -> 1479. or in case 231 where j=3;k=2 (j>k desc order ensured)
            // and i will reach to j=3 giving me 3 2 1 (swapping i=3 with k=2), so reversing it is 312
            // but in next permut. 312 (j>k j=2;k=1; so i can max go to j which is 2, in this case i is the first
            // element (i=2), reversing will do no harm --> swapping i,k (2,1) -> 321 reversing from j position
            // which is the first pos, will reverse 1 with itself, no harm and result remains as 321
            // I mean, when j is the firest element, reverse will do no work, another important note to notice
            // i can never exceeds j since my constraints are j>k and i>k so I can most reaches j.
            return true;
        }

        // if decrementing k reached the end of our vector, that means the permutation value has reached the
        // max (i.e. 321) all items are in descending order, this is our last permutation. stop
        if (k == begin)
        {
            // this reverse is just to keep the original input intact, it has no effect on the output if we
            // commented this line. it is only used to restore the input vector as it is manipulated by ref
            // (using iterators)
            reverse(begin, end);
            return false;
        }
    }
}


void driver()
{
    vector<int> v = {1,2,3};
    int n = v.size();
    do
    {
        // print the vector as is (1st premutation)
        for (int i = 0; i < n; i++)
        {
            cout << v[i] << " ";
        }
        cout << endl;
    }
    while (::next_permutation(v.begin(), v.end()));
}

#endif // NEXT_PERMUTATION_H_INCLUDED
