# String Calculator Code Challenge

Click here to download and install the application: 

https://drive.google.com/drive/folders/1mrZYyzO9BD_HazxRpvaUCAM6I6V7rTDD?usp=sharing

## Summary

Create a calculator that only supports an Add operation given a single formatted string

C# console application

Include unit tests

## Requirements

1. Support a maximum of 2 numbers using a comma delimiter
   - examples: 20 will return 20; 1,5000 will return 5001
   - invalid/missing numbers should be converted to 0 e.g. "" will return 0; 5,tytyt will return 5
   
2. Support an unlimited number of numbers e.g. 1,2,3,4,5,6,7,8,9,10,11,12 will return 78

3. Support a newline character as an alternative delimiter e.g. 1\n2,3 will return 6

4. Deny negative numbers. An exception should be thrown that includes all of the negative numbers provided

5. Ignore any number greater than 1000 e.g. 2,1001,6 will return 8

6. Support 1 custom single character length delimiter
   - use the format: //{delimiter}\n{numbers} e.g. //;\n2;5 will return 7
   - all previous formats should also be supported
    
7. Support 1 custom delimiter of any length
    - use the format: //[{delimiter}]\n{numbers} e.g. //[***]\n11***22***33 will return 66
    - all previous formats should also be supported
    
8. Support multiple delimiters of any length
    - use the format: //[{delimiter1}][{delimiter2}]...\n{numbers} e.g. //[*][!!][r9r]\n11r9r22*33!!44 will return 110
    - all previous formats should also be supported
