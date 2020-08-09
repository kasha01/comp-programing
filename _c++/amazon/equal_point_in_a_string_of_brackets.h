#ifndef EQUAL_POINT_IN_A_STRING_OF_BRACKETS_H_INCLUDED
#define EQUAL_POINT_IN_A_STRING_OF_BRACKETS_H_INCLUDED

// A VERY ANNOYING QUESTION
// http://practice.geeksforgeeks.org/problems/find-equal-point-in-string-of-brackets/0
void equal_point_in_a_string_of_brackets(){

    int t=0; cin >> t;
    while(t>0){
     t--;
     string arr = ""; cin >> arr;
     int c = arr.length();
     // sj=counter of closing brackets
     // si=counter of opening brackets
     // i: left to right index
     // j: right to left index
     // Logic: the idea is to get si==sj, so if si>sj, I want more ')' so I keep moving index j
     // until I find a ')' and increment sj to equalize with si and vice versa of i,si.
     int i=0; int j = c-1; int si=0; int sj=0;
     while(i<=j && i<c && j>=0){
        if(si==sj){
                if(arr[i] == '('){si++; i++;}
                else if(arr[j] == ')'){sj++; j--;}
                else {i++;j--;}
        }
        else if(si>sj){
            if(arr[j] == ')'){sj++;}
            j--;
        }
        else if(sj>si){
            if(arr[i] == '('){si++;}
            i++;
        }
     }

    if(arr[j] == ')'){sj++;}
    if(arr[i] == '('){si++;}

    if(si>sj){cout << i-1 << endl;}
    else if(si == sj){cout << i << endl;}
    else if(sj > si){ cout << i+1 << endl;}
    }
}

#endif // EQUAL_POINT_IN_A_STRING_OF_BRACKETS_H_INCLUDED
