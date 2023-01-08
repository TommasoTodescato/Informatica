function splitConsVowels(world)
{
	let cons = vow = "";
	let vowels = ["A", "E", "I", "O", "U"];
	for (i of world.split(""))
	{
		if (vowels.includes(i.toUpperCase()))
			vow += i;
		else
			cons += i;
	}
	return [cons, vow];
}

function getSurname(surnameId)
{
	let surname = result = document.getElementById(surnameId).value;
	let i = 0;

	if (surname.length < 3)
		result += "X";
	else if (surname.length > 3)
	{
		result = splitConsVowels(surname)[0];
		if (result.length > 3)
			result = result.slice(0, -(result.length -3));
		while (result.length < 3)
		{
			result += splitConsVowels(surname)[1][i];
			i += 1;
		}
	}
	return result.toUpperCase();
}

function getName(nameId)
{
	let name = result = document.getElementById(nameId).value;
	let i = 0;

	if (name.length < 3)
		result += "X";
	else if (name.length > 3)
	{
		result = splitConsVowels(name)[0];
		if (result.length > 3)
			result = result[0] + result[2] + result[3];
		while (result.length < 3)
		{
			result += splitConsVowels(name)[1][i];
			i += 1;
		}
	}
	return result.toUpperCase();
}

function getDate(dateId)
{
	let months = 
	{
		"01":"A",	"02":"B",	"03":"C",
		"04":"D",	"05":"E",	"06":"H",
		"07":"L",	"08":"M",	"09":"P",
		"10":"R",	"11":"S",	"12":"T"
	}
	let date = document.getElementById(dateId).value;
	let result = date[2] + date[3];
	result += months[date.split("-")[1]];
	return result;
}

function getDaySex(dateId, femaleId)
{
	let date = document.getElementById(dateId).value;
	let result = date.split("-")[2];
	if (document.getElementById(femaleId).checked === true)
	{
		result = parseInt(result) + 40;
	}
	return String(result);
}

function getPlace(placeId)
{
	return document.getElementById(placeId).value;
}

function getControlCode(incompleteCode)
{
	let result = "";
	let sum = 0;
	let evenTable =
	{
		'0':0,	'1':1,	'2':2,	'3':3,	'4':4,	'5':5,	'6':6,
		'7':7,	'8':8,	'9':9,	'A':0, 	'B':1, 	'C':2, 	'D':3,
		'E':4, 	'F':5, 	'G':6, 	'H':7, 	'I':8, 	'J':9,	'K':10,
		'L':11, 'M':12, 'N':13, 'O':14, 'P':15, 'Q':16, 'R':17,
		'S':18, 'T':19, 'U':20, 'V':21, 'W':22, 'X':23, 'Y':24, 'Z':25
	};
	let oddTable =
	{
		"C":5,	"D":7,	"E":9,	"F":13,	"G":15,	"1":0,	"6":15,
		"H":17,	"I":19,	"J":21,	"K":2,	"L":4,	"2":5,	"7":17,
		"M":18,	"N":20,	"O":11,	"P":3,	"Q":6,	"3":7,	"8":19,
		"R":8,	"S":12,	"T":14,	"U":16,	"V":10,	"4":9,	"9":21,
		"W":22,	"X":25,	"Y":24,	"Z":23,	"0":1,	"5":13,	"A":1,	"B":0
	};
	for(let i=0;i<15;i++)
	{
		if (i%2===0)
			sum += oddTable[incompleteCode[i]];
		else
			sum += evenTable[incompleteCode[i]];
	}
	
	result = sum % 26;
	
	result = Object.keys(evenTable).find(key=>evenTable[key]===sum);
	//result è giusto, bisogna solo capire come prendere il value dal key
	
	console.log(result);
	return result;
}

function getCode()
{
	//makePlace()
	//makeControl()
	

}






