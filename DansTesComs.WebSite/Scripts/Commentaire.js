var actualId = 0;

function newRow(id) {
    return "<div class=\"row\"><div class=\"col-md-4\">" +
        "<input class=\"form-control text-box single-line\" id=\"CommentairesExterneContents_" + id + "__Pseudo\" name=\"CommentairesExterneContents[" + id + "].Pseudo\" type=\"text\" placeholder=\"Pseudo\">"
        + "<input  class=\"form-control petitChampNiveau\" id=\"CommentairesExterneContents_"+id+"__Niveau\" name=\"CommentairesExterneContents["+id+"].Niveau\" value=\"0\" type=\"number\" disabled=\"disabled\" >"
        + "<button type=\"button\" class=\"btn\" onclick=\"addNiveau(this);\">+</button>"
        + "<button type=\"button\" class=\"btn\" onclick=\"moinsNiveau(this);\">-</button>"
        + "</div><div class=\"col-md-8\">"
        + " <textarea class=\"form-control\" id=\"CommentairesExterneContents_" + id + "__Commentaire\" name=\"CommentairesExterneContents[" + id + "].Commentaire\"  placeholder=\"commentaire\"></textarea>"
        + " </div>";

}

function buttonAdd() {

    var newhtml = newRow(actualId);
    $("#ajoutdecoms").append(newhtml);
    actualId += 1;
}

function addNiveau(div) {
    var directParent = $(div).parents(".row").get(0);
    var grandpere = $(div).parents("#ajoutdecoms");
    var childMoinsUn = null;
    for (var i =0;i<  grandpere.children(".row").length;i++) {
        var child = grandpere.children(".row").get(i);
        if (childMoinsUn != null) {
            if (child == directParent
                && $(childMoinsUn).find(".petitChampNiveau").eq(0).val()
                >= $(child).find(".petitChampNiveau").eq(0).val()) {
                var v = $(child).find(".petitChampNiveau").eq(0).val();
                $(child).find(".petitChampNiveau").attr("value", (parseInt(v) < 4) ?parseInt(v)+1:4);
            }
        }
        childMoinsUn = child;
    }
}
function moinsNiveau(div) {
    var directParent = $(div).parents(".row").get(0);
    var grandpere = $(div).parents("#ajoutdecoms");
    var previouschild = null;
    for (var i = 0; i <= grandpere.children(".row").length; i++) {
        var child = grandpere.children(".row").get(i);
        if (previouschild!=null) {
            if (previouschild == directParent) {
                if (typeof child === 'undefined' || $(previouschild).find(".petitChampNiveau").eq(0).val()
                    >= $(child).find(".petitChampNiveau").eq(0).val()) {
                    var v = $(previouschild).find(".petitChampNiveau").eq(0).val();
                    $(previouschild).find(".petitChampNiveau").attr("value", (parseInt(v) > 0) ? (parseInt(v) - 1) : parseInt(v));
                } else if ($(previouschild).find(".petitChampNiveau").val() > 0) {
                    moinsNiveau($(child).children().eq(0));
                    moinsNiveau(div);
                }
            }
        }
        previouschild = child;
    }
}

$().ready(function () {
    actualId = parseInt($("#lastIndexCom").val());
    $("#addCommentButton").click(buttonAdd);
    $('form').bind('submit', function () {
        $(this).find(':input').removeAttr('disabled');
    });
});

