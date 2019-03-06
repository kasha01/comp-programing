#ifndef NUMBER_OF_WAYS_TO_REACH_SCORE_H_INCLUDED
#define NUMBER_OF_WAYS_TO_REACH_SCORE_H_INCLUDED

// http://www.geeksforgeeks.org/count-number-ways-reach-given-score-game/

// Not optimized - return all possible combination (order matters)
// for n=13 ==> {3,5,5} {5,3,5} {5,5,3} {3,10} {10,3} ==> That is 5
int dpp(int x, int n){
    if(x==n){return 1;}
    if(x>n){return 0;}
    return dpp(x+3,n) + dpp(x+5,n) + dpp(x+10,n);
}

// Solution to question - Order does not matter - bottom up - O(3n) O(n^2) space. can easily be O(n) space as below more generic solution
int dp(int n){
    int score[3] = {3,5,10}; int scoreCount = 3;
    if(n<3){return 0;}
    int arr[n+1][scoreCount+1];
    for(int i=0;i<=n;i++){
        arr[i][0]=0;
    }
    arr[0][0]=0;arr[0][1]=1;arr[0][2]=1;arr[0][3]=1;

    for(int i=1;i<=n;i++){
        for(int j=1; j<=3;j++){
            if((i-score[j-1])<0){
                arr[i][j] = arr[i][j-1];
            }
            else{
                int mynum = score[j-1];
                arr[i][j] = arr[i-mynum][j] + arr[i][j-1];
            }
        }
    }
    return arr[n][scoreCount];
}

// Solution to question - bottom up - more generic - if scores are not necessarily 3,5,10 O(nm) O(n) space
int dp2(int n, int scoreCount, int* score){

    if(n<=0){return 0;}

    int arr[n+1];
    for(int i=0;i<=n;i++){
        arr[i]=0;
    }
    arr[0]=1;

    for(int i=0; i<scoreCount;i++){
        for(int j=1;j<=n;j++){
            if(j-score[i]<0){
                //do nothing
            }
            else {
                arr[j]=arr[j] + arr[j-score[i]];
            }
        }
    }
    return arr[n];
};

void driver(){
    int n=13;
    int rr = dpp(0,n);
    cout << rr << endl;
    int scoreCount = 3;
    int score[scoreCount] = {5,3,10};
    int res = dp2(n,scoreCount,score);
    cout << res;
}
#endif // NUMBER_OF_WAYS_TO_REACH_SCORE_H_INCLUDED
