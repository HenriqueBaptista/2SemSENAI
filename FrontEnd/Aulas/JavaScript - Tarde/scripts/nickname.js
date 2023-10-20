function olaPessoa() {
    event.preventDefault();

    let name = document.getElementsByClassName("nome").value;
    let nickname = document.getElementsByClassName("apelido").value;
}

function showNicknamePlaceholder() {
    event.preventDefault();

    let yesOrNo = document.getElementsByClassName("simNao").value;

    if (yesOrNo == "sim") {
        document.getElementById("show").style.display = "none";
    }
    else {
        document.getElementById("show").style.display = "none";
    }
}