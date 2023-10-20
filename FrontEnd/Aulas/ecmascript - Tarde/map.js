
const numeros = [1, 2, 5, 10, 300];
console.log(numeros);
console.log()

// Foreach - Um por um e não há retorno - VOID
numeros.forEach(n => { console.log(n) })
console.log()

// Map - Retorna um novo array modificado
const dobro = numeros.map((n) => { return n * 2 });
console.log(dobro);
console.log()

// Filter - Retorna um novo array apenas com elementos que atendem uma condição
const maior10 = numeros.filter((n) => { return n >= 10 });
console.log(maior10);
console.log();

// Reduce - Valor unificado do array

const soma = numeros.reduce((vlInicial, num) => { return vlInicial + num })
console.log(soma)
console.log()






// Exercícios

const comentarios = [
    { comentario: "Bla bla", exibe: true },
    { comentario: "Evento foi uma *****", exibe: false },
    { comentario: "Legal!", exibe: true },
    { comentario: "Vai tomar no", exibe: false },
    { comentario: "Muito boa!", exibe: true },
]

const comentariosOk = comentarios.filter((c) => {
    return c.exibe === true;
    // return c.exibe;
});
comentariosOk.forEach(c => { console.log(c.comentario) });



// Curiosidade: =, == e === são diferentes entre si, sendo que "=" (atribuição) atribue valores, "==" (igual a) relaciona valores que tenham o mesmo valor mas nem sempre o mesmo tipo, já o "===" (idêntico a) serve para relacionar valores que tenham o mesmo valor e tipo ao mesmo tempo.