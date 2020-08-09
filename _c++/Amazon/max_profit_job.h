#ifndef MAX_PROFIT_JOB_H_INCLUDED
#define MAX_PROFIT_JOB_H_INCLUDED

// http://www.geeksforgeeks.org/weighted-job-scheduling/
int jobs[4][3] = {
                {1,2,50},
                {3,5,20},
                {6,19,100},
                {2,100,200}
              };
int table[4];

// top down solution - check geeks, it has a better solution
int dp(int s, int f, int cost, int& c){
    int temp = 0; c++;
    for(int i=0; i<4; i++){
        if(jobs[i][0] >= f){
            if(table[i]==-1){table[i] = dp(jobs[i][0], jobs[i][1], jobs[i][2], c);}
            temp = max(temp,table[i]);
        }
    }
    return temp + cost;
};

// top down - not optimized solution
int dp2(int s, int f, int cost, int& c){
    int temp = 0; c++;
    for(int i=0; i<4; i++){
        if(jobs[i][0] >= f){
            temp = max(temp,dp2(jobs[i][0], jobs[i][1], jobs[i][2], c));
        }
    }
    return temp + cost;
}

void driver()
{
    for(int i=0; i<4;i++){table[i]=-1;}
    int cost = 0; int c=0;
    for(int i=0;i<4;i++){
        c++;
        cost = max(cost, dp(jobs[i][0], jobs[i][1], jobs[i][2],c));
    }
    cout << cost << " " << c;
}


#endif // MAX_PROFIT_JOB_H_INCLUDED
