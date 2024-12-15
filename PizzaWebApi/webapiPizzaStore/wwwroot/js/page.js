function openPopup() {
    document.getElementById("pizzaPopup").style.display = "flex";
}

// פונקציה לסגירת הפופאפ
function closePopup() {
    document.getElementById("pizzaPopup").style.display = "none";
}
    
var baseURL = "http://localhost:5190";
function addpizza() {
    alert("הפיצה הןספה בהצלחה לרשימת הפיצות שלנו תודה ויום טוב");
    var pizza1={};
    pizza1.name=document.getElementById('name').value;
    pizza1.id=document.getElementById('id').value;
    pizza1.isGluten=document.getElementById('isGluten').value;
     var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

        const requestOptions = {
            method: "POST",
            headers: myHeaders
          
          };  
          fetch(`http://localhost:5190/ChanisPizza/setPizza/${pizza1.name}/${pizza1.id}/${pizza1.isGluten}`, requestOptions)
            .then((response) => response.text())
            .then((result) => console.log(result))
            .catch((error) => console.error(error));
             console.log("הוספת פיצה:",pizzaName,pizzaId, pizzaGluten);

            // סגור את הפופאפ
            closePopup();
        }