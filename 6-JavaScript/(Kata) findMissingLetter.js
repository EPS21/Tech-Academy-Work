var str = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"
var alpha = "abcdefghijklmnopqrstuvwxyz"

// charCodeAt gets the index of the letter in the ASCII character set
// console.log(alpha.charCodeAt(0))

var chars = ['a','b','c','d','f']; // missing 'e'

// finding out some properties of charArray
/*
console.log(chars)
console.log(chars.length)
console.log(chars[0]) // a
console.log(chars[0].charCodeAt()) // 97
console.log(String.fromCharCode(97)) // a
*/

//console.log(chars.join()) // make it into a string if you want

// the reason why I didn't get it before was because in the if statement, I was 
// swapping the 0 and i, like if (array[i].charCodeAt() + 1 ...) but the correct
// way was if (array[0].charCodeAt() + i) because this way checks the addition of
// i against the other value of array[i].
function findMissingLetterNoString(array) {	
	for (var i = 0; i < array.length; i++) {
		//if (array[0].charCodeAt() + i != array[i].charCodeAt()) {
		if (array[i + 1].charCodeAt() - array[i].charCodeAt() != 1) { // hey I figured this out my own way sort of
			return String.fromCharCode(array[i].charCodeAt() + 1);		
		}
	}
	throw new Error("Invalid input"); // stealing this to catch invalid inputs
}

console.log(findMissingLetterNoString(chars))
//console.log(chars[3 + 1].charCodeAt())
//console.log(chars[3].charCodeAt())


// the solution, joining the array into a string
function findMissingLetter(array) {
	var str = array.join("");
	for (var i = 0; i < str.length; i++) {	
		if (str.charCodeAt(i + 1) - str.charCodeAt(i) != 1) {
			return (String.fromCharCode(str.charCodeAt(i) + 1));
		}	
	}
}

console.log(findMissingLetter(chars));


