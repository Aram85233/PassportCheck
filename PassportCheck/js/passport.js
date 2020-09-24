
function CheckPassport() {
    let passportNumber = document.getElementById("passportNumber").value;
    if (passportNumber) {
        $.ajax({
            url: `/passport/CheckPassport/${passportNumber}`,
            success: function (result) {
                if (typeof result === 'object') {
                    let date = new Date(parseInt(result.DateOfBirth.substr(6)));
                    document.getElementById("result").innerHTML = `<b>Имя:</b> ${result.FirstName} </br>
                                                                   <b>Фамилия:</b> ${result.LastName} </br>
                                                                   <b>Год рождения:</b> ${date.toDateString()} </br>
                                                                   <b>Пол:</b> ${result.Sex == 1 ? "Мужской" : "Женский"} </br>
                                                                   <b>Номер паспорта:</b> ${result.PassportNumber} </br>`;
                }
                else {
                    document.getElementById("result").innerHTML = `<p>${result}</p>`;
                }
            }
        });
    }
    
}
    
