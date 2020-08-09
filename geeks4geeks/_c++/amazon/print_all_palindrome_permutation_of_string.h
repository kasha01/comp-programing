#ifndef PRINT_ALL_PALINDROME_PERMUTATION_OF_STRING_H_INCLUDED
#define PRINT_ALL_PALINDROME_PERMUTATION_OF_STRING_H_INCLUDED

// http://www.geeksforgeeks.org/print-all-palindrome-permutations-of-a-string/
//Input:  str = "aabcb"
//Output: abcba bacab

bool isPalin(string str, int* freq)
{
    /* Initialising frequency array with all zeros */
    memset(freq, 0, M * sizeof(int));
    int l = str.length();

    // update letters count. if letter is a -> freq[str[i]-'a'] = freq[a-a]=freq[0]
    // so freq[0] is for letter a, freq[1] is for letter b and so on...nice trick
    for (int i = 0; i < l; i++)
        freq[str[i] - 'a']++;

    int odd = 0;

    /* Loop to count total letter with odd frequency */
    for (int i = 0; i < M; i++)
        if (freq[i] % 2 == 1)
            odd++;

    /* Palindrome condition :
    if length is odd then only one letter's frequency must be odd
    if length is even, then no letter should have odd frequency */
    if ((l % 2 == 1 && odd == 1 ) || (l %2 == 0 && odd == 0))
        return true;
    else
        return false;
}

/* Utility function to reverse a string */
string reverse(string str)
{
    string rev = str;
    reverse(rev.begin(), rev.end());
    return rev;
}

/* Function to print all possible palindromes by letter of
    given string */
void printAllPossiblePalindromes(string str)
{
    int freq[M];

    // checking whether input string can make palindrome or not
    if (!isPalin(str, freq))
        return;

    int l = str.length();

    // half will contain half part of all palindromes,
    // that is why pushing half freq of each letter
    string half = "";
    char oddC;
    for (int i = 0; i < M; i++)
    {
        /* find the one odd letter, I can only have 1 odd letter for str to be palindormized */
        if(freq[i] % 2 == 1)
            oddC = i + 'a';     // the letter is the freq index + 'a'. if it is index 0 then the letter is simply a
                                // if letter with odd count is at index=2, then the letter is 2+'a' = c.

        half += string(freq[i] / 2, i + 'a'); // half is all the letters with even count(sorted ascendingly)
                    // it must be sorted ascendingly for the next_permutation method to work.
                    // for str=abbdda -> half=abd
    }

    /* palin will store the possible palindromes one by one */
    string palin;

    // Now looping through all permutation of half, and adding
    // reverse part at end.
    // if length is odd, then pushing oddCharacter also in mid
    do
    {
        palin = half;
        if (l % 2 == 1)
            palin += oddC;  // add odd letter to half (if existed)
        palin += reverse(half); // rever half and add
        cout << palin << endl;
    }
    while (next_permutation(half.begin(), half.end())); // find the next permutation of the half
}
// str=ababc -> half=ab | oddC = c
// permutations:
// ab+c+ba = abcba
// ba+c+ab = bacab


/******************************************************************************************************/
// Find all the combinations of size k of a word which are also palindromes?
// Solution:
// Find all the combinations of EVEN count chars
// Get the permutations of each one of these combination
// a) match each permutation with its reverse
// b) match each permutation + each odd character + permutation reverse

// Example: aabb
// Combination of EVEN count chars {a,b} is: {a}, {b}, {ab}
// permutation of each combination are: a,b,ab,ba
// a) match each permutation with its reverse. aa, bb, abba, baab
// b) no odd char. skip
// solutions are: aa,bb,abba,baab

// Example2: aabc
// Combination of EVEN count chars {a} is: {a}
// permutation of each combination are: a
// a) match each permutation with its reverse. aa
// b) match each permutation with each odd char: aba, aca
// solution: aa,aba,aca
//(you can also include each single char in the solution is a palindrome)

#endif // PRINT_ALL_PALINDROME_PERMUTATION_OF_STRING_H_INCLUDED
