#ifndef IS_STRING_ROTATED_H_INCLUDED
#define IS_STRING_ROTATED_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/check-if-string-is-rotated-by-two-places/0
// Input : a = "amazon" |  b = "azonam"  // rotated anti-clockwise
bool loopstring(string a, string b, int ai, int bi, int al){
    for(int i=ai; i<al; i++){
        if(a[i] != b[bi]){
            return false;
        }
        bi=bi+1;
    }
    return true;
}

// main method
bool isrotated(string a, string b){

    int al = a.length();
    int bl = b.length();
    if(al != bl){
        return false;
    }

    if(a.substr(0,2) == b.substr(bl-2,2)){
        // counter clock wise
        return loopstring(a,b,2,0,al);
    }
    else if(a.substr(al-2,2) == b.substr(0,2)){
        return loopstring(a,b,0,2,al-2);
    }
    else{
        return false;
    }
}


/// are two strings rotation of each other (full rotation does not work)
// https://www.geeksforgeeks.org/a-program-to-check-if-strings-are-rotations-of-each-other/
// if strstr is using KMP, then time complexity is O(n1+n2)
int areRotations(char *str1, char *str2)
{
  int size1   = strlen(str1);
  int size2   = strlen(str2);
  char *temp;
  void *ptr;

  /* Check if sizes of two strings are same */
  if (size1 != size2)
     return 0;

  /* Create a temp string with value str1.str1 */
  temp   = (char *)malloc(sizeof(char)*(size1*2 + 1));
  temp[0] = '\0';
  strcat(temp, str1);
  strcat(temp, str1);

  /* Now check if str2 is a substring of temp */
  ptr = strstr(temp, str2);

  free(temp); // Free dynamically allocated memory

  /* strstr returns NULL if the second string is NOT a
    substring of first string */
  if (ptr != NULL)
    return 1;
  else
    return 0;
}


#endif // IS_STRING_ROTATED_H_INCLUDED
