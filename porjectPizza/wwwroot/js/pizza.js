var baseURL="http://localhost:5095"
function addPizza(){
    var pizza={};
    pizza.Id=document.getElementById('id').value;
    pizza.If_gloten=document.getElementById('if_gloten').value;
    pizza.Name=document.getElementById('name').value;
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify(pizza);

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw
    };

    fetch(baseURL+"/Pizza/PostPizza/Pizza", requestOptions)
        .then(response => alert("yesss"))
     
        .catch(error => console.log('error', error));
}
