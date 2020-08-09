#ifndef SNAKE_AND_LADDER_H_INCLUDED
#define SNAKE_AND_LADDER_H_INCLUDED

// find minimum number of dice throws to reach end.
// https://practice.geeksforgeeks.org/problems/snake-and-ladder-problem/0
void mt(){

    int arr[30];
    for(int i=1;i<30;i++){
        arr[i] = INT_MAX;
    }
    arr[0]=0;

    map<int,int> ladders;
    map<int,int> snakes;

    vector<int> v = {2,30};
    int vv = 2;
    for(int i=0;i<vv;i=i+2){
        // decrement since I am using index not square number.
        int a=v[i]-1; int b=v[i+1]-1;
        if(a<b){
            // it is a ladder
            ladders[a]=b;
        }
        else{
            // it is a snake
            snakes[a]=b;
        }
    }

    for(int i=0;i<30;i++){
        if(ladders.find(i) != ladders.end()){
            // there is a ladder from me to another square.
            int ladderend = ladders[i];
            // the distance from me through the ladder to the other end is the same
            arr[ladderend] = min(arr[i],arr[ladderend]);
            continue;   // I continue b/c i have no option but to go up the ladder
        }
        else if(snakes.find(i) != snakes.end()){
            // there is a snake from me to another square.
            int snakeend = snakes[i];
            // the distance from me through the ladder to the other end is the same
            arr[snakeend] = min(arr[i],arr[snakeend]);
            continue;   // I continue b/c i have no option but to go down the snake
        }

        for(int j=i+1;j<=i+6 && j<30; j++){
            // adjacent
            arr[j] = min(arr[j],arr[i] + 1);
        }
    }

    cout << arr[29];

}

#endif // SNAKE_AND_LADDER_H_INCLUDED
