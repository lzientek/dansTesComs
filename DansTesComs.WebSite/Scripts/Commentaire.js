var actualId = 0;

function newRow(id) {
    return "<div class=\"row\"><div class=\"col-md-3\">" +
        "<input class=\"form-control text-box single-line\" id=\"CommentairesExterneContents_" + id + "__Pseudo\" name=\"CommentairesExterneContents[" + id + "].Pseudo\" type=\"text\" placeholder=\"Pseudo\">"
        + "</div><div class=\"col-md-6\">"
        + " <textarea class=\"form-control\" id=\"CommentairesExterneContents_" + id + "__Commentaire\" name=\"CommentairesExterneContents[" + id + "].Commentaire\"  placeholder=\"commentaire\"></textarea>"
        + "<input id=\"CommentairesExterneContents_" + id + "__Niveau\" name=\"CommentairesExterneContents[" + id + "].Niveau\" type=\"hidden\" value=\"0\">"
        + " </div>";

}

function buttonAdd() {
    actualId += 1;
    var newhtml = newRow(actualId);
    $("#ajoutdecoms").append(newhtml);
}

$().ready(function () {
    $("#addCommentButton").click(buttonAdd);
});