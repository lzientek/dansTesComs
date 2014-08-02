//reponse success truc
function successAddComm() {
    $('#supercompliquepourmettrenotrecom').hide(0);
    $('#supercompliquepourmettrenotrecom').fadeIn(900);
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