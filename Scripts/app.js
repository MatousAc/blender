﻿// javascript that the whole app can use

dq = function (selector) { return document.querySelector(selector) }
sg = function (item) { return sessionStorage.getItem(item) }
ss = function (item, val) { return sessionStorage.setItem(item, val) }

toggleSystem = function () {
    if ((sg("system") == "imperial") || (sg("system") == null)) {
        ss("system", "metric")
    }
    else {
        ss("system", "imperial")
    }
    location.reload()
}
