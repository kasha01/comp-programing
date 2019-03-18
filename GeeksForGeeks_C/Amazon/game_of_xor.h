#ifndef GAME_OF_XOR_H_INCLUDED
#define GAME_OF_XOR_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/game-of-xor/0

// deducting from noticing the sub array output.
// subarray is contiguous parts of the array {1,2,3} => {1}, {2}, {3}, {1,2}, {2,3}, {1,2,3}
// subset is not necessarily contiguous ==> {1}, {2}, {3}, {1,2}, {2,3}, {1,2,3}, {1,3}
void game_of_xor1(){
    int c = 0; int xor_sum=0;
    cin >> c; int num = 0;
    if(c%2==0){
        // if count of array is even
        cout << 0 << endl;
    }
    else{
        // if count of array is odd
        for(int i=0; i<c ; i++){
            cin >> num;
            if(i%2 == 0){
                // choose alternating index: 0,2,4,6..etc
                xor_sum = xor_sum ^ num;
            }
        }
        cout << xor_sum << endl;
    }
}

void game_of_xor(){
    int t = 0;
    cin >> t;
    while(t>0){
        t--;
        int c = 0; int xor_sum=0;
        cin >> c; int num = 0;
        for(int i=0; i<c ; i++){
            cin >> num;
            if(((c-i)*(i+1))%2 != 0){
                // odd
                xor_sum = xor_sum ^ num;
            }
        }
        cout << xor_sum << endl;
    }
}


#endif // GAME_OF_XOR_H_INCLUDED
