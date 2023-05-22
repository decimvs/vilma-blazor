/**
 * VilmaBlazor 1.0
 */

var VilmaBlazor = VilmaBlazor || {};

/*** ALERT ********************************************************/

/// Closes the referenced alert
VilmaBlazor.alertClose = function (element) {
    var alert = bootstrap.Alert.getOrCreateInstance(element);
    alert.close();
}

/// Alert event listeners
VilmaBlazor.setAlertListeners = function (dnRef, element) {
    //_setBasicComponentListeners(dnRef, element);
}

/*** BUTTON ********************************************************/

/// Toggles the active status of the button
VilmaBlazor.buttonToggleState = function (element) {
    var button = bootstrap.Button.getOrCreateInstance(element);
    button.toggle();
}

/// Gets the current active status
VilmaBlazor.buttonGetStatus = function (element) {
    var button = document.getElementById(element.id);

    if (button.classList.contains("active"))
        return true;
    else
        return false;
}

/// Gets the value of the property checked
VilmaBlazor.buttonIsChecked = function (element) {
    var button = document.getElementById(element.id);
    return button.checked;
}

/*** CAROUSEL ********************************************************/

/// Initialise the passed carousel and applies the autoplay start
VilmaBlazor.initCarousel = function (element, dotnetref, autostart) {
    var carousel = new bootstrap.Carousel(element);
    var carouselEl = document.getElementById(element.id);

    carouselEl.addEventListener('slid.bs.carousel', event => {
        var data = {
            "Direction": event.direction,
            "RelatedTarget": DotNet.createJSObjectReference(event.relatedTarget),
            "FromIndex": event.from,
            "ToIndex": event.to
        };

        dotnetref.invokeMethodAsync("OnItemSlid", data);
    });

    carouselEl.addEventListener('slide.bs.carousel', event => {
        var data = {
            "Direction": event.direction,
            "RelatedTarget": DotNet.createJSObjectReference(event.relatedTarget),
            "FromIndex": event.from,
            "ToIndex": event.to
        };

        dotnetref.invokeMethodAsync("OnItemSlide", data);
    });

    if (autostart)
        carousel.cycle();
}

/// Cycles the next item
VilmaBlazor.carouselNext = function (element) {
    var carousel = bootstrap.Carousel.getOrCreateInstance(element);
    carousel.next();
}

/// Cycles to the previus item
VilmaBlazor.carouselPrev = function (element) {
    var carousel = bootstrap.Carousel.getOrCreateInstance(element);
    carousel.prev();
}

/// Starts cycling through the carousel items from left to right
VilmaBlazor.carouselCycle = function (element) {
    var carousel = bootstrap.Carousel.getOrCreateInstance(element);
    carousel.cycle();
}

/// Cycles the next item only when the page, the carousel or the carousel's 
/// parent aren't visible.
VilmaBlazor.carouselNextWhenVisible = function (element) {
    var carousel = bootstrap.Carousel.getOrCreateInstance(element);
    carousel.next();
}

/// Stops the carousel from cycling through items
VilmaBlazor.carouselPause = function (element) {
    var carousel = bootstrap.Carousel.getOrCreateInstance(element);
    carousel.pause();
}

/// Cycles the carousel to a particular frame (index starts in 0)
VilmaBlazor.carouselTo = function (element, index) {
    var carousel = bootstrap.Carousel.getOrCreateInstance(element);
    carousel.to(index);
}

/*** DROPDOWN ****************************************************/

/// Sets the event handlers for the dropdown passed
VilmaBlazor.dropdownInit = function (element, dotNetRef) {
    element.addEventListener('hidden.bs.dropdown', event => {
        dotNetRef.invokeMethodAsync('OnDropdownHidden');
    });

    element.addEventListener('shown.bs.dropdown', event => {
        dotNetRef.invokeMethodAsync('OnDropdownShown');
    });
}

/*** TABS ********************************************************/

VilmaBlazor.setActiveTab = function (element) {
    var tab = bootstrap.Tab.getOrCreateInstance('#' + element);
    tab.show();
}

VilmaBlazor.setTabPageListeners = function (dnRef, element) {
    var tabEl = document.getElementById(element);

    tabEl.addEventListener('shown.bs.tab', event => {
        dnRef.invokeMethodAsync('OnTabShown');
    });

    tabEl.addEventListener('hidden.bs.tab', event => {
        dnRef.invokeMethodAsync('OnTabHidden');
    });
}

/*** TOAST ********************************************************/

/// Closes the referenced toast
VilmaBlazor.toastClose = function (element) {
    var toast = bootstrap.Toast.getOrCreateInstance(element);
    toast.hide();
}

/// Toast event listeners
VilmaBlazor.setToastListeners = function (dnRef, element) {
    //_setBasicComponentListeners(dnRef, element);
}
