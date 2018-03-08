var person = {};
person['firstname'] = 'Mario';
person['lastname'] = 'Rossi';

// the dot notation way of grabbing these values
console.log(person.firstname);
// expected output: "Mario"

// the bracket notation way of grabbing these values
person = {'firstname': 'John', 'lastname': 'Doe'}

console.log(person['lastname']);
// expected output: "Doe"
