function addQuestion() {
    var order = document.querySelectorAll(".input-question").length / 2 - 1;
    var template = document.querySelector("#question");
    var div = document.querySelector("#questions");
    var clone = template.cloneNode(true);
    var questionName = "Questions[" + order + "]";
    var questionTitle = clone.querySelector("input.input-question");
    questionTitle.setAttribute("name", questionName + ".QuestionTitle");
    clone.removeAttribute("hidden");
    div.appendChild(clone);
}

function removeQuestion(fieldset) {
    var div = fieldset.parentElement;
    div.removeChild(fieldset);
    var questionTitle = div.querySelectorAll("input.input-question");
    for (var i = 0; i < questionTitle.length; i++) {
        var questionName = "Questions[" + i + "]";
        questionTitle[i].setAttribute("name", questionName + ".QuestionTitle");
    }
}

function chooseType(input, type) {
    input.value = type;
}