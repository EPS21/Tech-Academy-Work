function myFunction() {
	var txt = "You Ordered:<br>";
	var runningTotal = 0;
	var sizePrice = 0;
	var sizeArray = document.getElementsByClassName("size");		
	var sizeResult;		
	
	// iterate through pizza sizeArray, find the checked one, and append to the txt string
	for (var i = 0; i < sizeArray.length; i++) {
		if (sizeArray[i].checked) {
			sizeResult = sizeArray[i].value;
			txt = txt + sizeResult + "<br>";
		}
	}
	
	// gets the price of the selected pizza size type, set to running total so far
	if (sizeResult === "Personal Pizza") {
		sizePrice = 6;
	} else if (sizeResult === "Medium Pizza") {
		sizePrice = 10;
	} else if (sizeResult === "Large Pizza") {
		sizePrice = 14;
	} else if (sizeResult === "Extra Large Pizza") {
		sizePrice = 16;
	}
	
	runningTotal = sizePrice;
	getMeat(runningTotal,txt);	
}
/***************************
 ***** meat function *******
 ***************************/
function getMeat(runningTotal, txt) {
	var meatTotal = 0;	
	var meatArray = document.getElementsByClassName("meats");
	var meatResult = [];
	
	// iterate through the meatArray, add each checked one to new meatResult array, and append to txt string
	for (var j = 0; j < meatArray.length; j++) {
		if (meatArray[j].checked) {
			meatResult.push(meatArray[j].value);
			txt = txt + meatArray[j].value + "<br>";
		}
	}
	
	// if there is more than one topping in meatResult, add $1 for each. Otherwise first is free
	if (meatResult.length == 1) {
		runningTotal = runningTotal;
	} else if (meatResult.length > 1) {
		runningTotal = runningTotal + meatResult.length - 1;
	}
	
	getCheese(runningTotal,txt);
}

function getCheese(runningTotal, txt) {
	var exCheesePrice = 3;
	var cheeseArray = document.getElementsByClassName("cheese");
	var cheeseSelection;
	
	// iterate through cheeseArray, find the checked one, and append to the txt string
	for (var i = 0; i < cheeseArray.length; i++) {
		if (cheeseArray[i].checked) {
			cheeseSelection = cheeseArray[i].value;
			txt = txt + cheeseSelection + "<br>";
		}
	}
	
	// if Extra Cheese is selected, adds $3, otherwise no change in price
	if (cheeseSelection === "Extra Cheese") {
		runningTotal += exCheesePrice;
	} else {
		runningTotal;
	}
	
	getCrust(runningTotal, txt);	
}	
	
function getCrust(runningTotal, txt) {
	var stuffedCrustPrice = 3;
	var crustArray = document.getElementsByClassName("crust");
	var crustSelection;
	
	// iterate through crustArray, find checked and append to txt string
	for (var i = 0; i < crustArray.length; i++) {
		if (crustArray[i].checked) {
			crustSelection = crustArray[i].value;
			txt += crustSelection + "<br>";
		}
	}
	
	// if stuffed crust is selected, adds $3 otherwise no change in price
	if (crustSelection === "Cheese Stuffed") {
		runningTotal += stuffedCrustPrice;
	}
	
	getSauce(runningTotal, txt);
		
}
	
function getSauce(runningTotal, txt) {
	var sauceArray = document.getElementsByClassName("sauce");
	var sauceSelection;
	
	// iterate through the sauceArray, find checked and append to txt string
	for (var i = 0; i < sauceArray.length; i++) {
		if (sauceArray[i].checked) {
			sauceSelection = sauceArray[i].value;
			txt += sauceSelection + "<br>";
		}
	}
	// no change in price for sauces here
	getVeggies(runningTotal, txt);
	
}

function getVeggies(runningTotal, txt) {
	var veggieArray = document.getElementsByClassName("veggies")
	var selectedVeggies = [];
	
	// iterate throught the veggieArray, find checked and add into selectedVeggies array
	for (var i = 0; i < veggieArray.length; i++)
		if (veggieArray[i].checked) {
			selectedVeggies.push(veggieArray[i].value);
			txt += veggieArray[i].value + "<br>";
		}
		
	// add $1 for each veggie, unless just one then no cost
	if (selectedVeggies.length > 1) {
		runningTotal += selectedVeggies.length - 1;
	} else if (selectedVeggies.length == 1) {
		runningTotal;
	} else if (selectedVeggies.length <= -1) {
		runningTotal += 9999;
	}
	
	document.getElementById("herp").innerHTML = txt;
	if (runningTotal >= 33) {
		document.getElementById("derp").innerHTML = "Total: $" + runningTotal + ".00" + "<br> dis a big pizza mang you gonna eat all that?";
	} else {
	document.getElementById("derp").innerHTML = "Total: $" + runningTotal + ".00";
	}
}

	























