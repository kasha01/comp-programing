#ifndef MIN_JUMPS_H_INCLUDED
#define MIN_JUMPS_H_INCLUDED

int loop = 0;

int min_jumps(int* arr, int n){

    if(n == 0 || arr[0] == 0){
        return -1;
    }

    int jumps[n];

    int max_coverage = arr[0] + 0;
    int current_index = 0;
    jumps[0] = 0;
    int breakIndex = INT_MAX;

    while(arr[current_index] > 0 && max_coverage < n && current_index <n){

        int loopi=0;
        int old_max_cov = max_coverage;
        for(int i= current_index+1; i<=old_max_cov;i++){
            jumps[i] = 1 + jumps[current_index];
            loopi++;

            if(arr[i] + i> max_coverage ){
                max_coverage = arr[i] + i ;
            }
            if(max_coverage > n){breakIndex = i; break;}
        }
        current_index = min(old_max_cov,breakIndex);
        loop = loopi + loop + 1;
    }

    if(current_index + arr[current_index] > n){
        return jumps[current_index] + 1;
    }else{
        return -1;
    }
};

void min_jumps_driver()
{
    int arr[] = {1, 3, 6, 3, 2, 3, 6, 8, 9, 5};
    int sz = sizeof(arr)/sizeof(arr[0]);
    cout << min_jumps(arr, sz) << endl;
    cout << loop << endl;
}

#endif // MIN_JUMPS_H_INCLUDED
