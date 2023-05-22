/*** ACCORDION ********************************************************/

/// Toggle an accordion item.
export function accordionToggle (element) {
    var collapsible = bootstrap.Collapse.getOrCreateInstance(element);
    collapsible.toggle();
}

export function accordionShow (element) {
    var collapsible = bootstrap.Collapse.getOrCreateInstance(element);
    collapsible.show();
}

export function accordionHide (element) {
    var collapsible = bootstrap.Collapse.getOrCreateInstance(element);
    collapsible.hide();
}

/// AccordionItem event listeners
export function setAccordionItemListeners (dnRef, element) {
    setCollapsibleListeners(dnRef, element);
}

function setCollapsibleListeners(dnRef, element) {
    var domelm = document.getElementById(element.id);

    domelm.addEventListener('hidden.bs.collapse', event => {
        dnRef.invokeMethodAsync('OnItemHidden');
    });

    domelm.addEventListener('shown.bs.collapse', event => {
        dnRef.invokeMethodAsync('OnItemShown');
    });
}