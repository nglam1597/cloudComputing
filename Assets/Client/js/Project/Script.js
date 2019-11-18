
document.getElementById("btnClick").addEventListener("click", function () {
    ID1();
});




function ID1() {
    $.ajax({
        url: "/Calendar/ID",
        type: 'POST',
        success: function (result) {
            console.log(result);
        }
    });
}
