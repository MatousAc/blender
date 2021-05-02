// js for some last-minute features

loadNewServings = function () {
    let serves = dq("#serves").value
    let url = window.location.href
    url = url.split("?serves")[0]
    window.location.replace(url + "?serves=" + serves)
}


//loadNewServings = function () {
//    let serves = dq("#serves").value
//    let url = window.location.href
//    url = url.split("?serves")[0]
//    window.location.replace(url + "?serves=" + serves)
//}