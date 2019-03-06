#ifndef NUMBERS_TO_WORDS_H_INCLUDED
#define NUMBERS_TO_WORDS_H_INCLUDED


void mt()
{
    vector<string> vec = {"one","two","three","four","five","six","seven","eight","nine"};


    int a1=0; int a2=0; int a3=0; int a4=0;
    int n = 2000;
    int c=0;
    while(n>0){
        c++;
        int m = n%10;
        n = n/10;

        switch(c){
        case 1:
            a1=m;
            break;
        case 2:
            a2=m;
            break;
        case 3:
            a3=m;
            break;
        case 4:
            a4=m;
            break;
        }
    }

    string num="";

    if(a4>0){
        num = vec[a4-1] + " thousand ";
    }
    if(a3>0){
        num = num + vec[a3-1] + " hundred ";
    }

    if(!(num == "" || (a2==0 && a1==0))){
        num = num + "and ";
    }

    if(a2 == 1){
        switch(a1){
        case 0:
            num = num + "ten";
            break;
        case 1:
            num = num + "eleven";
            break;
        case 2:
            num = num + "twelve";
            break;
        case 3:
            num = num + "thirteen";
            break;
        case 4:
            num = num + "fourteen";
            break;
        case 5:
            num = num + "fifteen";
            break;
        case 6:
            num = num + "sixteen";
            break;
        case 7:
            num = num + "seventeen";
            break;
        case 8:
            num = num + "eighteen";
            break;
        case 9:
            num = num + "nineteen";
            break;
        }
    }
    else if(a2 > 1){
        switch(a2){
        case 2:
            num = num + "twenty ";
            break;
        case 3:
            num = num + "thirty ";
            break;
        case 4:
            num = num + "forty ";
            break;
        case 5:
            num = num + "fifty ";
            break;
        case 6:
            num = num + "sixty ";
            break;
        case 7:
            num = num + "seventy ";
            break;
        case 8:
            num = num + "eighty ";
            break;
        case 9:
            num = num + "ninety ";
            break;
        }
    }

    if((a2==0 || a2 > 1)&& a1>0){
        num = num + vec[a1-1];
    }

    cout << num << endl;

}


#endif // NUMBERS_TO_WORDS_H_INCLUDED
