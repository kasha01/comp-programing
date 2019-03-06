#ifndef MODULAR_POWER_MOD_H_INCLUDED
#define MODULAR_POWER_MOD_H_INCLUDED

/* Iterative Function to calculate (x^y)%p in O(log y) - see road trip note book for further notes
it is useful specifically in RSA and encryption to calc product/power of large numbers */
int power(int x, unsigned int y, int p)
{
    int res = 1;      // Initialize result

    x = x % p;  // Update x if it is more than or equal to p - can be ommitted. as I said in notes
                // for mathemeticians 12%10=2 ==> 2 and 12 are identical. Modulo is nothing but a cycle or a numerical system
                // also notice any operation done on x % p yields the same result
                // (x*k)%p = (x%p * k%p)%p ==> so whether x=2,12,22,32...etc (assuming mod10) will all yields the same result
                // (2*7)%10 = (12*7)%10 ==>2%10 * 7%10 = 12%10 * 7%10.

    while (y > 0)
    {
        // If y is odd, multiply x with result
        if (y & 1)
            res = (res*x) % p;  // this is step 3. combine the final result/sub_result and apply modulo

        y = y>>1;       // y = y/2
        x = (x*x) % p;  // this is step 2, as I am decreasing y by half, x (the base)is getting squared and then modulo
                        // this is like doing (5^2)%19, (5^4)%19...etc.
    }
    return res;
};


/*
this is used to prevent overflow in case a,b,m are too big, so we are using long double which has more range than int, although we will
run into a percision issue which will be addressed later.
What are we doing here?
take modulo of a, taking modulo of b.
c is ==> (ab) div m
ab/m => in long division it will be apparent that
c=ab div m (approx.)
remainder = ab-cm = which is ab%m

Now it is good to mention:
long double * int => the int will implicity converted into a long double and the multiplication result will be long double
long double / int => the int will implicity converted into a long double and the division result will be long double
So x*b will 'most likely' not result in an overflow b/c of implict conversion to long double
x*b/m will 'most likely' not result in an overflow b/c of implict conversion to long double

Here is the problem, as we convert the result to c which is an integer, compiler may do a round which will result in inaccurate result.
I have to get c as int because that is what ab%m is..an int always duh.

So how I resolve this problem...well, In floating mulitplication, "the relative error is always bounded by the machine epsilon
which the maximum error that can occur when rounding to the unit value (1)" in other words the error margin of rounding cannot exceed 1,
which makes tons of sense in elementary math too. 79.9999 can either be approx to 80 or 79...most wild error is 1.

if I say d=ab div m (d is the accurate result) Then => ab-dm => accurately equals ab%m
I also have c (the rounded result of ab div m "ab/m") can either be equal to:
d => accurate ==> d = c => r = ab-cm
d-1 or d+1 => the most inaccurate.

if c is accurate, then (ab-cm) is the accurate result to ab%m.
taking modulo of the result will change nothing...as modulo is a cycle => r = (ab-cm)%m = (ab%m)%m = ab%m

if c is not accurate => c = d-1 => ab -(d-1)m => ab-dm+m.....here comes the use of module m to r
here I have the result has a +m difference from the accurate, so when I do a modulo of m r=(ab-cm) % m, I am going one cycle of m down and
this gets me the right result.

Now if c is => d+1...here it comes the use of the last line
ab-cm => ab-(d+1)m => ab-dm-m => I have -m difference from the accurate result. of course a module will decrease the cycle by m which will
keep things the same. so what I do is I add +m (r+m) in the last line. notice ab-dm-m will be negative. as the remainder (ab-dm) cannot be
greater than the divider m.
*/
// calc (ab) mod m
uint64_t mul_mod(uint64_t a, uint64_t b, uint64_t m)
{
   long double x;
   uint64_t c;
   int64_t r;
   if (a >= m) a %= m;
   if (b >= m) b %= m;
   x = a;
   c = x * b / m;
   r = (int64_t)(a * b - c * m) % (int64_t)m;
   return r < 0 ? r + m : r;
};

// calc (a^b) mod m - uses the above method to calc (ab) mod m
uint64_t pow_mod(uint64_t a, uint64_t b, uint64_t m)
{
    uint64_t r = 1;
    while (b > 0) {
        if(b % 2 == 1)
            r = mul_mod(r, a, m);
        b = b >> 1;
        a = mul_mod(a, a, m);
    }
    return r;
};

///////////////////////////////////////////////////////////////////////////////////////////////////////
// Simple power - no modulo
// O(log n) x^y (recurssive)
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
}

// O(log n) x^y -works with negative y
float power(float x, int y)
{
    float temp;
    if( y == 0)
       return 1;
    temp = power(x, y/2);  // decrease power by two and square
    if (y%2 == 0)
        return temp*temp;
    else
    {
        if(y > 0)
            return x*temp*temp; // power was descrease by 2, so square(x) * x, since y is odd
        else
            return (temp*temp)/x;   // if y was -ve, 2^-1 = 1/2. so I divide by x=2. notice temp always returned
            // to me as the correct inverse of x squared
    }
}

void calc_pow_driver(){
    cout << power(2,5,13) << endl;
    cout << pow_mod(2,5,13) << endl;
}

#endif // MODULAR_POWER_MOD_H_INCLUDED
