const listaPessoa = [];

function calcular(event) {
    event.preventDefault();
    let nome = document.getElementById("nome").value.trim();
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);

    if (isNaN(altura) || isNaN(peso) || nome == "") {
        alert('É necessário preencher todos os campos!');
        return;
    }
    if (altura == 0) {
        alert('A altura não pode ser igual a zero!')
    }

    const imc = calcularImc(peso, altura);
    const situacao = geraSituacao(imc);

    const pessoa = {
        nome: nome,
        altura: altura,
        peso: peso,
        imc: imc,
        situacao: situacao
    }; // object short sintaxe

    console.log(pessoa)

    // também pode ser: 
    // const pessoa = {
    //     nome,
    //     altura,
    //     peso,
    //     imc,
    //     situacao
    // };
    // Visto que as propriedades e valores possuem o mesmo nome

    listaPessoa.push(pessoa);

    exibirDados()
}

function calcularImc(w, h) {
    return w / Math.pow(h, 2);
}

function geraSituacao(i) {
    if (i < 18.5) {
        return "Magreza Severa";
    }
    else if (i < 25) {
        return "Peso Normal";
    }
    else if (i < 30) {
        return "Acima do Peso";
    }
    else if (i < 35) {
        return "Obesidade I";
    }
    else if (i < 40) {
        return "Obesidade II";
    }
    else {
        return "Cuidado!";
    }
}

function exibirDados() {
    console.log(listaPessoa)
    let linhas = '';

    listaPessoa.forEach(function (oPessoa) {
        linhas += (`<tr>

                        <td>${oPessoa.nome}</td>
                        <td>${oPessoa.altura}</td>
                        <td>${oPessoa.peso}</td>
                        <td>${Math.round(oPessoa.imc)}</td>
                        <td>${oPessoa.situacao}</td>
                        
                    </tr>`)

    });

    document.getElementById('cadastro').innerHTML = linhas;
}