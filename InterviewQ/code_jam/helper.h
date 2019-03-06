#ifndef HELPER_H_INCLUDED
#define HELPER_H_INCLUDED

// calculate the powers of 2 till the yth power
void precompute(int* arr, int y){
    pre[0] = 1;
    for(int i=1;i<=y;i++){
		pre[i] = pre[i-1] * 2;
    }
}


#endif // HELPER_H_INCLUDED
