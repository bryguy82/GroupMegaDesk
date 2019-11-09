// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function getMaterial(materialValue) {

    pine = "/images/pine.jpg";
    laminate = "/images/laminate.jpg";
    oak = "/images/oak.jpg";
    rosewood = "/images/rosewood.jpg";
    veneer = "/images/veneer.jpg";

    if (materialValue == "Pine") {
        document.getElementById("materialImage").src = pine;
    }

    if (materialValue == "Laminate") {
        document.getElementById("materialImage").src = laminate;
    }

    if (materialValue == "Oak") {
        document.getElementById("materialImage").src = oak;
    }

    if (materialValue == "Rosewood") {
        document.getElementById("materialImage").src = rosewood;
    }

    if (materialValue == "Veneer") {
        document.getElementById("materialImage").src = veneer;
    }
}