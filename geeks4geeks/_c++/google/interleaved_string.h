#ifndef INTERLEAVED_STRING_H_INCLUDED
#define INTERLEAVED_STRING_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/interleaved-strings/1
// A string is interleaved if it ONLY has all the chars of A and B in order
// A=X  B=XY    C=XXY   ==> interleaved
// A=X  B=YX    C=XXY   ==> Not interleaved
// A=X  B=XY    C=XY   ==>  Not interleaved
// A=X  B=XY    C=XXAY   ==> Not interleaved

bool dp(int i, int x, int y, string A, string B, string C){
    if(i>=C.length()){
        return true;
        // I reached the end of my string C. all C chars were consumed. return true. End of Program, remember
        // i only moves if either x or y moves, so by i reaching C length that means I have all chars matched
        // thus return true.
    }

    if((x<A.length() && C[i]==A[x]) && (y<B.length() && C[i]==B[y])){
        if(dp(i+1,x+1,y,A,B,C)){
            return true;
        }
        else if(dp(i+1,x,y+1,A,B,C)){
            return true;
        }
        else{
            return false;
        }
    }
    else if(x<A.length() && C[i]==A[x]){
        return dp(i+1,x+1,y,A,B,C);
    }
    else if(y<B.length() && C[i]==B[y]){
        return dp(i+1,x,y+1,A,B,C);
    }
    else {
        return false;
    }
}

#endif // INTERLEAVED_STRING_H_INCLUDED
