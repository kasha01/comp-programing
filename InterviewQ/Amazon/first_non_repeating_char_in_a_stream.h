#ifndef FIRST_NON_REPEATING_CHAR_IN_A_STREAM_H_INCLUDED
#define FIRST_NON_REPEATING_CHAR_IN_A_STREAM_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/first-non-repeating-character-in-a-stream/0

// a much easier solution is, put all letters counts and index where it was first found
// in a map. then loop through the map, the letter with count =1 and min. index is the solution
void first_non_repeating_char_in_a_stream(){
    int t = 0;
    cin >> t;
    map<char,int> mp; queue<char> qu;
    while(t>0){
        t--;
        mp.clear(); std::queue<char>().swap(qu);
        int n = 0; cin >> n;
        char x = '\0';

        for(int i=0; i<n;i++){
            cin >> x;
            if(mp.find(x)!=mp.end()){
                mp[x]++;
                // found - if queue head is found in map --> it means it is a dup --> keep poping till Q is empty or not found in map
                while(!qu.empty() && mp.find(qu.front()) != mp.end() && mp[qu.front()] > 1){
                    qu.pop();
                }
                if(qu.empty()){cout << -1 << " ";}
                else {cout << qu.front() << " ";}

            }else{
                // not found - add to queue - print Q head
                mp[x] = 1; qu.push(x);
                cout << qu.front() << " ";
            }
        }
        cout << endl;
    }
}

#endif // FIRST_NON_REPEATING_CHAR_IN_A_STREAM_H_INCLUDED
