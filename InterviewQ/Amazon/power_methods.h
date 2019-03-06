#ifndef POWER_METHODS_H_INCLUDED
#define POWER_METHODS_H_INCLUDED

/* Function to calculate x raised to the power y */
int power(int x, unsigned int y)
{
    if (y == 0)
        return 1;
    else if (y%2 == 0)
        return power(x, y/2)*power(x, y/2);
    else
        return x*power(x, y/2)*power(x, y/2);
};

/* Function to calculate x raised to the power y in O(logn)*/
/*
x^n:
if n is even ==> x^n = x^(n/2) * x^(n/2)
if n is odd ==> x^n = x * x^(n-1) ==> x * {(x^(n'/2) * x^(n'/2))} . n' being n-1 which is an even
*/
int power(int x, unsigned int y)
{
    int temp;
    if( y == 0)
        return 1;
    temp = power(x, y/2);
    if (y%2 == 0)
        return temp*temp;
    else
        return x*temp*temp;
};

/*
Remember: temp is the previous solution
x^-n:
if n is even ==> x^-n = x^(-n/2) * x^(-n/2). at the some point -n/2 will return -1 (-2/2=-1) which will make temp=1/x.
and temp will keep multiplying as 1/x * 1/x....n times.
if n is odd ==> x^-n = (1/x) * x^(-(n-1)) ==> (1/x) * {(x^(n'/2) * x^(n'/2))} . n' being -(n-1) which is an even
*/
float power(float x, int y)
{
    float temp;
    if( y == 0)
       return 1;
    temp = power(x, y/2);
    if (y%2 == 0)
        return temp*temp;
    else
    {
        if(y > 0)
            return x*temp*temp;
        else
            return (temp*temp)/x;
    }
};

/* Program to test function power */
void mypower_driver()
{
    int x = 2;
    unsigned int y = 3;

    printf("%d", power(x, y));
}

#endif // POWER_METHODS_H_INCLUDED
