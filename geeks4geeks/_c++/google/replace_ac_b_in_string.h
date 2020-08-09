#ifndef REPLACE_AC_B_IN_STRING_H_INCLUDED
#define REPLACE_AC_B_IN_STRING_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/remove-b-and-ac-from-a-given-string/0
// only loop through the string once
void driver()
{
    string s = "aababc";
    int l = s.length();

    // i is a pointer to each char in the string
    // j is a pointer of what to print of the string, notice, j only increments when there is a valid character
    // so invalid char ('ac' or 'b') are getting skipped as j doesn't increment.
    int i=0;int j=0;
    while(i<l){
        if(s[i]=='b'){
            i++;
        }
        else if(s[i]=='a' && i+1<l && s[i+1]=='c'){
            i=i+2;
        }
        else{
            s[j]=s[i];
            i++;
            j++;
        }
    }
    cout << s.substr(0,j);
    return 0;
}


#endif // REPLACE_AC_B_IN_STRING_H_INCLUDED
