function displayQuestion(type, order) {
    const question = document.querySelector("#question-div");
    const questionType = question.querySelector("#question-type");
    const questionTitle = question.querySelector("input.input-question");
    const questionName = `Questions[${order}]`;
    questionTitle.setAttribute("name", questionName + ".QuestionTitle");
    questionType.setAttribute("name", questionName + ".QuestionType");
    if (type === 1) {
        const newOptions = document.querySelector("template#closed");
        const optionsClone = newOptions.content.cloneNode(true);
        questionType.setAttribute("value", QuestionType.Closed);
        question.appendChild(optionsClone);
    }
    if (type === 2) {
        const newOptions = document.querySelector("template#openEnded");
        const optionsClone = newOptions.content.cloneNode(true);
        questionType.setAttribute("value", QuestionType.OpenEnded);
        question.appendChild(optionsClone);
    }
    question.id = "";
}