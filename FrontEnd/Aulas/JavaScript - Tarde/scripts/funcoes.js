function calcular() {
    event.preventDefault();

    let n1 = parseFloat(document.getElementById("numero1").value);
    let n2 = parseFloat(document.getElementById("numero2").value);
    let resultado;
    let operador = document.getElementById("operacao").value;

    if (isNaN(n1) || isNaN(n2)) {
        alert(`Insira números!`)

        return "Insira números!"
    }
    else {
        switch (operador) {

            case '+':
                resultado = soma(n1, n2);

                alert(`Resultado: ${resultado}`);
                break;

            case '-':
                resultado = sub(n1, n2);

                alert(`Resultado: ${resultado}`);
                break;

            case '*':
                resultado = multi(n1, n2);

                alert(`Resultado: ${resultado}`);
                break;

            case '/':
                resultado = divid(n1, n2);

                alert(`Resultado: ${resultado}`);
                break;

            default:
                console.log("Inválido, selecione um operador!");

                alert("Inválido, selecone um operador!")
                break;
        }

        document.getElementById("resultado").innerText = resultado;
    }


    // console.log(n1);
    // console.log(n2);
    // console.log(`Resultado: ${resultado}`);



}

function soma(x, y) {
    return (x + y).toFixed(2);
}

function sub(x, y) {
    return (x - y).toFixed(2);
}

function multi(x, y) {
    return (x * y).toFixed(2);
}

function divid(x, y) {
    if ((x == 0) || (y == 0)) {
        return "Inválido"
    }

    else {
        return (x / y).toFixed(2);
    }
}