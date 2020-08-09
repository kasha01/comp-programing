#ifndef REARRANGE_CHARACTERS_H_INCLUDED
#define REARRANGE_CHARACTERS_H_INCLUDED

// if characters can be rearranged to have no adjacent characters, print 1

// https://practice.geeksforgeeks.org/problems/rearrange-characters/0

void mt(){

    string s = "b";

    int z = s.length();
    int arr[26];
    memset(arr,0,26*sizeof(int));

    for(int i=0;i<z;i++){
        char c = s[i];
        int j = c-'a';
        arr[j] = arr[j] + 1;
    }

    char myc='\0';
    int mx=-1;
    for(int i=0;i<26;i++){
        if(mx<arr[i]){
            mx=arr[i];
            myc = i+'a';
        }
    }

    bool result = false;
    if(z%2 == 0){
        result = mx<=z/2;
    }
    else{
        result = mx<=(z/2)+1;
    }

    cout << result;
}

#endif // REARRANGE_CHARACTERS_H_INCLUDED
