var baseURL = "http://localhost:5190";
function load() {
    fetch(baseURL + `/pizza`)
        .then((res) => res.json())
        .then((data) => fillpizzaTbl(data))
        .catch((error) => console.log(error))

}
function fillpizzaTbl(data) {
    var table = document.getElementById('pizzalist');
    data.forEach(function (pizza) {
        var tr = document.createElement('tr');
        tr.innerHTML = 
            '<td>' + pizza.name + '</td>' +
            '<td>' + pizza.id+ '</td>' +
            '<td>' + pizza.isGluten + '</td>' ;
        var tBody = table.getElementsByTagName('tbody')[0];
        tBody.appendChild(tr);
    });
}
function addpizza() {
    var pizza1={};
    pizza1.name=document.getElementById('name').value;
    pizza1.id=document.getElementById('id').value;
    pizza1.isGluten=document.getElementById('isGluten').value;

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify(pizza1);

    const requestOptions = {
        method: "POST",
        redirect: "follow"
      };
      
      fetch(baseURL+`/ChanisPizza/setPizza/${pizza1.name}/${pizza1.id}/${pizza1.isGluten}`,requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error));

    // var requestOptions = {
    //     method: 'POST',
    //     headers: myHeaders,
    //     body: raw
    // };

    // fetch(baseURL+"/pizza", requestOptions)
    //     .then(response => afterPost())
    //     .catch(error => console.log('error', error));
}

function afterPost(params) {
    alert("");
    load();
}