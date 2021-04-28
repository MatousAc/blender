// this file is to provide functionality for adding ingredient forms to the recipe pages
// it also is to gather the stuff from the page to create new _requires strings
console.log("requires.js")

addIngredient = function () {
    // console.log("adding ingredient")
    let requires_wrapper = dq("#requires_wrapper")
    let requires_template = dq("#requires_template")
    let new_requires = requires_template.cloneNode(true)
    new_requires.removeAttribute("id")
    new_requires.classList.add("requires")
    requires_wrapper.append(new_requires)
}


collectData = function () {
    let require_list = document.getElementsByClassName("requires")
    amounts = []; units = []; ingredients = [];
    for (i = 0; i < require_list.length; i++) {
        info = require_list[i].children[1].children[0]
        amounts.push(info.children[0].value)
        units.push(info.children[1].value)
        ingredients.push(info.children[2].value)
    }

    let _requires = dq("#_requires")
    _requires.value = ""
    for (i = 0; i < require_list.length; i++) {
        console.log("amount: ", amounts[i], " unit: ", units[i], " ingredient:  ", ingredients[i])
        _requires.value += `@${amounts[i]}%${units[i]}%${ingredients[i]}`
    }
}


loadIngredient = function (amount, units, ingredient) {
    let requires_wrapper = dq("#requires_wrapper")
    let requires_template = dq("#requires_template")
    let new_requires = requires_template.cloneNode(true)
    new_requires.removeAttribute("id")
    new_requires.classList.add("requires")
    info = new_requires.children[1].children[0]
    info.children[0].value = amount
    info.children[1].value = units
    info.children[2].value = ingredient
    requires_wrapper.append(new_requires)
}

loadIngredients = function () {
    console.log("loading ingredients")
    let _requires = dq("#_requires").value
    let _requires_list = _requires.split("@")
    _requires_list.forEach(
        _req =>
            loadIngredient(_req.split('%')[0], _req.split('%')[1], _req.split('%')[2])
    )
}

