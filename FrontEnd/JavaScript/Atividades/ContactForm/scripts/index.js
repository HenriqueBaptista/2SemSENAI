// URL para o servidor local
const url = "http://localhost:3000/contato"

// Função para usar a API da Viacep
async function usarApi() {
    // Busca o cep no HTML
    const cep = document.getElementById("cep").value;

    if (cep != "") {
        // URL para o uso da API - o cep será inserido por interpolação
        const urlcep = `https://viacep.com.br/ws/${cep}/json/`;

        // Se for resolvida - Fullfiled
        try {
            // Conteúdo da Api - irá esperar o retorno
            const promise = await fetch(urlcep);

            // JSON da Api - esperará e só retornará o JSON
            const endereco = await promise.json();

            // Escreverá no console
            console.log(endereco);

            // Função exibeEndereco em uso
            exibeEndereco(endereco);
        }
        // Se for rejeitada
        catch (error) {
            // Exibe uma mensagem de erro
            console.log("Erro, cep inválido")

            // Função apagaEndereco em uso
            apagaEndereco();
        }
    }

    // Função para preencher o endereço automaticamente se o cep estiver correto
    function exibeEndereco(endereco) {
        document.getElementById("rua").value = endereco.logradouro;
        document.getElementById("bairro").value = endereco.bairro;
        document.getElementById("cidade").value = endereco.localidade;
        document.getElementById("UF").value = endereco.uf;
        document.getElementById("ddd").value = endereco.ddd;
    }

    // Função para apagar os campos preenchidos automaticamente quando o sistema der errado
    function apagaEndereco() {
        document.getElementById("rua").value = "";
        document.getElementById("bairro").value = "";
        document.getElementById("cidade").value = "";
        document.getElementById("UF").value = "";
        document.getElementById("ddd").value = "";
    }
}; // Completa


// Função para cadastrar e salvar um contato no db.json
async function cadastrar(e) {
    // Previne a captura do evento submit do form
    e.preventDefault();

    let nome = document.getElementById("nome").value; // Nome

    let sobrenome = document.getElementById("sobrenome").value; // Sobrenome

    let email = document.getElementById("email").value; // Email

    let pais = document.getElementById("pais").value; // País

    let ddd = document.getElementById("ddd").value; // DDD

    let telefone = document.getElementById("telefone").value; // Telefone

    let cep = document.getElementById("cep").value; // Cep

    let rua = document.getElementById("rua").value; // Rua

    let numero = document.getElementById("numero").value; // Número

    let complemento = document.getElementById("complemento").value; // Complemento

    let bairro = document.getElementById("bairro").value; // Bairro

    let cidade = document.getElementById("cidade").value; // Cidade

    let UF = document.getElementById("UF").value; // Estado - UF

    let anotates = document.getElementById("anotates").value; // Anotações


    // Objeto que será guardado os valores acima
    const contato = { nome, sobrenome, email, pais, ddd, telefone, cep, rua, numero, complemento, bairro, cidade, UF, anotates }

    //Tentará transformar o contato em um JSON para inserir no db.json
    try {
        // Conteúdo da Api - vai esperar um retorno da URL
        const promise = await fetch(url, {
            //Transforma objetos em JSON
            body: JSON.stringify(contato),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });

        // Retorna o JSON da promise
        const retorno = promise.json();

        // Retorna no console
        console.log(retorno);
    }
    // Se for rejeitada
    catch (error) {
        alert(`Um erro ocorreu: ${error}`);
    }
};