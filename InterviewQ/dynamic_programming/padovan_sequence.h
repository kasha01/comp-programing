#ifndef PADOVAN_SEQUENCE_H_INCLUDED
#define PADOVAN_SEQUENCE_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/padovan-sequence/0

int meme[4];
int dp2(int n){

    if(n<=2){return 1;}
    meme[0] = 1;
    meme[1] = 1;
    meme[2] = 1;
    meme[3] = 0;

    for(int i=3;i<=n;i++){
        meme[3] = (meme[0] + meme[1]) % 1000000007;
        meme[0] = meme[1];
        meme[1] = meme[2];
        meme[2] = meme[3];
    }
    return meme[3];
}


#endif // PADOVAN_SEQUENCE_H_INCLUDED
