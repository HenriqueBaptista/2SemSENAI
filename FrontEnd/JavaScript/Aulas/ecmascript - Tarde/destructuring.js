// Em um objeto temos os atributos
const camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: 399.98,
    marca: "Lacoste",
    tamanho: "G",
    cor: "Azul",
    promo: true
}

// Se eu quiser selecionar atributos específicos nesse onjeto para uma listagem, por exemplo, posso fazer assim:
const descricao = camisaLacoste.descricao;
const preco = camisaLacoste.preco;
console.log(`
Produto: ${descricao}
Preço: ${preco}
`);

// Entretanto, há uma maneira mais prática de se fazer isso, essa é chamada de destructuring. Essa forma se faz assim:
const { marca, tamanho, promo } = camisaLacoste;

console.log(`
Marca: ${marca}
Tamanho: ${tamanho}
Promoção: ${promo ? "sim" : "não"}
`); // Aqui no promo fica numa condicional, se ele for true, receberá o valor "sim", senão, receberá o valor não




// Exercícios:

const evento = {
    data: new Date(),
    descricaoEvento: "Aniversário do Henrique",
    titulo: "Aniversário",
    presenca: true,
    comentario: "Que legal!"
};
const {data, descricaoEvento, titulo, presenca, comentario} = evento
console.log(`
    Data: ${data};
    Descrição: ${descricaoEvento};
    Título: ${titulo};
    Presença: ${presenca ? "Presente" : "Ausente"};
    Comentário ${comentario};
`)