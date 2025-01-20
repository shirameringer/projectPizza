var baseURL = "http://localhost:5095";
function shira() {
    alert("hello");
}
function showForm() {
    const pizzaForm = document.getElementById('pizzaForm');
    const showFormButton = document.getElementById('showFormButton');

    if (pizzaForm && showFormButton) {
        pizzaForm.style.display = 'block';
        showFormButton.style.display = 'none';
    } else {
        console.error('Pizza form or button not found');
    }
}



function addPizza() {
    var pizza = {
        id: document.getElementById('id').value,
        ifGloten: document.getElementById('if_gloten').value === 'true',
        pizzaName: document.getElementById('name').value,
        price: parseFloat(document.getElementById('price').value)  // ודא שהמחיר הוא מספר
    };

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json",);

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
function addWorker() {
    var worker = {
        id: document.getElementById('worker_id').value,
        firstName: document.getElementById('fname_worker').value,  // לדוג' אם יש לבחור בין "true" ו-"false"
        lastName: document.getElementById('lname_worker').value,
        password: document.getElementById('password').value,
        role: document.getElementById('role').value


    };
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    myHeaders.append("Authorization", `Bearer ${dinami_token}`);

    var raw = JSON.stringify(worker);

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw
    }
    console.log("Sending data:", raw);
    fetch(baseURL + "/worker/addWorker", requestOptions)
        .then(response => alert("good good"))
        .catch(error => console.log('error', error));
}

function showWorkerForm() {
    var workerForm = document.getElementById('workerForm');
    workerForm.style.display = workerForm.style.display === 'none' ? 'block' : 'none';
}
function login(event) {
    event.preventDefault(); // Prevent the form from submitting naturally

    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    const requestOptions = {
        method: "POST",
        redirect: "follow"
    };

    fetch(baseURL + `/Login/Login?name=${username}&password=${password}`, requestOptions)
        .then(response => {
            if (response.ok) {
                return response.text(); // Assuming the response contains JSON
            }
            throw new Error('Login failed');
        })
        .then(data => {
            dinami_token = data.token; // Assuming the token is in the response
            document.querySelector('.login-container').style.display = 'none'; // Hide login
            document.getElementById('managementContainer').style.display = 'block'; // Show management
        })
        .catch(error => console.log('error', error));
}

