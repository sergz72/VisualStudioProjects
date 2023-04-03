: test begin dup . 1- dup 0= until ;
: test2 begin dup . dup while 1- repeat ;
: test3 10 0 do i 5 = if leave else i . then loop ;

5 test
5 test2
test3
