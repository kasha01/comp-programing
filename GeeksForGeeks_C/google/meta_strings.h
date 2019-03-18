#ifndef META_STRINGS_H_INCLUDED
#define META_STRINGS_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/meta-strings/0
// Meta strings are the strings which can be made equal by exactly one swap in any of the strings.
// Equal string are not considered here as Meta strings.
int mt(string s1, string s2){
    int l1 = s1.length(); int l2=s2.length();

    if(l1!=l2){return 0;}

    bool res = false;
    char a; char b; int t = 1;
    for(int i=0; i< l1; i++){
        if(s1[i] != s2[i] && t==1){
            // first time
            a=s1[i]; b=s2[i]; t++;
        }
        else if(s1[i] != s2[i] && t==2){
            // second time
            t++;
            if(a==s2[i] && b==s1[i]){
                res = true;
            }
        }
    }
    return res;
}

#endif // META_STRINGS_H_INCLUDED
