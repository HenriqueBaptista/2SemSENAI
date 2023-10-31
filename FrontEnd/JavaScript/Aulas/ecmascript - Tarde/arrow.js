const somar = function name(x, y) {
    return x + y;
}

// Também pode ser:
const somar2 = function (x, y) {
    return x + y;
}

// Que também pode ser:
const somar3 = (x, y) => {
    return x + y;
}

console.log(somar(50, 10));
console.log(somar2(20, 30));
console.log(somar3(30, 50));
console.log("")

//////////

const dobro = (numero) => {
    return numero * 2;
}

// Também pode ser:
const dobro2 = numero => numero * 2

console.log(dobro(70))
console.log(dobro2(100))
console.log()

//////////

const sacola = [
    "Maçã",
    "Banana",
    "Pera",
    "Uva",
    "Mamão",
    "Laranja",
    "Mexerica"
];

sacola.forEach(f => {
    console.log(`Fruta: ${f}`);
});

console.log();

//////////

const convidados = [
    {nome : "Enzo", idade : 17},
    {nome : "Gabriel", idade : 16},
    {nome : "Thiago", idade : 18},
    {nome : "Henrique", idade : 17},
    {nome : "Lucas", idade : 16},
    {nome : "Pedro", idade : 19}
];

convidados.forEach(p => {
    console.log(`Convidado: ${p.nome}; Idade: ${p.idade}`);
})