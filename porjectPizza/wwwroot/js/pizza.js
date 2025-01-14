var baseURL = "http://localhost:5095";
var dinami_token=
// מציאת האלמנטים של כפתור ה-"Add Pizza" ואזור שדות הקלט
// var btn = document.getElementById("addPizzaButton");
// var pizzaFormContainer = document.getElementById("pizzaFormContainer");
function showForm() {
    console.log('showForm function was called'); // לבדוק אם הפונקציה נקראת
    document.getElementById('pizzaForm').style.display = 'block';
    document.getElementById('showFormButton').style.display = 'none';
}


// פונקציה לשליחת הפיצה לשרת
function addPizza() {
    var pizza = {
        id: document.getElementById('id').value,
        ifGloten: document.getElementById('if_gloten').value === 'true',
        pizzaName: document.getElementById('name').value,
        price: parseFloat(document.getElementById('price').value)  // ודא שהמחיר הוא מספר
    };

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify(pizza);
    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw
    };

    fetch(baseURL + "/Pizza/PostPizza", requestOptions)
        .then(response => {
            if (response.ok) {
                alert("Pizza added successfully!");
                pizzaFormContainer.classList.add("hidden"); // מסתיר את אזור שדות הקלט לאחר שליחה
                btn.style.display = "inline-block";
            } 
            else {
                alert("Error adding pizza: " + response.statusText);
            }
        })
        .catch(error => console.log('error', error));
}
function addWorker()
{
var worker = {
    id : document.getElementById('worker_id').value,
    firstName: document.getElementById('fname_worker').value,  // לדוג' אם יש לבחור בין "true" ו-"false"
    lastName: document.getElementById('lname_worker').value,
    password:document.getElementById('password').value,
    role:document.getElementById('role').value


};
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify(worker);

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw
}
console.log("Sending data:", raw);
fetch(baseURL+"/worker/writeWorker", requestOptions)
.then(response => alert("good good"))
.catch(error => console.log('error', error));
}

function showWorkerForm() {
    var workerForm = document.getElementById('workerForm');
    workerForm.style.display = workerForm.style.display === 'none' ? 'block' : 'none';
}