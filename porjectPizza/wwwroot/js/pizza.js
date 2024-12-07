var baseURL = "http://localhost:5095";

// מציאת האלמנטים של כפתור ה-"Add Pizza" ואזור שדות הקלט
var btn = document.getElementById("addPizzaButton");
var pizzaFormContainer = document.getElementById("pizzaFormContainer");

// פתיחת שדות הקלט כאשר לוחצים על כפתור "Add Pizza"
btn.onclick = function() {
    pizzaFormContainer.classList.remove("hidden"); // מציג את אזור שדות הקלט
    document.getElementById("addPizzaButton").style.display="none";
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
