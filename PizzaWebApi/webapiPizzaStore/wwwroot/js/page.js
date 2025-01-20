
function openPopup() {
    document.getElementById("pizzaPopup").style.display = "flex";
}

// פונקציה לסגירת הפופאפ
function closePopup() {
    document.getElementById("pizzaPopup").style.display = "none";
}

// משתנה שיאכסן את ה-TOKEN של המשתמש אחרי התחברות
// משתנה שיאכסן את ה-TOKEN של המשתמש אחרי התחברות
let token = "";

// פונקציה להתחברות
function login() {
    // שליפת שם משתמש וסיסמה
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    const requestOptions1 = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
          },
        body: JSON.stringify({ name: username, password: password })
    };

    // שליחת בקשה לשרת להתחברות
    fetch(`http://localhost:5190/Login/Login/${username}/${password}`, requestOptions1)
    .then(response => {
        if (response.ok) {
            return response.text(); // מחזיר את הטקסט (ה-TOKEN)
        } else {
            throw new Error(`הבקשה נכשלה. סטטוס: ${response.status} - ${response.statusText}`);
        }
    })
    .then(result => {
        token = result; // כאן נשמר ה-TOKEN במשתנה
        document.getElementById("errorMessage").style.display = "none"; // החבא את הודעת השגיאה
        alert("ההתחברות הצליחה!");
       console.log( token);
      
        // הצגת דף הוספת הפיצה
        document.getElementById("loginForm").style.display = "none";
        document.getElementById("pizzaSection").style.display = "block";
    })
    .catch(error => {
        document.getElementById("errorMessage").style.display = "block"; // הצג הודעת שגיאה
        console.error("שגיאה בהתחברות:", error);
    });
}
function addpizza() {
    // יצירת אובייקט פיצה
    var pizza1 = {};
    pizza1.name = document.getElementById('name').value;
    pizza1.id = document.getElementById('id').value;
    // pizza1.isGluten = document.getElementById('isGluten').value;
    pizza1.isGluten = document.getElementById('isGluten').checked;

    // יצירת כותרות הבקשה
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    // אם אין TOKEN, נבקש מהמשתמש להתחבר מחדש
    if (!token) {
        alert("נא להתחבר קודם");
        return;
    }

    // הוספת ה-TOKEN לכותרת Authorization
    myHeaders.append("Authorization", `Bearer ${token}`);

    // הגדרת אפשרויות הבקשה
    const requestOptions = {
        method: "POST",
        headers: myHeaders
    };  
    
    // שליחת הבקשה לשרת עם משתנים מתוך הפורום
    fetch(`http://localhost:5190/ChanisPizza/setPizza/${pizza1.name}/${pizza1.id}/${pizza1.isGluten}`, requestOptions)
        .then((response) => response.text())
        .then((result) => {
            console.log(result);
            alert("הפיצה הוספה בהצלחה!");
        })
        .catch((error) => console.error(error));

    // הדפסת נתונים לקונסול להדגמה
    console.log("הוספת פיצה:", pizza1.name, pizza1.id, pizza1.isGluten);

    // סגור את הפופאפ
    closePopup();
}
