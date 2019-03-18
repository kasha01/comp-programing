#ifndef COUNT_NO_OF_SET_BITS_H_INCLUDED
#define COUNT_NO_OF_SET_BITS_H_INCLUDED

void mt(){
    int n=468;

    // get number of digits n has
    int dig_count=0; int nn=n;
    while(nn>0){
        dig_count++; nn=nn/2;
    }

    int sum=0; int b=0;
    for(int i=1;i<=n;i++){
        // generate all numbers from 1 to N
        for(int j=0;j<dig_count;j++){
            // count no of 1's in the number
            b = 1 << j;
            if((b&i)!=0){
                sum = sum + 1;
            }
        }
    }
    cout << sum;
}

#endif // COUNT_NO_OF_SET_BITS_H_INCLUDED
