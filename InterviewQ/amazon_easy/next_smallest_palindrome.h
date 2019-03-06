#ifndef NEXT_SMALLEST_PALINDROME_H_INCLUDED
#define NEXT_SMALLEST_PALINDROME_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/next-smallest-palindrome/0
// find the palindrome number that is next smallest to the given number
// ex  9 4 1 8 7 9 7 8 3 2 2 ->  9 4 1 8 8 0 8 8 1 4 9
bool increment_pivot(vector<int>& vec, int pivot, int n){

    bool carry = false;
    if(vec[pivot] == 9){
        vec[pivot]=0;
        carry = true;
        pivot++;
    }
    else{
        vec[pivot]++;
        return 0;
    }

    while(pivot<n){
        if(carry && vec[pivot] != 9){
            vec[pivot]++;
            carry = false;
            break;
        }
        else if(carry && vec[pivot] == 9){
            vec[pivot]=0;
            pivot++;
        }
        else{
            break;
        }
    }
    return carry;
}

void solve(vector<int>& vec, int n){
    int pivot = (n-1)/2;
    if(n%2==0){pivot++;}

    bool palindrome_satisfied=false;

    // split half vecay and copy
    for(int i=pivot-1;i>=0;--i){
        int orig_item = vec[i];
        int mirror_item = vec[n-i-1];
        if(mirror_item< orig_item && !palindrome_satisfied){
            // Go to increment pivot logic
            break;
        }
        else if(mirror_item > orig_item && !palindrome_satisfied){
            vec[i] = vec[n-i-1];
            palindrome_satisfied = true;
        }
        else if(palindrome_satisfied){
            vec[i] = vec[n-i-1];
        }
    }

    if(!palindrome_satisfied){
        // increment pivot logic
        bool carry = increment_pivot(vec,pivot,n);

        if(carry){
            vec.push_back(1);
            n++;
        }

        // done incrementing pivot - now just mirror the number
        int pivot = (n-1)/2;
        if(n%2==0){pivot++;}
        for(int i=pivot-1;i>=0;--i){
            vec[i] = vec[n-i-1];
        }
    }

    for(int i=n-1; i>=0;--i){
        cout << vec[i] << " ";
    }
    cout << endl;
}

void test()
{
    vector<int> vec = {9,9};
    int n=vec.size();
    std::reverse(vec.begin(), vec.end());   // single digit is at index [0], multiples are on [1,2,3..]
    solve(vec,n);
}

#endif // NEXT_SMALLEST_PALINDROME_H_INCLUDED
