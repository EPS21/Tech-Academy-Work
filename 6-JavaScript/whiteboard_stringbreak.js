/***********************************************************
 This assignment needs to make new line after a word is four
 letters long, but not to split that word if it happens to be
 longer the letter length to make a new line
 ***********************************************************/


var str = "i ii iii the quick brown fox jumps over the lazy dog"

// splits them up but will omit words over x
function stringBreak1 (x, str) {
	// split the string into an array
	var splitstring = str.split(" ");	
	
	for (var i in splitstring) {
		if (splitstring[i].length < x + 1) {
			console.log(splitstring[i])
		}
	}
}

//stringBreak1(4, str);


function stringBreak2 (x, str) {
	console.log(str.substring(0, x))
}

stringBreak2(4, str);






	//for (i = 1; i <= x; i++) {
	//	console.log(str.substring(0+x,x))
	//}
	//console.log(str.substring(0+x,x))
	


	/*
	for (var i in str) {		
	if (str.length > x + 1) {
			console.log(str.substring(i,x))

		}
		//console.log(str.substring(i,x) + "\n");

		
		if (str.length < x + 1) {
			console.log(str.substring(i,x))
		}
		
		
	}
	*/

	/*
	
	*/

	/*
	if (splitstring.length > x) {
		return splitstring.join("") + "\n"
	} else {
		return splitstring.join("");
	}
	*/

	


