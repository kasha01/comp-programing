#ifndef BETTING_GAME_H_INCLUDED
#define BETTING_GAME_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/betting-game/0
void mt(){
    string s = "WLWLLWLLWWLWWW";
    int sz = s.length();

    long long int sum=4; long long int b=1;
    for(int i=0;i<sz;++i){
        if(sum<0 || sum < b){sum = -1; break;} // sum < b is the tricky part as technically you cannot be

        // if your money is less than the bet
        char c = s[i];
        if(c=='W'){
            sum = sum + b;
            b=1;
        }
        else{
            sum = sum - b;
            b=2*b;
        }
    }

    cout << sum << endl;
}

#endif // BETTING_GAME_H_INCLUDED
