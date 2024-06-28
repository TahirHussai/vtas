redirectToCheckout = function (sessionId,PublishableKey) {
    var stripe = Stripe(PublishableKey);
    stripe.redirectToCheckout({
        sessionId: sessionId
    }).then(function (result) {
        if (result.error) {
            var displayError = document.getElementById("stripe-error");
            displayError.textContent = result.error.message;
        }
    });
};