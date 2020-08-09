#ifndef TIC_TAC_TOE_H_INCLUDED
#define TIC_TAC_TOE_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/tic-tac-toe/0

// NOT COMPLETE - IT FAILS ON THE EXAMPLE INPUT BELOW.
void pp(char c, pair<char,int> &p){
    char myc = p.first;
    char mycount = p.second;

    if(mycount == 0){
        // empty
        p = make_pair(c,1);
    }
    else if(myc == 'z'){
        return;
    }
    else{
        if(myc != c){
            // a different character already exists in the vertical. it is useless
            p.first = 'z';  // mark it as useless
        }
        else{
            p.second = mycount + 1;
        }
    }
}

void countwins(pair<char,int> p, int &xwins, int &owins){
    char myc = p.first;
    char mycount = p.second;

    if(myc == 'X' && mycount == 3){
        xwins = xwins + 1;
    }
    else if(myc == 'O' && mycount == 3){
        owins = owins + 1;
    }
}

void mt(){

    char arr[] = {'X','X','X','O','O','X','O','O','X'};
    int n = 9;
    pair<char,int> h1;
    pair<char,int> h2;
    pair<char,int> h3;

    pair<char,int> v1;
    pair<char,int> v2;
    pair<char,int> v3;

    pair<char,int> d1;
    pair<char,int> d2;

    int xcount=0; int ocount=0;
    int r=0; int c=0;
    for(int i=0;i<n;i++){
        if(arr[i] == 'X'){
            xcount++;
        }else{
            ocount++;
        }

        switch ((i+1)%3){
        case 0:
            // third column
            c=3;
            break;
        case 2:
            // second column
            c=2;
            break;
        case 1:
            // first column
            c=1;
            break;
        }

        switch (i/3){
        case 0:
            // first row
            r=1;
            break;
        case 1:
            // second row
            r=2;
            break;
        case 2:
            // third row
            r=3;
            break;
        }

        if(r==1){
            //h1
            pp(arr[i],h1);
        }
        else if(r==2){
            // h2
            pp(arr[i],h2);
        }
        else if(r==3){
            // h3
            pp(arr[i],h3);
        }

        if(c==1){
            //v1
            pp(arr[i],v1);
        }
        else if(c==2){
            // v2
            pp(arr[i],v2);
        }
        else if(c==3){
            // v3
            pp(arr[i],v3);
        }

        if(r==c){
            pp(arr[i],d1);
        }

        if(r+c == 4){
            pp(arr[i],d2);
        }
    }

    // validation
    bool flag = true;
    if(xcount != ocount && xcount != ocount+1){
        flag = false;
        cout << flag << endl;
    }

    int xwins=0; int owins=0;

    countwins(h1,xwins,owins);
    countwins(h2,xwins,owins);
    countwins(h3,xwins,owins);
    countwins(v1,xwins,owins);
    countwins(v2,xwins,owins);
    countwins(v3,xwins,owins);
    countwins(d1,xwins,owins);
    countwins(d2,xwins,owins);

    if(xwins == 0 && owins == 0 && xcount == ocount+1){
        // nobody won and game was over - it is a valid game
        flag = true;
    }
    else if((xwins>1) || (owins > 1) || (xwins == owins)){
        flag = false;
    }
    else if((owins == 1) && (xcount != ocount)){
        // if owins, then the counts of plays must be equal
        flag = false;
    }

    cout << flag;
}


#endif // TIC_TAC_TOE_H_INCLUDED
