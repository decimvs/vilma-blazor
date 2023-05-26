export function modalInit(element, dotnetRef) {
    element.addEventListener('hidden.bs.modal', event => {
        dotnetRef.invokeMethodAsync("OnModalHidden");
    });

    element.addEventListener('shown.bs.modal', event => {
        dotnetRef.invokeMethodAsync("OnModalShown");
    });

    element.addEventListener('hidePrevented.bs.modal', event => {
        dotnetRef.invokeMethodAsync("OnModalHidePrevented");
    });
}

export function modalShow(element) {
    var modal = bootstrap.Modal.getOrCreateInstance(element);
    modal.show();
}

export function handleUpdate(element) {
    var modal = bootstrap.Modal.getOrCreateInstance(element);
    modal.handleUpdate();
}

export function modalHide(element) {
    var modal = bootstrap.Modal.getOrCreateInstance(element);
    modal.hide();
}

export function modalToggle(element) {
    var modal = bootstrap.Modal.getOrCreateInstance(element);
    modal.toggle();
}