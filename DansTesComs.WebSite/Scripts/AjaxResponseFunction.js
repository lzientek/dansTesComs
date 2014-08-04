//reponse success truc
function successAddComm() {
    $('#supercompliquepourmettrenotrecom').hide(0);
    $('#supercompliquepourmettrenotrecom').fadeIn(900);
    $(".commentaireDeComExt").last().remove();
}

function changeIdForMoreCom() {
    $("#morecomments").attr("class", "");
    var divtoShow = $("#morecomments");
    divtoShow.attr("id", "morecommentsold");
    divtoShow.hide(0);
    divtoShow.fadeIn(900);
}

function errorAjax() {
    alert("Une erreur est aparu!");
}

function onStartDisableComment() {
    $("#boutonajoutcom").attr("disabled", "disabled");
}

function onStartHideShowMore() {
    $(".PagedList-skipToNext").hide(0);
}
