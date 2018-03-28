/*
function spinWords(str){
  //TODO Have fun :)
  //str.split()
  str.trim().split(" ");

  return str;


}

console.log(spinWords("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"));
*/

/*
var text = "Bla bla Tony, bla la Tony, bla bla Tony bla bla bla Tony."; 
var arr = text.split(" ");
var myName = "Tony";
var hits = [];
for (var i = 0; i < arr.length; i++) {
  if (arr[i] === myName || arr[i] === myName + "." || arr[i] === myName + "!") {
    hits.push(arr[i]);
  }
}
console.log(hits);
*/

// the working function, reverses words in the string if they are x letters long
function spinWords(str, x) {
	//var str = ;
	var splitString = str.split(/[ ,.]+/); // here is an example of regular expressions to account for commas and periods as well as the spaces
	var hits = [];

	//console.log(splitString)

	for (var i = 0; i < splitString.length; i++) {
		if (splitString[i].length < x) {
			hits.push(splitString[i])
		} else if (splitString[i].length >= x) {
			hits.push(splitString[i].split("").reverse().join(""))
		}
	}

	return (hits.join(" "));
}

console.log(spinWords("THE QUICK BROWN FOX, JUMPS. OVER. THE... LAZY DOG IS A", 4))

