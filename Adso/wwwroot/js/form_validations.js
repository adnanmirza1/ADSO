$('body').on('keyup', 'input.is-capitalize', function() {
    var val = $(this).val();
    if(val) {
        var valArr = val.split(" ");
        for (let i = 0; i < valArr.length; i++) {
            var word = valArr[i];
            word = word.toLowerCase();
            word = word.charAt(0).toUpperCase() + word.slice(1);
            valArr[i] = word;
        }
        val = valArr.join(" ");
        $(this).val(val);
    }
});

$('body').on('keyup', 'input.is-uppercase', function() {
    var val = $(this).val();
    if(val) {
        $(this).val(val.toUpperCase());
    }
});