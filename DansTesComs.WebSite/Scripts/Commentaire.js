﻿var actualId = 0;

function newRow(id) {
    return "<div class=\"row\"><div class=\"col-md-4\">" +
        "<input class=\"form-control text-box single-line\" id=\"CommentairesExterneContents_" + id + "__Pseudo\" name=\"CommentairesExterneContents[" + id + "].Pseudo\" type=\"text\" placeholder=\"Pseudo\">"
        + "</div><div class=\"col-md-8\">"
        + " <textarea class=\"form-control\" id=\"CommentairesExterneContents_" + id + "__Commentaire\" name=\"CommentairesExterneContents[" + id + "].Commentaire\"  placeholder=\"commentaire\"></textarea>"
        + "<input id=\"CommentairesExterneContents_" + id + "__Niveau\" name=\"CommentairesExterneContents[" + id + "].Niveau\" type=\"hidden\" value=\"0\">"
        + " </div>";

}

function buttonAdd() {

    var newhtml = newRow(actualId);
    $("#ajoutdecoms").append(newhtml);
    actualId += 1;
}

$().ready(function () {
    actualId = parseInt($("#lastIndexCom").val());
    $("#addCommentButton").click(buttonAdd);
});

