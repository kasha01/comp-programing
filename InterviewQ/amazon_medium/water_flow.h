#ifndef WATER_FLOW_H_INCLUDED
#define WATER_FLOW_H_INCLUDED


/*
if we flag Pascal Triangle into an array, it will be like 0,1,2,3,4,5,6,7,8,9 -->
1st row = [0]
2nd row = [1],[2]
3rd row = [3][4],[5]
4th row = [6],[7],[8],[9]

notice how, [0] glass, floods to [1][2] glasses, [1] glass floods to glasses [3],[4]
this is the skip value. notice how [1][2] glasses are fed from row 1 (index 0) with skip=0 from index[0]
, glasses [3][4] are feed from glass [1] with skip = 1 (x+skip+1) and so on
*/

/*There is a stack of water glasses in a form of pascal triangle and a person wants to pour the water at
the topmost glass, but the capacity of each glass is 1 unit . Overflow takes place in such a way that
after 1 unit, 1/2 of remaining unit gets into bottom left glass and other half in bottom right glass.*/
// https://practice.geeksforgeeks.org/problems/champagne-overflow/0
void mt(double k, int R, int C){

    if(k<1){return;}

    map<int,int> mp;
    vector<double> vec;
    vec.push_back(k);
    mp[0]=1;

    int r=1; int c=1; int x=0; //x:marks the index starting the row in Pascal Triangle.
    while(r<R){
        int skip = r-1; // skip is the amount to skip for each index in the array to the next row
        mp[r + 1] = x + skip + 1;   // map: key: row in pascal triangle; value: index of array marking beginning of row

        // feeding/flowing to r+1
        for(int i=0;i<c;i++){

            if(x+skip+1 > vec.size() - 1){
                vec.push_back(0);
            }
            if(x+skip+2 > vec.size() - 1){
                vec.push_back(0);
            }

            if (vec[x] >= 1)
            {
                vec[x + skip + 1] = vec[x + skip + 1] + (vec[x] - 1) / 2;
                vec[x + skip + 2] = vec[x + skip + 2] + (vec[x] - 1) / 2;
            }

            x++;
        }
        r++;
        c++;
    }

    double r1 = min(vec[mp[R] + C - 1], 1.000000);

    cout << fixed << setprecision(6) << r1;
}


#endif // WATER_FLOW_H_INCLUDED
