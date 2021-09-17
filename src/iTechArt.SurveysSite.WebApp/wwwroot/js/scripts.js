class QuestionType {
    static get Closed() {
        return 1;
    }

    static get OpenEnded() {
        return 2;
    }
}

function addQuestion() {
    const order = document.querySelectorAll("input.input-question").length;
    const template = document.querySelector("template#question");
    const div = document.querySelector("#questions");
    const clone = template.content.cloneNode(true);
    clone.id = "";
    const questionName = `Questions[${order}]`;
    const questionTitle = clone.querySelector("input.input-question");
    questionTitle.setAttribute("name", questionName + ".QuestionTitle");
    const options = clone.querySelector("template#closed");
    const optionsClone = options.content.cloneNode(true);
    const questionType = clone.querySelector("#question-type");
    const questionDiv = clone.querySelector("#question-div");
    questionType.setAttribute("name", `Questions[${order}].QuestionType`);
    questionType.setAttribute("value", QuestionType.Closed);
    questionDiv.appendChild(optionsClone);
    div.appendChild(clone);
}

function removeQuestion(event) {
    const fieldset = event.target.closest("div.flex");
    const div = fieldset.parentElement;
    div.removeChild(fieldset);
    const questionTitle = div.querySelectorAll("input.input-question");
    for (let i = 0; i < questionTitle.length; i++) {
        const questionName = `Questions[${i}]`;
        questionTitle[i].setAttribute("name", questionName + ".QuestionTitle");
    }
}

function chooseType(event, type) {
    const fieldset = event.target.closest("div.flex");
    const options = fieldset.querySelectorAll(".question");
    const currentOption = options[options.length - 1];
    fieldset.removeChild(currentOption);
    var newOptions;
    var optionsClone;
    const questionType = fieldset.querySelector("#question-type");
    if (type === QuestionType.Closed) {
        newOptions = document.querySelector("template#closed");
        optionsClone = newOptions.content.cloneNode(true);
        questionType.setAttribute("value", QuestionType.Closed);
        fieldset.appendChild(optionsClone);
    } else {
        newOptions = document.querySelector("template#openEnded");
        optionsClone = newOptions.content.cloneNode(true);
        questionType.setAttribute("value", QuestionType.OpenEnded);
        fieldset.appendChild(optionsClone);
    }
}