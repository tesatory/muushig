function cardClick(card, code) {
    var list = document.getElementById("change_list");
    if (list == null) {
        list = document.getElementById("play_list");
    }
    if (list == null) {
        return;
    }
    var cards = list.getElementsByTagName("input");
    var i;
    var card;
    for (i = 0; i < cards.length; i++) {
        if (cards[i].value == code) {
            if (cards[i].disabled == false) {
                cards[i].checked = !cards[i].checked;
            }
        }
    }

    syncCards();
}

function syncCards() {
    var list = document.getElementById("change_list");
    if (list == null) {
        list = document.getElementById("play_list");
    }
    if (list == null) {
        return;
    }
    var cards = list.getElementsByTagName("input");
    var i;
    var card;
    for (i = 0; i < cards.length; i++) {
        card = document.getElementById("handcard_" + cards[i].value);
        if (cards[i].checked == true) {
            card.parentNode.className = "card_holder_selected";
        } else {
            card.parentNode.className = "card_holder";
        }
    }
}