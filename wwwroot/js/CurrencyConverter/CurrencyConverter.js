function validInput(event, keyCode) {
    var keyCode = event.keyCode;

    if (keyCode = 46) {
        var inputValue = $("#fromCurrencyInput").val();
        if (inputValue.includes('.')) {
            event.preventDefault();
        }
    }
    else if (!(keyCode >= 48 && keyCode <= 57)) {
        event.preventDefault();
    }
}