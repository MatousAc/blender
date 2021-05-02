// javascript that the whole app can use

console.log("app.js")
dq = function (selector) { return document.querySelector(selector) }
sg = function (item) { return sessionStorage.getItem(item) }
ss = function (item, val) { return sessionStorage.setItem(item, val) }

toggleSystemSession = function () {
    if ((sg("system") == "imperial") || (sg("system") == null)) {
        ss("system", "metric")
    }
    else {
        ss("system", "imperial")
    }
}

getSystem = function () {
    dq("#system").checked = (sg("system") == "metric") ? true : false
}

toggleSystemPost = function () {
    let form = dq("#system_form")
    form.action = dq("#system").checked ? "../AppVariables/toggleSystem?syst=metric&callingPage=" : "../AppVariables/toggleSystem?syst=imperial&callingPage="
    url = window.location.pathname
    form.action += url
}