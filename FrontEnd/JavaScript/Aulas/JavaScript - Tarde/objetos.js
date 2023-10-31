let henrique = {
    nome : "Henrique",
    idade: 17,
    altura: 1.90
};

henrique.peso = 70

let lucas = new Object();

lucas.nome = "Lucas";
lucas.idade = 16;
lucas.altura = 2;
lucas.peso = "Mãe do Renan"

let pessoas = [];

pessoas.push(henrique, lucas)

console.log(henrique);
console.log(lucas);
console.log(pessoas)

pessoas.forEach(function (y){
    console.log(y.nome);
});