function closeMenu() {
    document.getElementById("myNav").style.display = "none";
}

function openMenu() {
    document.getElementById("myNav").style.display = "block";
}

function showSubCollections() {
    var subMenuCollection = document.getElementById("subMenuCollection");
    if (subMenuCollection.style.display == "") {
        subMenuCollection.style.display = "block";
    } else {
        subMenuCollection.style.display = "";
    }
}

//function closeModal() {
//    document.getElementById("myModal").style.display = "none";
//}