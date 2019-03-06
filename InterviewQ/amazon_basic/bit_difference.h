#ifndef BIT_DIFFERENCE_H_INCLUDED
#define BIT_DIFFERENCE_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/bit-difference/0
// count number of bits needed to be flipped to convert A to B.
// A= 10  = A  = 1001001
// B = 20 = B  = 0010101
// solution, xor the numbers and count number of set bits.
void mt()
{
    int t=0; cin >> t;
    while(t>0){
        t--;

        int a=0; int b=0;
        cin >> a >> b;
        int x=0;
        x = a^b;

        int sum=0;
        for(int i=0;i<10;i++){
            if((1<<i & x) != 0){sum++;}
        }
        cout << sum << endl;
    }
	return 0;
}

#endif // BIT_DIFFERENCE_H_INCLUDED
