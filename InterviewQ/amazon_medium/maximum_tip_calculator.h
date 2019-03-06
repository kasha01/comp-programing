#ifndef MAXIMUM_TIP_CALCULATOR_H_INCLUDED
#define MAXIMUM_TIP_CALCULATOR_H_INCLUDED

// solution was NOT verified!!!!!!!!!!!!!!!!!
// https://practice.geeksforgeeks.org/problems/maximum-tip-calculator/0
int dp(int n, int x, int y, int*** meme, int* A, int* B){
    if(n<0){return 0;}
    int s1=0; int s2=0;
    if(meme[n][x][y] != -1){
        return meme[n][x][y];
    }

    if(x>0){
        s1 = A[n] + dp(n-1,x-1,y,meme,A,B);
    }
    if(y>0){
        s2= B[n] + dp(n-1,x,y-1,meme,A,B);
    }
    meme[n][x][y] = max(s1,s2);
    return meme[n][x][y];
}

int dp(int n, int x, int y, vector<vector<vector<int>>> &meme, int* A, int* B){
    if(n<0){return 0;}
    int s1=0; int s2=0;
    if(meme[n][x][y] != -1){
        return meme[n][x][y];
    }

    if(x>0){
        s1 = A[n] + dp(n-1,x-1,y,meme,A,B);
    }
    if(y>0){
        s2= B[n] + dp(n-1,x,y-1,meme,A,B);
    }
    meme[n][x][y] = max(s1,s2);
    return meme[n][x][y];
}

int main()
{
    int A[] = {1 ,4 ,3 ,2 ,7 ,5 ,9 ,6};
    int B[] = {1 ,2 ,3 ,6 ,5 ,4 ,9 ,8};

    int n=8; int x=4; int y=4;
    int*** meme = new int**[n];

    for(int i=0;i<n;i++){
        meme[i] = new int*[x+1];
        for(int j=0;j<=x;j++){
            meme[i][j] = new int[y+1];
            for(int k=0;k<=y;k++){
                meme[i][j][k] = -1;
            }
        }
    }

    int res = dp(n-1,x,y, meme,A,B);
    cout << res;

    for(int ii=0;ii<n;ii++){
        for(int jj=0;jj<=x;jj++){
            delete[] meme[ii][jj];
        }
        delete[] meme[ii];
    }
    delete[] meme;

    return 0;
}

#endif // MAXIMUM_TIP_CALCULATOR_H_INCLUDED
