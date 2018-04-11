// Finds the prime factors in a number, that is the prime numbers you multiply
// to get the integer inputted


var integer = 10;
var primeArray = [];

//find whether its a prime number

for (var i = 2; i <= integer; i++) {
	while (integer % i == 0) {
		//console.log(integer)
		primeArray.push(i)
		integer /= i 
	}
}

console.log(primeArray.toString())


// should return 2 and 3