#ifndef MIN_ROPE_COST_H_INCLUDED
#define MIN_ROPE_COST_H_INCLUDED


// https://practice.geeksforgeeks.org/problems/minimum-cost-of-ropes/0
// The cost to connect two ropes is equal to sum of their lengths.
// total cost is the summation of all connections costs
void mt(){

    int n=0; int x=0;

    vector<int> vec= {468,335,1,170,225,479,359,463,465,206,146,282,328,462,492,496,443,328,437,392,105,403,154,293,383,422,217,219,396,448,227,272,39,370,413,168,300,36,395,204,312,323};

    std::priority_queue<int, std::vector<int>, std::greater<int>>pq(vec.begin(), vec.end());

    int grantsum=0;
    int sum=0;
    while(!pq.empty()){
        int i1 = pq.top();
        pq.pop();
        int i2 = pq.top();
        pq.pop();
        sum = i1+i2;
        grantsum = grantsum + sum;
        if(pq.empty()){break;}
        pq.push(sum);
    }

    cout << grantsum;

}

#endif // MIN_ROPE_COST_H_INCLUDED
